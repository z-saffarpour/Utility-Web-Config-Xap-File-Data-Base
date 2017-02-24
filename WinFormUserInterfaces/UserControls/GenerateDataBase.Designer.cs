namespace ZaHra.WinFormUserInterfaces.UserControls
{
    partial class GenerateDataBase
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
            this.dgvTabel = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnAllConfig = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnOpenDirectory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvColumn = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabel)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTabel
            // 
            this.dgvTabel.AllowUserToAddRows = false;
            this.dgvTabel.AllowUserToDeleteRows = false;
            this.dgvTabel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabel.Location = new System.Drawing.Point(452, 115);
            this.dgvTabel.Name = "dgvTabel";
            this.dgvTabel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTabel.ShowCellErrors = false;
            this.dgvTabel.ShowCellToolTips = false;
            this.dgvTabel.ShowEditingIcon = false;
            this.dgvTabel.ShowRowErrors = false;
            this.dgvTabel.Size = new System.Drawing.Size(285, 215);
            this.dgvTabel.TabIndex = 3;
            this.dgvTabel.SelectionChanged += new System.EventHandler(this.dgvTabel_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReadFile);
            this.groupBox3.Controls.Add(this.btnAllConfig);
            this.groupBox3.Controls.Add(this.btnConfig);
            this.groupBox3.Location = new System.Drawing.Point(3, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(35, 111);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btnReadFile
            // 
            this.btnReadFile.Enabled = false;
            this.btnReadFile.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnReadFile.Location = new System.Drawing.Point(7, 15);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(25, 23);
            this.btnReadFile.TabIndex = 0;
            this.btnReadFile.Text = "";
            this.toolTip1.SetToolTip(this.btnReadFile, "خواندن مسیر انتخاب شده");
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // btnAllConfig
            // 
            this.btnAllConfig.Enabled = false;
            this.btnAllConfig.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnAllConfig.Location = new System.Drawing.Point(6, 73);
            this.btnAllConfig.Name = "btnAllConfig";
            this.btnAllConfig.Size = new System.Drawing.Size(25, 23);
            this.btnAllConfig.TabIndex = 2;
            this.btnAllConfig.Text = "";
            this.toolTip1.SetToolTip(this.btnAllConfig, "اجرای تمام اسکریپت ها");
            this.btnAllConfig.UseVisualStyleBackColor = true;
            this.btnAllConfig.Click += new System.EventHandler(this.btnAllConfig_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Enabled = false;
            this.btnConfig.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnConfig.Location = new System.Drawing.Point(7, 44);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.Text = "";
            this.toolTip1.SetToolTip(this.btnConfig, "اجرای اسکریپت انتخاب شده");
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTestConnection);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.txtDataBase);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Enabled = false;
            this.btnTestConnection.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnTestConnection.Location = new System.Drawing.Point(10, 18);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(25, 23);
            this.btnTestConnection.TabIndex = 4;
            this.btnTestConnection.Text = "";
            this.toolTip1.SetToolTip(this.btnTestConnection, "تست برقراری ارتباط");
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(568, 19);
            this.txtServer.Name = "txtServer";
            this.txtServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServer.Size = new System.Drawing.Size(90, 20);
            this.txtServer.TabIndex = 0;
            this.txtServer.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(41, 19);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDataBase.Size = new System.Drawing.Size(95, 20);
            this.txtDataBase.TabIndex = 3;
            this.txtDataBase.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(231, 19);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(110, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "بانک اطلاعاتی  : ";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(414, 19);
            this.txtUser.Name = "txtUser";
            this.txtUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUser.Size = new System.Drawing.Size(75, 20);
            this.txtUser.TabIndex = 1;
            this.txtUser.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "کلمه عبور : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(495, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "نام کاربری : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(664, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "آدرس سرور : ";
            // 
            // btnOpenDirectory
            // 
            this.btnOpenDirectory.Enabled = false;
            this.btnOpenDirectory.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnOpenDirectory.Location = new System.Drawing.Point(6, 17);
            this.btnOpenDirectory.Name = "btnOpenDirectory";
            this.btnOpenDirectory.Size = new System.Drawing.Size(25, 23);
            this.btnOpenDirectory.TabIndex = 2;
            this.btnOpenDirectory.Text = "";
            this.toolTip1.SetToolTip(this.btnOpenDirectory, "باز کردن انتخاب مسیر اسکریپت");
            this.btnOpenDirectory.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenDirectory);
            this.groupBox2.Controls.Add(this.btnOpenPath);
            this.groupBox2.Controls.Add(this.txtPath);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnOpenPath
            // 
            this.btnOpenPath.Font = new System.Drawing.Font("FontAwesome", 9F);
            this.btnOpenPath.Location = new System.Drawing.Point(37, 17);
            this.btnOpenPath.Name = "btnOpenPath";
            this.btnOpenPath.Size = new System.Drawing.Size(25, 23);
            this.btnOpenPath.TabIndex = 1;
            this.btnOpenPath.Text = "";
            this.toolTip1.SetToolTip(this.btnOpenPath, "انتخاب مسیر اسکریپت");
            this.btnOpenPath.UseVisualStyleBackColor = true;
            this.btnOpenPath.Click += new System.EventHandler(this.btnOpenPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(68, 19);
            this.txtPath.Name = "txtPath";
            this.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPath.Size = new System.Drawing.Size(585, 20);
            this.txtPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(659, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "مسیر ذخیره : ";
            // 
            // dgvColumn
            // 
            this.dgvColumn.AllowUserToAddRows = false;
            this.dgvColumn.AllowUserToDeleteRows = false;
            this.dgvColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumn.Location = new System.Drawing.Point(44, 115);
            this.dgvColumn.Name = "dgvColumn";
            this.dgvColumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColumn.ShowCellErrors = false;
            this.dgvColumn.ShowCellToolTips = false;
            this.dgvColumn.ShowEditingIcon = false;
            this.dgvColumn.ShowRowErrors = false;
            this.dgvColumn.Size = new System.Drawing.Size(402, 215);
            this.dgvColumn.TabIndex = 4;
            // 
            // GenerateDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvColumn);
            this.Controls.Add(this.dgvTabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerateDataBase";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(743, 359);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabel)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Button btnAllConfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnOpenDirectory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpenPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvColumn;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.Button btnConfig;
    }
}
