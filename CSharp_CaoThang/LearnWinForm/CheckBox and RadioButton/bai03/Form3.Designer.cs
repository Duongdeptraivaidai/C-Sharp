namespace bai3
{
    partial class Form3
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
            this.rbtn_Plus = new System.Windows.Forms.RadioButton();
            this.rbnt_Minus = new System.Windows.Forms.RadioButton();
            this.rbtn_Mutiply = new System.Windows.Forms.RadioButton();
            this.rbtn_Devide = new System.Windows.Forms.RadioButton();
            this.btn_Result = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số thứ nhất:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số thứ hai: ";
            // 
            // rbtn_Plus
            // 
            this.rbtn_Plus.AutoSize = true;
            this.rbtn_Plus.Location = new System.Drawing.Point(46, 112);
            this.rbtn_Plus.Name = "rbtn_Plus";
            this.rbtn_Plus.Size = new System.Drawing.Size(50, 17);
            this.rbtn_Plus.TabIndex = 2;
            this.rbtn_Plus.TabStop = true;
            this.rbtn_Plus.Text = "Cộng";
            this.rbtn_Plus.UseVisualStyleBackColor = true;
            // 
            // rbnt_Minus
            // 
            this.rbnt_Minus.AutoSize = true;
            this.rbnt_Minus.Location = new System.Drawing.Point(109, 112);
            this.rbnt_Minus.Name = "rbnt_Minus";
            this.rbnt_Minus.Size = new System.Drawing.Size(41, 17);
            this.rbnt_Minus.TabIndex = 3;
            this.rbnt_Minus.TabStop = true;
            this.rbnt_Minus.Text = "Trừ";
            this.rbnt_Minus.UseVisualStyleBackColor = true;
            // 
            // rbtn_Mutiply
            // 
            this.rbtn_Mutiply.AutoSize = true;
            this.rbtn_Mutiply.Location = new System.Drawing.Point(156, 112);
            this.rbtn_Mutiply.Name = "rbtn_Mutiply";
            this.rbtn_Mutiply.Size = new System.Drawing.Size(51, 17);
            this.rbtn_Mutiply.TabIndex = 4;
            this.rbtn_Mutiply.TabStop = true;
            this.rbtn_Mutiply.Text = "Nhân";
            this.rbtn_Mutiply.UseVisualStyleBackColor = true;
            // 
            // rbtn_Devide
            // 
            this.rbtn_Devide.AutoSize = true;
            this.rbtn_Devide.Location = new System.Drawing.Point(213, 112);
            this.rbtn_Devide.Name = "rbtn_Devide";
            this.rbtn_Devide.Size = new System.Drawing.Size(46, 17);
            this.rbtn_Devide.TabIndex = 5;
            this.rbtn_Devide.TabStop = true;
            this.rbtn_Devide.Text = "Chia";
            this.rbtn_Devide.UseVisualStyleBackColor = true;
            // 
            // btn_Result
            // 
            this.btn_Result.Location = new System.Drawing.Point(46, 156);
            this.btn_Result.Name = "btn_Result";
            this.btn_Result.Size = new System.Drawing.Size(75, 23);
            this.btn_Result.TabIndex = 6;
            this.btn_Result.Text = "Tính toán";
            this.btn_Result.UseVisualStyleBackColor = true;
            this.btn_Result.Click += new System.EventHandler(this.btn_Result_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(142, 156);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset.TabIndex = 7;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(117, 12);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 20);
            this.txtA.TabIndex = 8;
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtA_KeyPress);
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(117, 47);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 20);
            this.txtB.TabIndex = 9;
            this.txtB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtB_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Kết quả:";
            // 
            // txt_Result
            // 
            this.txt_Result.Location = new System.Drawing.Point(117, 84);
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.Size = new System.Drawing.Size(100, 20);
            this.txt_Result.TabIndex = 11;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 202);
            this.Controls.Add(this.txt_Result);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_Result);
            this.Controls.Add(this.rbtn_Devide);
            this.Controls.Add(this.rbtn_Mutiply);
            this.Controls.Add(this.rbnt_Minus);
            this.Controls.Add(this.rbtn_Plus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtn_Plus;
        private System.Windows.Forms.RadioButton rbnt_Minus;
        private System.Windows.Forms.RadioButton rbtn_Mutiply;
        private System.Windows.Forms.RadioButton rbtn_Devide;
        private System.Windows.Forms.Button btn_Result;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Result;
    }
}

