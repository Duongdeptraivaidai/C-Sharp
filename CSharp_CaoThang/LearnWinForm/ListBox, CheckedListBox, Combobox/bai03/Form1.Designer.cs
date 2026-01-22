namespace Bai03
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
            this.lst_DayofWeek = new System.Windows.Forms.ListBox();
            this.btn_Click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lst_DayofWeek
            // 
            this.lst_DayofWeek.FormattingEnabled = true;
            this.lst_DayofWeek.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.lst_DayofWeek.Location = new System.Drawing.Point(260, 116);
            this.lst_DayofWeek.Name = "lst_DayofWeek";
            this.lst_DayofWeek.Size = new System.Drawing.Size(135, 134);
            this.lst_DayofWeek.TabIndex = 0;
            // 
            // btn_Click
            // 
            this.btn_Click.Location = new System.Drawing.Point(260, 273);
            this.btn_Click.Name = "btn_Click";
            this.btn_Click.Size = new System.Drawing.Size(75, 23);
            this.btn_Click.TabIndex = 1;
            this.btn_Click.Text = "Click me";
            this.btn_Click.UseVisualStyleBackColor = true;
            this.btn_Click.Click += new System.EventHandler(this.btn_Click_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Click);
            this.Controls.Add(this.lst_DayofWeek);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_DayofWeek;
        private System.Windows.Forms.Button btn_Click;
    }
}

