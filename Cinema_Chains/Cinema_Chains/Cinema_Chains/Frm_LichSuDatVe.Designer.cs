namespace Cinema_Chains
{
    partial class Frm_LichSuDatVe
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
            this.dgvLichSuDatVe = new System.Windows.Forms.DataGridView();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDatVe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(415, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lịch sử đặt vé";
            // 
            // dgvLichSuDatVe
            // 
            this.dgvLichSuDatVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuDatVe.Location = new System.Drawing.Point(49, 135);
            this.dgvLichSuDatVe.Name = "dgvLichSuDatVe";
            this.dgvLichSuDatVe.RowHeadersWidth = 51;
            this.dgvLichSuDatVe.RowTemplate.Height = 24;
            this.dgvLichSuDatVe.Size = new System.Drawing.Size(1042, 384);
            this.dgvLichSuDatVe.TabIndex = 1;
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Location = new System.Drawing.Point(896, 525);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(195, 51);
            this.btnXemChiTiet.TabIndex = 2;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = true;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // Frm_LichSuDatVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1158, 601);
            this.Controls.Add(this.btnXemChiTiet);
            this.Controls.Add(this.dgvLichSuDatVe);
            this.Controls.Add(this.label1);
            this.Name = "Frm_LichSuDatVe";
            this.Text = "Frm_LichSuDatVe";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDatVe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLichSuDatVe;
        private System.Windows.Forms.Button btnXemChiTiet;
    }
}