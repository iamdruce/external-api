using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Discovery;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using System.IO;
using Google.Apis.Auth.OAuth2;

namespace StorageDestopClient
{
    public class GoogleDriveStorage : IStorageProvider
    {
        private UserCredential credential = null;
        private DriveService service = null; 
        private bool disposedValue;

        //public GoogleDriveStorage(string apiKey)
        //{            
        //    service = new DriveService(new BaseClientService.Initializer
        //    {
        //        ApplicationName = "AndrushkevychDesktopApp",
        //        ApiKey = apiKey,
        //    });
        //}

        public GoogleDriveStorage(UserCredential credential)
        {
            this.credential = credential;
            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "DesktopStorageClient",
            });
        }

        public async Task<StorageResponse> CreateFolderAsync(string path, string name)
        {
            try
            {
                var metadata = new Google.Apis.Drive.v3.Data.File() 
                { 
                    Name = name, 
                    MimeType = "application/vnd.google-apps.folder" 
                };

                var creation = service.Files.Create(metadata);
                var res = await creation.ExecuteAsync();
                
                return new StorageResponse(true, "Successfully created!");
            }
            catch (Exception ex)
            {
                return new StorageResponse(false, "Cannot create \n" + ex.Message);
            }
        }

        public async Task<StorageResponse> DeleteFolderAsync(string path)
        {
            path = path.Trim('/');
            try
            {
                var files = await service.Files.List().ExecuteAsync();
                var fileToDelete = files.Files.FirstOrDefault(f => f.Name == path);
                var deleteProccess = await service.Files.Delete(fileToDelete.Id).ExecuteAsync();
                return new StorageResponse(true, "Success!");
            }
            catch (Exception ex)
            {
                return new StorageResponse(false, "Cannot delete \n" + ex.Message);
            }
        }

        public async Task<List<TreeNode>> GetItemsAsync(string path)
        {
            var files = await service.Files.List().ExecuteAsync();
            List<TreeNode> treeNodes = new List<TreeNode>();
            foreach (var file in files.Files)
            {
                if (file.MimeType.Contains("folder"))
                {
                    treeNodes.Add(new TreeNode(file.Name, 0, 0));
                }
                else
                {
                    treeNodes.Add(new TreeNode(file.Name, 1, 1));
                }                
            }
            return treeNodes.OrderBy(tn => tn.ImageIndex).ToList();
        }

        public async Task<StorageResponse> RenameFolderAsync(string oldPath, string newPath)
        {
            var oldName = oldPath.Trim('/').Split('/').Last();
            var newName = newPath.Trim('/').Split('/').Last();
            try
            {
                var files = await service.Files.List().ExecuteAsync();
                var fileToRename = files.Files.FirstOrDefault(f => f.Name == oldName);

                var metadata = new Google.Apis.Drive.v3.Data.File() { Name = newName };
                var renameProccess = await service.Files.Update(metadata, fileToRename.Id).ExecuteAsync();
                return new StorageResponse(true, "Success!");
            }
            catch (Exception ex)
            {
                return new StorageResponse(false, "Cannot rename \n" + ex.Message);
            }
        }

        public async Task<StorageResponse> UploadFileAsync(string storagePath, string filePath)
        {
            var uploadStream = new System.IO.FileStream(filePath,
                                                System.IO.FileMode.Open,
                                                System.IO.FileAccess.Read);
            try
            {                
                string filename = Path.GetFileName(filePath);
                var metadata = new Google.Apis.Drive.v3.Data.File() { Name = filename };
                var creation = service.Files.Create(metadata, uploadStream, "image/png");
                var res = await creation.UploadAsync();
                
                return new StorageResponse(true, "Successfully uploaded! "+ res.Status);
            }
            catch (Exception ex)
            {
                return new StorageResponse(false, "Cannot upload \n" + ex.Message);
            }
            finally
            {
                uploadStream.Dispose();
            }            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    service.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~GoogleDriveStorage()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
