namespace Cinema_Chains
{
    partial class Frm_DangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_EmailDangNhap = new System.Windows.Forms.TextBox();
            this.txt_MKDangNhap = new System.Windows.Forms.TextBox();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.linklb_QuenMK = new System.Windows.Forms.LinkLabel();
            this.lbLoiEmail = new System.Windows.Forms.Label();
            this.lbLoiMK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(480, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập";
            // 
            // txt_EmailDangNhap
            // 
            this.txt_EmailDangNhap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_EmailDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EmailDangNhap.Location = new System.Drawing.Point(404, 80);
            this.txt_EmailDangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_EmailDangNhap.Name = "txt_EmailDangNhap";
            this.txt_EmailDangNhap.Size = new System.Drawing.Size(321, 36);
            this.txt_EmailDangNhap.TabIndex = 1;
            this.txt_EmailDangNhap.TextChanged += new System.EventHandler(this.txt_EmailDangNhap_TextChanged);
            this.txt_EmailDangNhap.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txt_EmailDangNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_EmailDangNhap_KeyPress);
            this.txt_EmailDangNhap.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // txt_MKDangNhap
            // 
            this.txt_MKDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MKDangNhap.Location = new System.Drawing.Point(404, 150);
            this.txt_MKDangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_MKDangNhap.Name = "txt_MKDangNhap";
            this.txt_MKDangNhap.Size = new System.Drawing.Size(321, 36);
            this.txt_MKDangNhap.TabIndex = 1;
            this.txt_MKDangNhap.TextChanged += new System.EventHandler(this.txt_MKDangNhap_TextChanged);
            this.txt_MKDangNhap.Enter += new System.EventHandler(this.textBox2_Enter);
            this.txt_MKDangNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MKDangNhap_KeyPress);
            this.txt_MKDangNhap.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_DangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangNhap.Location = new System.Drawing.Point(488, 247);
            this.btn_DangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(157, 50);
            this.btn_DangNhap.TabIndex = 3;
            this.btn_DangNhap.Text = "Xác nhận";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.White;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.White;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkLabel1.Location = new System.Drawing.Point(401, 216);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(145, 16);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Bạn chưa có tài khoản?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.Location = new System.Drawing.Point(616, 326);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(133, 42);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // linklb_QuenMK
            // 
            this.linklb_QuenMK.AutoSize = true;
            this.linklb_QuenMK.BackColor = System.Drawing.Color.White;
            this.linklb_QuenMK.DisabledLinkColor = System.Drawing.Color.White;
            this.linklb_QuenMK.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linklb_QuenMK.Location = new System.Drawing.Point(613, 216);
            this.linklb_QuenMK.Name = "linklb_QuenMK";
            this.linklb_QuenMK.Size = new System.Drawing.Size(103, 16);
            this.linklb_QuenMK.TabIndex = 2;
            this.linklb_QuenMK.TabStop = true;
            this.linklb_QuenMK.Text = "Quên mật khẩu?";
            this.linklb_QuenMK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklb_QuenMK_LinkClicked);
            // 
            // lbLoiEmail
            // 
            this.lbLoiEmail.AutoSize = true;
            this.lbLoiEmail.BackColor = System.Drawing.Color.Transparent;
            this.lbLoiEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoiEmail.ForeColor = System.Drawing.Color.Red;
            this.lbLoiEmail.Location = new System.Drawing.Point(401, 118);
            this.lbLoiEmail.Name = "lbLoiEmail";
            this.lbLoiEmail.Size = new System.Drawing.Size(46, 18);
            this.lbLoiEmail.TabIndex = 6;
            this.lbLoiEmail.Text = "label2";
            // 
            // lbLoiMK
            // 
            this.lbLoiMK.AutoSize = true;
            this.lbLoiMK.BackColor = System.Drawing.Color.Transparent;
            this.lbLoiMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoiMK.ForeColor = System.Drawing.Color.Red;
            this.lbLoiMK.Location = new System.Drawing.Point(401, 192);
            this.lbLoiMK.Name = "lbLoiMK";
            this.lbLoiMK.Size = new System.Drawing.Size(46, 18);
            this.lbLoiMK.TabIndex = 6;
            this.lbLoiMK.Text = "label2";
            // 
            // Frm_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::Cinema_Chains.Properties.Resources.Best_Website_Background_Images14;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(760, 382);
            this.Controls.Add(this.lbLoiMK);
            this.Controls.Add(this.lbLoiEmail);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.linklb_QuenMK);
            this.Controls.Add(this.txt_MKDangNhap);
            this.Controls.Add(this.txt_EmailDangNhap);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_DangNhap";
            this.Load += new System.EventHandler(this.Frm_DangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_EmailDangNhap;
        private System.Windows.Forms.TextBox txt_MKDangNhap;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.LinkLabel linklb_QuenMK;
        private System.Windows.Forms.Label lbLoiEmail;
        private System.Windows.Forms.Label lbLoiMK;
    }
}

