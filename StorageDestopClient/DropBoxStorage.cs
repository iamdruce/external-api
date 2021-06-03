using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageDestopClient
{
    class DropBoxStorage : IStorageProvider
    {
        private string _token = null;
        private DropboxClient dbx = null;
        private bool disposedValue;

        public DropBoxStorage(string token)
        {
            _token = token;
            dbx = new DropboxClient(_token);            
        }

        public async Task<List<TreeNode>> GetItemsAsync(string path)
        {            
            List<TreeNode> treeNodes = new List<TreeNode>();
            var list = await dbx.Files.ListFolderAsync(path);
            foreach (var item in list.Entries.Where(i => i.IsFolder))
            {
                TreeNode t = new TreeNode(item.Name, 0, 0);
                treeNodes.Add(t);
            }
            foreach (var item in list.Entries.Where(i => i.IsFile))
            {
                TreeNode t = new TreeNode(item.Name, 1, 1);
                treeNodes.Add(t);
            }

            return treeNodes;
        }

        public async Task<StorageResponse> UploadFileAsync(string dropBoxPath, string filename)
        {
            StorageResponse response = new StorageResponse(false, "Not run");

            var ms = new MemoryStream(File.ReadAllBytes(filename));
            try
            {
                var updated = await dbx.Files.UploadAsync(dropBoxPath, autorename: true, body: ms);
                response = new StorageResponse(true, "File uploaded.");
            }
            catch(Exception e)
            {
                response = new StorageResponse(false, e.Message);
            }
            finally
            {
                ms.Dispose();
            }

            return response;
        }


        public async Task<StorageResponse> CreateFolderAsync(string path, string name)
        {
            StorageResponse response = new StorageResponse(false, "Not run");

            try
            {
                var f = await dbx.Files.CreateFolderV2Async(path + '/' + name);
                response = new StorageResponse(true, "Folder created.");
            }
            catch (Exception e)
            {
                response = new StorageResponse(false, e.Message);
            }

            return response;
        }

        public async Task<StorageResponse> DeleteFolderAsync(string path)
        {
            StorageResponse response = new StorageResponse(false, "Not run");

            try
            {
                var f = await dbx.Files.DeleteV2Async(path);
                response = new StorageResponse(true, "Item deleted.");
            }
            catch (Exception e)
            {
                response = new StorageResponse(false, e.Message);
            }

            return response;
        }

        public async Task<StorageResponse> RenameFolderAsync(string oldPath, string newPath)
        {
            StorageResponse response = new StorageResponse(false, "Not run");

            try
            {
                var f = await dbx.Files.MoveV2Async(oldPath, newPath);
                response = new StorageResponse(true, "Folder renamed.");
            }
            catch (Exception e)
            {
                response = new StorageResponse(false, e.Message);
            }

            return response;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbx.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DropBoxStorage()
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
