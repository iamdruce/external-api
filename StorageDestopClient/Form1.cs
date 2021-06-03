using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageDestopClient
{
    public partial class Form1 : Form
    {

        IStorageProvider storageProvider = null;
        public Form1()
        {
            InitializeComponent();
            itemsList.ImageList = imageList1;
            itemsList.PathSeparator = "/";
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private async void RefreshItems()
        {
            if (storageProvider == null)
            {
                MessageBox.Show("Connect to storage first.");
                return;
            }

            itemsList.Nodes.Clear();
            itemsList.Nodes.AddRange((await storageProvider.GetItemsAsync(string.Empty)).ToArray());
        }

        private async void upload_btn_Click(object sender, EventArgs e)
        {
            if (storageProvider == null)
            {
                MessageBox.Show("Connect to storage first.");
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                var result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var response = await storageProvider.UploadFileAsync("/" + openFileDialog.SafeFileName, openFileDialog.FileName);
                    MessageBox.Show(
                        response.Message, 
                        response.Success ? "Success!" : "Ooops!",
                        MessageBoxButtons.OK, 
                        response.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                }
            }

            RefreshItems();
        }

        private async void newFolder_btn_Click(object sender, EventArgs e)
        {
            if (storageProvider == null)
            {
                MessageBox.Show("Connect to storage first.");
                return;
            }

            var response = await storageProvider.CreateFolderAsync("", folderName_tb.Text);
            MessageBox.Show(
                response.Message, 
                response.Success ? "Success!" : "Ooops!", 
                MessageBoxButtons.OK, 
                response.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            RefreshItems();
        }

        private async void renameFolder_btn_Click(object sender, EventArgs e)
        {
            if (storageProvider == null)
            {
                MessageBox.Show("Connect to storage first.");
                return;
            }

            var response = await storageProvider.RenameFolderAsync(
                "/" + itemsList.SelectedNode.FullPath, 
                ("/" + itemsList.SelectedNode.Parent?.FullPath + "/" + folderName_tb.Text).Replace("//","/"));
            MessageBox.Show(
                response.Message, 
                response.Success ? "Success!" : "Ooops!", MessageBoxButtons.OK, 
                response.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            RefreshItems();
        }

        private async void delete_btn_Click(object sender, EventArgs e)
        {
            if (storageProvider == null)
            {
                MessageBox.Show("Connect to storage first.");
                return;
            }

            var response = await storageProvider.DeleteFolderAsync("/" + itemsList.SelectedNode.FullPath);
            MessageBox.Show(
                response.Message,
                response.Success ? "Success!" : "Ooops!", MessageBoxButtons.OK,
                response.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            RefreshItems();
        }

        private void dropboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TokenInput tokenInput=new TokenInput())
            {
                if (tokenInput.ShowDialog() == DialogResult.OK)
                {
                    storageProvider = new DropBoxStorage(tokenInput.Token);
                    RefreshItems();
                }
            }
        }

        private async void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    storageProvider = new GoogleDriveStorage(await GoogleAuthenticator.GetUserCredential(openFileDialog.FileName));
                    RefreshItems();
                }
            }
        }

        private new void Dispose()
        {
            storageProvider.Dispose();
            base.Dispose();            
        }
    }
}
