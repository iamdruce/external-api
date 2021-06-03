using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageDestopClient
{
    interface IStorageProvider:IDisposable
    {
        Task<List<TreeNode>> GetItemsAsync(string path);
        Task<StorageResponse> UploadFileAsync(string dropBoxPath, string filename);
        Task<StorageResponse> CreateFolderAsync(string path, string name);
        Task<StorageResponse> RenameFolderAsync(string oldPath, string newPath);
        Task<StorageResponse> DeleteFolderAsync(string path);
    }
}
