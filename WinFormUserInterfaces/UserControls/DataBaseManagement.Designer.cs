namespace ZaHra.WinFormUserInterfaces.UserControls
{
    partial class DataBaseManagement
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkEncryption = new System.Windows.Forms.CheckBox();
            this.btnDataBaseManegment = new System.Windows.Forms.Button();
            this.cmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkEncryption);
            this.groupBox4.Controls.Add(this.btnDataBaseManegment);
            this.groupBox4.Controls.Add(this.cmb);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtServer);
            this.groupBox4.Controls.Add(this.txtDataBase);
            this.groupBox4.Controls.Add(this.txtPassword);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtUser);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(446, 139);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // chkEncryption
            // 
            this.chkEncryption.AutoSize = true;
            this.chkEncryption.Location = new System.Drawing.Point(252, 108);
            this.chkEncryption.Name = "chkEncryption";
            this.chkEncryption.Size = new System.Drawing.Size(188, 17);
            this.chkEncryption.TabIndex = 6;
            this.chkEncryption.Text = "رمزگذاری تنظیمات ارتباط با دیتابیس";
            this.chkEncryption.UseVisualStyleBackColor = true;
            this.chkEncryption.Visible = false;
            // 
            // btnDataBaseManegment
            // 
            this.btnDataBaseManegment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDataBaseManegment.Location = new System.Drawing.Point(6, 17);
            this.btnDataBaseManegment.Name = "btnDataBaseManegment";
            this.btnDataBaseManegment.Size = new System.Drawing.Size(25, 23);
            this.btnDataBaseManegment.TabIndex = 1;
            this.btnDataBaseManegment.Text = "";
            this.toolTip1.SetToolTip(this.btnDataBaseManegment, "افزودن");
            this.btnDataBaseManegment.UseVisualStyleBackColor = true;
            this.btnDataBaseManegment.Visible = false;
            // 
            // cmb
            // 
            this.cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb.Location = new System.Drawing.Point(37, 19);
            this.cmb.Name = "cmb";
            this.cmb.Size = new System.Drawing.Size(345, 21);
            this.cmb.TabIndex = 0;
            this.cmb.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "انتخابی : ";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(224, 45);
            this.txtServer.Name = "txtServer";
            this.txtServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServer.Size = new System.Drawing.Size(127, 20);
            this.txtServer.TabIndex = 2;
            this.txtServer.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(224, 72);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDataBase.Size = new System.Drawing.Size(127, 20);
            this.txtDataBase.TabIndex = 3;
            this.txtDataBase.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(6, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(139, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(357, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "بانک اطلاعاتی  : ";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(6, 46);
            this.txtUser.Name = "txtUser";
            this.txtUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUser.Size = new System.Drawing.Size(139, 20);
            this.txtUser.TabIndex = 4;
            this.txtUser.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "کلمه عبور : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "نام کاربری : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "آدرس سرور : ";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Enabled = false;
            this.btnTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTestConnection.Location = new System.Drawing.Point(365, 157);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(25, 23);
            this.btnTestConnection.TabIndex = 1;
            this.btnTestConnection.Text = "";
            this.toolTip1.SetToolTip(this.btnTestConnection, "تست برقراری ارتباط");
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCancel.Location = new System.Drawing.Point(427, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(25, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "";
            this.toolTip1.SetToolTip(this.btnCancel, "انصراف");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnConfirm.Location = new System.Drawing.Point(396, 157);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(25, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "";
            this.toolTip1.SetToolTip(this.btnConfirm, "تائید");
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // DataBaseManagement
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(463, 181);
            this.ControlBox = false;
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTestConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataBaseManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات دیتابیس";
            this.Load += new System.EventHandler(this.DataBaseManagement_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDataBaseManegment;
        private System.Windows.Forms.ComboBox cmb;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.CheckBox chkEncryption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}