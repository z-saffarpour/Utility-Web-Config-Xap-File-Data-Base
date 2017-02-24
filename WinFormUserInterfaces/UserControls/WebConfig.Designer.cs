namespace ZaHra.WinFormUserInterfaces.UserControls
{
    partial class WebConfig
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
            this.components = new System.ComponentModel.Container();
            this.dgvConfig = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnOpenDirectory = new System.Windows.Forms.Button();
            this.btnOpenPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfig)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConfig
            // 
            this.dgvConfig.AllowUserToAddRows = false;
            this.dgvConfig.AllowUserToDeleteRows = false;
            this.dgvConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfig.Location = new System.Drawing.Point(44, 59);
            this.dgvConfig.Name = "dgvConfig";
            this.dgvConfig.ReadOnly = true;
            this.dgvConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConfig.ShowCellErrors = false;
            this.dgvConfig.ShowCellToolTips = false;
            this.dgvConfig.ShowEditingIcon = false;
            this.dgvConfig.ShowRowErrors = false;
            this.dgvConfig.Size = new System.Drawing.Size(696, 275);
            this.dgvConfig.TabIndex = 2;
            this.dgvConfig.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConfig_CellDoubleClick);
            this.dgvConfig.SelectionChanged += new System.EventHandler(this.dgvConfig_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnConfig);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnReadFile);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.btnEdit);
            this.groupBox3.Location = new System.Drawing.Point(3, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(35, 155);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // btnConfig
            // 
            this.btnConfig.Enabled = false;
            this.btnConfig.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnConfig.Location = new System.Drawing.Point(6, 128);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 4;
            this.btnConfig.Text = "";
            this.toolTip1.SetToolTip(this.btnConfig, "تنظیم فایل انتخاب شده");
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnDelete.Location = new System.Drawing.Point(6, 99);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "";
            this.toolTip1.SetToolTip(this.btnDelete, "حذف");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReadFile
            // 
            this.btnReadFile.Enabled = false;
            this.btnReadFile.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnReadFile.Location = new System.Drawing.Point(6, 12);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(25, 23);
            this.btnReadFile.TabIndex = 0;
            this.btnReadFile.Text = "";
            this.toolTip1.SetToolTip(this.btnReadFile, "خواندن فایل انتخاب شده");
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnAdd.Location = new System.Drawing.Point(6, 41);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "";
            this.toolTip1.SetToolTip(this.btnAdd, "افزودن");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("FontAwesome", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(6, 70);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "";
            this.toolTip1.SetToolTip(this.btnEdit, "ویرایش");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenFile);
            this.groupBox2.Controls.Add(this.btnOpenDirectory);
            this.groupBox2.Controls.Add(this.btnOpenPath);
            this.groupBox2.Controls.Add(this.txtPath);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(737, 50);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Enabled = false;
            this.btnOpenFile.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnOpenFile.Location = new System.Drawing.Point(37, 17);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(25, 23);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "";
            this.toolTip1.SetToolTip(this.btnOpenFile, "انتخاب فایل");
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnOpenDirectory
            // 
            this.btnOpenDirectory.Enabled = false;
            this.btnOpenDirectory.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnOpenDirectory.Location = new System.Drawing.Point(6, 17);
            this.btnOpenDirectory.Name = "btnOpenDirectory";
            this.btnOpenDirectory.Size = new System.Drawing.Size(25, 23);
            this.btnOpenDirectory.TabIndex = 3;
            this.btnOpenDirectory.Text = "";
            this.toolTip1.SetToolTip(this.btnOpenDirectory, "نمایش فایل");
            this.btnOpenDirectory.UseVisualStyleBackColor = true;
            this.btnOpenDirectory.Click += new System.EventHandler(this.btnOpenDirectory_Click);
            // 
            // btnOpenPath
            // 
            this.btnOpenPath.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnOpenPath.Location = new System.Drawing.Point(68, 17);
            this.btnOpenPath.Name = "btnOpenPath";
            this.btnOpenPath.Size = new System.Drawing.Size(25, 23);
            this.btnOpenPath.TabIndex = 1;
            this.btnOpenPath.Text = "";
            this.toolTip1.SetToolTip(this.btnOpenPath, "انتخاب فایل");
            this.btnOpenPath.UseVisualStyleBackColor = true;
            this.btnOpenPath.Click += new System.EventHandler(this.btnOpenPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(99, 19);
            this.txtPath.Name = "txtPath";
            this.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPath.Size = new System.Drawing.Size(563, 20);
            this.txtPath.TabIndex = 0;
            this.txtPath.Leave += new System.EventHandler(this.txtPath_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(668, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "مسیر فایل : ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 337);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(642, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // WebConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvConfig);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "WebConfig";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(743, 359);
            this.Load += new System.EventHandler(this.WebConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfig)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConfig;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpenPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnOpenDirectory;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnOpenFile;
    }
}
