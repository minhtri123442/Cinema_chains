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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_EmailDangNhap
            // 
            this.txt_EmailDangNhap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_EmailDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EmailDangNhap.Location = new System.Drawing.Point(74, 120);
            this.txt_EmailDangNhap.Name = "txt_EmailDangNhap";
            this.txt_EmailDangNhap.Size = new System.Drawing.Size(322, 36);
            this.txt_EmailDangNhap.TabIndex = 1;
            this.txt_EmailDangNhap.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txt_EmailDangNhap.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txt_EmailDangNhap.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // txt_MKDangNhap
            // 
            this.txt_MKDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MKDangNhap.Location = new System.Drawing.Point(74, 176);
            this.txt_MKDangNhap.Name = "txt_MKDangNhap";
            this.txt_MKDangNhap.Size = new System.Drawing.Size(322, 36);
            this.txt_MKDangNhap.TabIndex = 1;
            this.txt_MKDangNhap.Enter += new System.EventHandler(this.textBox2_Enter);
            this.txt_MKDangNhap.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_DangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangNhap.Location = new System.Drawing.Point(147, 260);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(165, 50);
            this.btn_DangNhap.TabIndex = 3;
            this.btn_DangNhap.Text = "Xác nhận";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(71, 226);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(145, 16);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Bạn chưa có tài khoản?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Red;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Yellow;
            this.btnThoat.Location = new System.Drawing.Point(328, 328);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(133, 42);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // linklb_QuenMK
            // 
            this.linklb_QuenMK.AutoSize = true;
            this.linklb_QuenMK.Location = new System.Drawing.Point(293, 226);
            this.linklb_QuenMK.Name = "linklb_QuenMK";
            this.linklb_QuenMK.Size = new System.Drawing.Size(103, 16);
            this.linklb_QuenMK.TabIndex = 2;
            this.linklb_QuenMK.TabStop = true;
            this.linklb_QuenMK.Text = "Quên mật khẩu?";
            this.linklb_QuenMK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklb_QuenMK_LinkClicked);
            // 
            // Frm_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(473, 382);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.linklb_QuenMK);
            this.Controls.Add(this.txt_MKDangNhap);
            this.Controls.Add(this.txt_EmailDangNhap);
            this.Controls.Add(this.label1);
            this.Name = "Frm_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_DangNhap";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

