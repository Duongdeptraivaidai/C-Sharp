using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Please pick your picture!";
                openFileDialog.Filter= "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //get path Project foldr (file.exe in folder).
                        string getPath = Application.StartupPath;
                        //create "Images" folder if it not exitsts yet.
                        string createFolderPath = Path.Combine(getPath, "Images");
                        if (!Directory.Exists(createFolderPath))
                        {
                            Directory.CreateDirectory(createFolderPath);
                        }
                        //Prepare the destination path for copying.
                        string fileName = Path.GetFileName(openFileDialog.FileName);
                        string desPath = Path.Combine(createFolderPath, fileName);

                        //Copy the file to the  Images folder (true to overwrite if the name same) 
                        File.Copy(openFileDialog.FileName, desPath,true);

                        //Show the picture from new path
                        pictureBox2.Image = new Bitmap(desPath);
                        pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                        MessageBox.Show("Image saved to folder!" + createFolderPath);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("An Error occurred!: " + ex.Message);
                    }
                }
            }
              
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }
        
    }
}

//1. Lay thong tin thu muc Project(duong dan)
//2. Tao thu muc images trong duong dan project
//3. Copy files hinh anh tai len vao thu muc images
