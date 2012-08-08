namespace DirectoryBrowser
{
  partial class FolderBrowser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderView = new FileBrowser.BrowserTreeView();
            this.SuspendLayout();
            // 
            // folderView
            // 
            this.folderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderView.HideSelection = false;
            this.folderView.HotTracking = true;
            this.folderView.Location = new System.Drawing.Point(0, 0);
            this.folderView.Name = "folderView";
            this.folderView.ShowLines = false;
            this.folderView.ShowRootLines = false;
            this.folderView.Size = new System.Drawing.Size(196, 310);
            this.folderView.TabIndex = 1;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.folderView);
            this.Name = "Browser";
            this.Size = new System.Drawing.Size(196, 310);
            this.ResumeLayout(false);

        }

        #endregion

        private FileBrowser.BrowserTreeView folderView;


    }
}
