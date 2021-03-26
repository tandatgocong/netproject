namespace BanHangThep
{
    partial class frm_Login
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lbFail = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtuserName = new System.Windows.Forms.TextBox();
            this.bt_huy = new DevComponents.DotNetBar.ButtonX();
            this.bt_Login = new DevComponents.DotNetBar.ButtonX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lb2 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(17, 143);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(104, 30);
            this.labelX2.TabIndex = 18;
            this.labelX2.Text = "Password";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(17, 104);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(117, 23);
            this.labelX1.TabIndex = 17;
            this.labelX1.Text = "UserName";
            // 
            // lbFail
            // 
            this.lbFail.AutoSize = true;
            this.lbFail.BackColor = System.Drawing.Color.Transparent;
            this.lbFail.ForeColor = System.Drawing.Color.Red;
            this.lbFail.Location = new System.Drawing.Point(51, 235);
            this.lbFail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFail.Name = "lbFail";
            this.lbFail.Size = new System.Drawing.Size(306, 25);
            this.lbFail.TabIndex = 16;
            this.lbFail.Text = "(*)  Wrong username or password";
            this.lbFail.Visible = false;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(141, 143);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(239, 30);
            this.txtPass.TabIndex = 15;
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // txtuserName
            // 
            this.txtuserName.Location = new System.Drawing.Point(141, 104);
            this.txtuserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtuserName.Name = "txtuserName";
            this.txtuserName.Size = new System.Drawing.Size(239, 30);
            this.txtuserName.TabIndex = 14;
            this.txtuserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtuserName_KeyPress);
            // 
            // bt_huy
            // 
            this.bt_huy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_huy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_huy.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_huy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(22)))), ((int)(((byte)(111)))));
            this.bt_huy.Location = new System.Drawing.Point(266, 181);
            this.bt_huy.Margin = new System.Windows.Forms.Padding(4);
            this.bt_huy.Name = "bt_huy";
            this.bt_huy.Size = new System.Drawing.Size(91, 33);
            this.bt_huy.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.bt_huy.TabIndex = 13;
            this.bt_huy.Text = "Cancel";
            this.bt_huy.Click += new System.EventHandler(this.bt_huy_Click);
            // 
            // bt_Login
            // 
            this.bt_Login.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_Login.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_Login.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(22)))), ((int)(((byte)(111)))));
            this.bt_Login.Location = new System.Drawing.Point(141, 181);
            this.bt_Login.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Login.Name = "bt_Login";
            this.bt_Login.Size = new System.Drawing.Size(91, 33);
            this.bt_Login.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.bt_Login.TabIndex = 12;
            this.bt_Login.Text = "Log In";
            this.bt_Login.Click += new System.EventHandler(this.bt_Login_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lb2
            // 
            this.lb2.BackColor = System.Drawing.Color.Transparent;
            this.lb2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb2.Location = new System.Drawing.Point(111, 33);
            this.lb2.Margin = new System.Windows.Forms.Padding(4);
            this.lb2.Name = "lb2";
            this.lb2.ReflectionEnabled = false;
            this.lb2.Size = new System.Drawing.Size(234, 42);
            this.lb2.TabIndex = 32;
            this.lb2.Text = "<b><font size=\"+6\"><font color=\"#B02B2C\">ĐĂNG NHẬP </font></font></b>";
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::BanHangThep.Properties.Resources.A093;
            this.ClientSize = new System.Drawing.Size(455, 273);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.lbFail);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtuserName);
            this.Controls.Add(this.bt_huy);
            this.Controls.Add(this.bt_Login);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NHẬP";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Label lbFail;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtuserName;
        private DevComponents.DotNetBar.ButtonX bt_huy;
        private DevComponents.DotNetBar.ButtonX bt_Login;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel lb2;
    }
}