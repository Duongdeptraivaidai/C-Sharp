namespace bai02
{
    partial class Form2
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
            this.txt_Infor = new System.Windows.Forms.TextBox();
            this.chk_BoldStyle = new System.Windows.Forms.CheckBox();
            this.chk_ItalicStyle = new System.Windows.Forms.CheckBox();
            this.chk_UnderlineStyle = new System.Windows.Forms.CheckBox();
            this.btn_ChangeStyle = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập nội dung văn bản:";
            // 
            // txt_Infor
            // 
            this.txt_Infor.Location = new System.Drawing.Point(3, 16);
            this.txt_Infor.Multiline = true;
            this.txt_Infor.Name = "txt_Infor";
            this.txt_Infor.Size = new System.Drawing.Size(271, 154);
            this.txt_Infor.TabIndex = 1;
            // 
            // chk_BoldStyle
            // 
            this.chk_BoldStyle.AutoSize = true;
            this.chk_BoldStyle.Location = new System.Drawing.Point(280, 18);
            this.chk_BoldStyle.Name = "chk_BoldStyle";
            this.chk_BoldStyle.Size = new System.Drawing.Size(69, 17);
            this.chk_BoldStyle.TabIndex = 2;
            this.chk_BoldStyle.Text = "Chữ đậm";
            this.chk_BoldStyle.UseVisualStyleBackColor = true;
            this.chk_BoldStyle.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chk_ItalicStyle
            // 
            this.chk_ItalicStyle.AutoSize = true;
            this.chk_ItalicStyle.Location = new System.Drawing.Point(280, 41);
            this.chk_ItalicStyle.Name = "chk_ItalicStyle";
            this.chk_ItalicStyle.Size = new System.Drawing.Size(86, 17);
            this.chk_ItalicStyle.TabIndex = 3;
            this.chk_ItalicStyle.Text = "Chữ nghiêng";
            this.chk_ItalicStyle.UseVisualStyleBackColor = true;
            // 
            // chk_UnderlineStyle
            // 
            this.chk_UnderlineStyle.AutoSize = true;
            this.chk_UnderlineStyle.Location = new System.Drawing.Point(280, 64);
            this.chk_UnderlineStyle.Name = "chk_UnderlineStyle";
            this.chk_UnderlineStyle.Size = new System.Drawing.Size(79, 17);
            this.chk_UnderlineStyle.TabIndex = 4;
            this.chk_UnderlineStyle.Text = "Gạch chân";
            this.chk_UnderlineStyle.UseVisualStyleBackColor = true;
            // 
            // btn_ChangeStyle
            // 
            this.btn_ChangeStyle.Location = new System.Drawing.Point(285, 101);
            this.btn_ChangeStyle.Name = "btn_ChangeStyle";
            this.btn_ChangeStyle.Size = new System.Drawing.Size(88, 23);
            this.btn_ChangeStyle.TabIndex = 5;
            this.btn_ChangeStyle.Text = "Đặt kiểu chữ";
            this.btn_ChangeStyle.UseVisualStyleBackColor = true;
            this.btn_ChangeStyle.Click += new System.EventHandler(this.btn_ChangeStyle_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(285, 130);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(88, 23);
            this.btn_Reset.TabIndex = 6;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 182);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_ChangeStyle);
            this.Controls.Add(this.chk_UnderlineStyle);
            this.Controls.Add(this.chk_ItalicStyle);
            this.Controls.Add(this.chk_BoldStyle);
            this.Controls.Add(this.txt_Infor);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Infor;
        private System.Windows.Forms.CheckBox chk_BoldStyle;
        private System.Windows.Forms.CheckBox chk_ItalicStyle;
        private System.Windows.Forms.CheckBox chk_UnderlineStyle;
        private System.Windows.Forms.Button btn_ChangeStyle;
        private System.Windows.Forms.Button btn_Reset;
    }
}

