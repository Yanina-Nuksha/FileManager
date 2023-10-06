
namespace FileManager._1
{
    partial class FileManager
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManager));
            this.button_Documents = new System.Windows.Forms.Button();
            this.button_Pictures = new System.Windows.Forms.Button();
            this.button_Videos = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.LayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.currentDirectoryLabel = new System.Windows.Forms.Label();
            this.selectedLabel = new System.Windows.Forms.Label();
            this.button_Desktop = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.CutOut = new System.Windows.Forms.Button();
            this.Sort = new System.Windows.Forms.Button();
            this.Put = new System.Windows.Forms.Button();
            this.Copy = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Documents
            // 
            this.button_Documents.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_Documents.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Documents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Documents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Documents.Location = new System.Drawing.Point(12, 160);
            this.button_Documents.Name = "button_Documents";
            this.button_Documents.Size = new System.Drawing.Size(236, 32);
            this.button_Documents.TabIndex = 1;
            this.button_Documents.Text = "Документы";
            this.button_Documents.UseVisualStyleBackColor = false;
            this.button_Documents.Click += new System.EventHandler(this.Documents_Click);
            // 
            // button_Pictures
            // 
            this.button_Pictures.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_Pictures.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Pictures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Pictures.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Pictures.Location = new System.Drawing.Point(12, 198);
            this.button_Pictures.Name = "button_Pictures";
            this.button_Pictures.Size = new System.Drawing.Size(236, 32);
            this.button_Pictures.TabIndex = 4;
            this.button_Pictures.Text = "Изображения";
            this.button_Pictures.UseVisualStyleBackColor = false;
            this.button_Pictures.Click += new System.EventHandler(this.Pictures_Click);
            // 
            // button_Videos
            // 
            this.button_Videos.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_Videos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Videos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Videos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Videos.Location = new System.Drawing.Point(12, 236);
            this.button_Videos.Name = "button_Videos";
            this.button_Videos.Size = new System.Drawing.Size(236, 32);
            this.button_Videos.TabIndex = 7;
            this.button_Videos.Text = "Видео";
            this.button_Videos.UseVisualStyleBackColor = false;
            this.button_Videos.Click += new System.EventHandler(this.Videos_Click);
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.back.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.back.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Location = new System.Drawing.Point(12, 625);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(74, 30);
            this.back.TabIndex = 8;
            this.back.Text = " Назад";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.Back_Click);
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeView.Location = new System.Drawing.Point(12, 284);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(236, 322);
            this.treeView.TabIndex = 13;
            this.treeView.Click += new System.EventHandler(this.Panel_Click);
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutPanel.AutoScroll = true;
            this.LayoutPanel.Location = new System.Drawing.Point(266, 123);
            this.LayoutPanel.MinimumSize = new System.Drawing.Size(895, 401);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.Size = new System.Drawing.Size(904, 523);
            this.LayoutPanel.TabIndex = 15;
            this.LayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLayoutPanel_Paint);
            // 
            // checkBox
            // 
            this.checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox.AutoSize = true;
            this.checkBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox.Location = new System.Drawing.Point(163, 630);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(85, 21);
            this.checkBox.TabIndex = 17;
            this.checkBox.Text = "Скрытые";
            this.checkBox.UseVisualStyleBackColor = false;
            this.checkBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cut.png");
            this.imageList1.Images.SetKeyName(1, "put_.png");
            this.imageList1.Images.SetKeyName(2, "copy_.png");
            this.imageList1.Images.SetKeyName(3, "delete.png");
            this.imageList1.Images.SetKeyName(4, "sort.png");
            this.imageList1.Images.SetKeyName(5, "dd7cd5bf-c89a-4afb-a087-e62f9b9a8ea9.jpg");
            // 
            // currentDirectoryLabel
            // 
            this.currentDirectoryLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentDirectoryLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currentDirectoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentDirectoryLabel.Location = new System.Drawing.Point(269, 85);
            this.currentDirectoryLabel.Name = "currentDirectoryLabel";
            this.currentDirectoryLabel.Size = new System.Drawing.Size(901, 25);
            this.currentDirectoryLabel.TabIndex = 26;
            this.currentDirectoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.currentDirectoryLabel.Click += new System.EventHandler(this.Panel_Click);
            // 
            // selectedLabel
            // 
            this.selectedLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectedLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectedLabel.Location = new System.Drawing.Point(269, 60);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(901, 25);
            this.selectedLabel.TabIndex = 27;
            this.selectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectedLabel.Click += new System.EventHandler(this.Panel_Click);
            // 
            // button_Desktop
            // 
            this.button_Desktop.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_Desktop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Desktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Desktop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Desktop.Location = new System.Drawing.Point(12, 122);
            this.button_Desktop.Name = "button_Desktop";
            this.button_Desktop.Size = new System.Drawing.Size(236, 32);
            this.button_Desktop.TabIndex = 28;
            this.button_Desktop.Text = "Рабочий стол";
            this.button_Desktop.UseVisualStyleBackColor = false;
            this.button_Desktop.Click += new System.EventHandler(this.Desktop_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImage = global::FileManager._1.Properties.Resources._;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1185, 45);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // CutOut
            // 
            this.CutOut.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CutOut.BackgroundImage = global::FileManager._1.Properties.Resources.cut;
            this.CutOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CutOut.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CutOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CutOut.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CutOut.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CutOut.Location = new System.Drawing.Point(154, 69);
            this.CutOut.Name = "CutOut";
            this.CutOut.Size = new System.Drawing.Size(33, 34);
            this.CutOut.TabIndex = 22;
            this.CutOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CutOut.UseVisualStyleBackColor = false;
            // 
            // Sort
            // 
            this.Sort.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Sort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Sort.BackgroundImage")));
            this.Sort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Sort.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sort.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Sort.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Sort.Location = new System.Drawing.Point(193, 63);
            this.Sort.Name = "Sort";
            this.Sort.Size = new System.Drawing.Size(25, 47);
            this.Sort.TabIndex = 21;
            this.Sort.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Sort.UseVisualStyleBackColor = false;
            this.Sort.Click += new System.EventHandler(this.Sort_Click);
            // 
            // Put
            // 
            this.Put.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Put.BackgroundImage = global::FileManager._1.Properties.Resources.put_;
            this.Put.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Put.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Put.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Put.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Put.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Put.Location = new System.Drawing.Point(115, 69);
            this.Put.Name = "Put";
            this.Put.Size = new System.Drawing.Size(33, 34);
            this.Put.TabIndex = 20;
            this.Put.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Put.UseVisualStyleBackColor = false;
            this.Put.Click += new System.EventHandler(this.Paste_Click);
            // 
            // Copy
            // 
            this.Copy.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Copy.BackgroundImage = global::FileManager._1.Properties.Resources.copy_;
            this.Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Copy.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Copy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Copy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Copy.Location = new System.Drawing.Point(76, 69);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(33, 34);
            this.Copy.TabIndex = 19;
            this.Copy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Copy.UseVisualStyleBackColor = false;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Delete.BackgroundImage")));
            this.Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Delete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Delete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Delete.Location = new System.Drawing.Point(41, 69);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(29, 34);
            this.Delete.TabIndex = 18;
            this.Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // FileManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.button_Desktop);
            this.Controls.Add(this.selectedLabel);
            this.Controls.Add(this.currentDirectoryLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.CutOut);
            this.Controls.Add(this.Sort);
            this.Controls.Add(this.Put);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.LayoutPanel);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.back);
            this.Controls.Add(this.button_Videos);
            this.Controls.Add(this.button_Pictures);
            this.Controls.Add(this.button_Documents);
            this.MinimumSize = new System.Drawing.Size(311, 250);
            this.Name = "FileManager";
            this.Text = "FileManager";
            this.Load += new System.EventHandler(this.FileManager_Load);
            this.Click += new System.EventHandler(this.Panel_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Documents;
        private System.Windows.Forms.Button button_Pictures;
        private System.Windows.Forms.Button button_Videos;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.FlowLayoutPanel LayoutPanel;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.Button Put;
        private System.Windows.Forms.Button Sort;
        private System.Windows.Forms.Button CutOut;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label currentDirectoryLabel;
        protected System.Windows.Forms.Label selectedLabel;
        private System.Windows.Forms.Button button_Desktop;
    }
}

