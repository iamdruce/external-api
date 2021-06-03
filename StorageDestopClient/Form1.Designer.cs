namespace StorageDestopClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.itemsList = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.upload_btn = new System.Windows.Forms.Button();
            this.newFolder_btn = new System.Windows.Forms.Button();
            this.folderName_tb = new System.Windows.Forms.TextBox();
            this.renameFolder_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemsList
            // 
            this.itemsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.itemsList.LabelEdit = true;
            this.itemsList.Location = new System.Drawing.Point(12, 35);
            this.itemsList.Name = "itemsList";
            this.itemsList.Size = new System.Drawing.Size(423, 403);
            this.itemsList.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(642, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dropboxToolStripMenuItem,
            this.googleToolStripMenuItem});
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // dropboxToolStripMenuItem
            // 
            this.dropboxToolStripMenuItem.Name = "dropboxToolStripMenuItem";
            this.dropboxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dropboxToolStripMenuItem.Text = "Dropbox";
            this.dropboxToolStripMenuItem.Click += new System.EventHandler(this.dropboxToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "file.png");
            // 
            // upload_btn
            // 
            this.upload_btn.Location = new System.Drawing.Point(6, 19);
            this.upload_btn.Name = "upload_btn";
            this.upload_btn.Size = new System.Drawing.Size(178, 23);
            this.upload_btn.TabIndex = 3;
            this.upload_btn.Text = "Upload file";
            this.upload_btn.UseVisualStyleBackColor = true;
            this.upload_btn.Click += new System.EventHandler(this.upload_btn_Click);
            // 
            // newFolder_btn
            // 
            this.newFolder_btn.Location = new System.Drawing.Point(6, 45);
            this.newFolder_btn.Name = "newFolder_btn";
            this.newFolder_btn.Size = new System.Drawing.Size(178, 23);
            this.newFolder_btn.TabIndex = 4;
            this.newFolder_btn.Text = "New folder";
            this.newFolder_btn.UseVisualStyleBackColor = true;
            this.newFolder_btn.Click += new System.EventHandler(this.newFolder_btn_Click);
            // 
            // folderName_tb
            // 
            this.folderName_tb.Location = new System.Drawing.Point(6, 19);
            this.folderName_tb.Name = "folderName_tb";
            this.folderName_tb.Size = new System.Drawing.Size(178, 20);
            this.folderName_tb.TabIndex = 5;
            // 
            // renameFolder_btn
            // 
            this.renameFolder_btn.Location = new System.Drawing.Point(6, 74);
            this.renameFolder_btn.Name = "renameFolder_btn";
            this.renameFolder_btn.Size = new System.Drawing.Size(178, 23);
            this.renameFolder_btn.TabIndex = 6;
            this.renameFolder_btn.Text = "Rename selected folder";
            this.renameFolder_btn.UseVisualStyleBackColor = true;
            this.renameFolder_btn.Click += new System.EventHandler(this.renameFolder_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(6, 48);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(178, 23);
            this.delete_btn.TabIndex = 7;
            this.delete_btn.Text = "Delete selected";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.folderName_tb);
            this.groupBox1.Controls.Add(this.newFolder_btn);
            this.groupBox1.Controls.Add(this.renameFolder_btn);
            this.groupBox1.Location = new System.Drawing.Point(441, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 109);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create/Rename";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.upload_btn);
            this.groupBox2.Controls.Add(this.delete_btn);
            this.groupBox2.Location = new System.Drawing.Point(441, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 79);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Upload/Delete";
            // 
            // googleToolStripMenuItem
            // 
            this.googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            this.googleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.googleToolStripMenuItem.Text = "Google";
            this.googleToolStripMenuItem.Click += new System.EventHandler(this.googleToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.itemsList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView itemsList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button upload_btn;
        private System.Windows.Forms.Button newFolder_btn;
        private System.Windows.Forms.TextBox folderName_tb;
        private System.Windows.Forms.Button renameFolder_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
    }
}

