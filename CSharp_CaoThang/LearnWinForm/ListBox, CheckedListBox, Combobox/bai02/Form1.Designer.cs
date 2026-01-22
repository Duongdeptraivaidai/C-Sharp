namespace ba02
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.cboPhongBan = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lstNghienCuu = new System.Windows.Forms.ListBox();
            this.lstQuanLy = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnToRight = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.btnToLeftAll = new System.Windows.Forms.Button();
            this.btnToRightAll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ho ten:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chuc vu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phong ban:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(212, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 20);
            this.txtName.TabIndex = 3;
            // 
            // cboChucVu
            // 
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Items.AddRange(new object[] {
            "Truong phong",
            "Nhan vien"});
            this.cboChucVu.Location = new System.Drawing.Point(212, 62);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(121, 21);
            this.cboChucVu.TabIndex = 4;
            // 
            // cboPhongBan
            // 
            this.cboPhongBan.FormattingEnabled = true;
            this.cboPhongBan.Items.AddRange(new object[] {
            "Nghien Cuu",
            "Quan Ly"});
            this.cboPhongBan.Location = new System.Drawing.Point(212, 105);
            this.cboPhongBan.Name = "cboPhongBan";
            this.cboPhongBan.Size = new System.Drawing.Size(121, 21);
            this.cboPhongBan.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(405, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Them";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(405, 81);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Thoat";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lstNghienCuu
            // 
            this.lstNghienCuu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstNghienCuu.FormattingEnabled = true;
            this.lstNghienCuu.Location = new System.Drawing.Point(12, 166);
            this.lstNghienCuu.Name = "lstNghienCuu";
            this.lstNghienCuu.Size = new System.Drawing.Size(194, 147);
            this.lstNghienCuu.TabIndex = 8;
            this.lstNghienCuu.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstNghienCuu_DrawItem);
            // 
            // lstQuanLy
            // 
            this.lstQuanLy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstQuanLy.FormattingEnabled = true;
            this.lstQuanLy.Location = new System.Drawing.Point(339, 168);
            this.lstQuanLy.Name = "lstQuanLy";
            this.lstQuanLy.Size = new System.Drawing.Size(203, 147);
            this.lstQuanLy.TabIndex = 9;
            this.lstQuanLy.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstQuanLy_DrawItem);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Phong quan ly";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Phong nghien cuu";
            // 
            // btnToRight
            // 
            this.btnToRight.Location = new System.Drawing.Point(212, 172);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(56, 23);
            this.btnToRight.TabIndex = 13;
            this.btnToRight.Text = ">";
            this.btnToRight.UseVisualStyleBackColor = true;
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Location = new System.Drawing.Point(279, 172);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(54, 23);
            this.btnToLeft.TabIndex = 14;
            this.btnToLeft.Text = "<";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // btnToLeftAll
            // 
            this.btnToLeftAll.Location = new System.Drawing.Point(279, 212);
            this.btnToLeftAll.Name = "btnToLeftAll";
            this.btnToLeftAll.Size = new System.Drawing.Size(54, 23);
            this.btnToLeftAll.TabIndex = 15;
            this.btnToLeftAll.Text = "<<";
            this.btnToLeftAll.UseVisualStyleBackColor = true;
            this.btnToLeftAll.Click += new System.EventHandler(this.btnToLeftAll_Click);
            // 
            // btnToRightAll
            // 
            this.btnToRightAll.Location = new System.Drawing.Point(212, 212);
            this.btnToRightAll.Name = "btnToRightAll";
            this.btnToRightAll.Size = new System.Drawing.Size(56, 23);
            this.btnToRightAll.TabIndex = 16;
            this.btnToRightAll.Text = ">>";
            this.btnToRightAll.UseVisualStyleBackColor = true;
            this.btnToRightAll.Click += new System.EventHandler(this.btnToRightAll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(240, 266);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Xoa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 319);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnToRightAll);
            this.Controls.Add(this.btnToLeftAll);
            this.Controls.Add(this.btnToLeft);
            this.Controls.Add(this.btnToRight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstQuanLy);
            this.Controls.Add(this.lstNghienCuu);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboPhongBan);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.ComboBox cboPhongBan;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lstNghienCuu;
        private System.Windows.Forms.ListBox lstQuanLy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnToRight;
        private System.Windows.Forms.Button btnToLeft;
        private System.Windows.Forms.Button btnToLeftAll;
        private System.Windows.Forms.Button btnToRightAll;
        private System.Windows.Forms.Button btnDelete;
    }
}

