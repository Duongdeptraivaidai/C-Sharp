namespace bai01
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkMovie = new System.Windows.Forms.CheckBox();
            this.chkMusic = new System.Windows.Forms.CheckBox();
            this.chkReadBook = new System.Windows.Forms.CheckBox();
            this.chkFootball = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ Tên: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sở thích:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(144, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // chkMovie
            // 
            this.chkMovie.AutoSize = true;
            this.chkMovie.Location = new System.Drawing.Point(69, 104);
            this.chkMovie.Name = "chkMovie";
            this.chkMovie.Size = new System.Drawing.Size(70, 17);
            this.chkMovie.TabIndex = 3;
            this.chkMovie.Text = "xem phim";
            this.chkMovie.UseVisualStyleBackColor = true;
            // 
            // chkMusic
            // 
            this.chkMusic.AutoSize = true;
            this.chkMusic.Location = new System.Drawing.Point(69, 127);
            this.chkMusic.Name = "chkMusic";
            this.chkMusic.Size = new System.Drawing.Size(77, 17);
            this.chkMusic.TabIndex = 4;
            this.chkMusic.Text = "nghe nhạc";
            this.chkMusic.UseVisualStyleBackColor = true;
            // 
            // chkReadBook
            // 
            this.chkReadBook.AutoSize = true;
            this.chkReadBook.Location = new System.Drawing.Point(69, 154);
            this.chkReadBook.Name = "chkReadBook";
            this.chkReadBook.Size = new System.Drawing.Size(72, 17);
            this.chkReadBook.TabIndex = 5;
            this.chkReadBook.Text = "Đọc sách";
            this.chkReadBook.UseVisualStyleBackColor = true;
            // 
            // chkFootball
            // 
            this.chkFootball.AutoSize = true;
            this.chkFootball.Location = new System.Drawing.Point(69, 177);
            this.chkFootball.Name = "chkFootball";
            this.chkFootball.Size = new System.Drawing.Size(67, 17);
            this.chkFootball.TabIndex = 6;
            this.chkFootball.Text = "Đá bóng";
            this.chkFootball.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(61, 211);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(169, 211);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 8;
            this.btnShow.Text = "Hiển thị";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 266);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.chkFootball);
            this.Controls.Add(this.chkReadBook);
            this.Controls.Add(this.chkMusic);
            this.Controls.Add(this.chkMovie);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkMovie;
        private System.Windows.Forms.CheckBox chkMusic;
        private System.Windows.Forms.CheckBox chkReadBook;
        private System.Windows.Forms.CheckBox chkFootball;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnShow;
    }
}

