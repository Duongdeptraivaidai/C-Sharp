using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void btnOK_OneClick(object sender, EventArgs e)
        {
            if (txtName == null) MessageBox.Show("Vui lòng nhập tên.");
            else MessageBox.Show($"Xin chào {txtName.Text}");
        }


    }
}
