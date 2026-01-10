using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    public class Student : Person
    {
        private string _mssv = "", _email = "";
        private double _dtb = 0;

        public Student(string mssv, string email, double dtb)
        {
            _mssv = mssv;
            _email = email;
            _dtb = dtb;
        }

        public Student() { }

        ~Student() { }

        public string mssv { get { return _mssv; } set { _mssv = value; } }
        public string email { get { return _email; } set { _email = value; } }
        public double dtb { get { return _dtb; } set { _dtb = value; } }

        public override void nhap()
        {
            base.nhap();
            Console.Write("Nhap mssv: ");
            this.mssv = Console.ReadLine();
            Console.Write("Nhap email: ");
            this.email = Console.ReadLine();
            Console.Write("Nhap diem trung binh: ");
            this.dtb = double.Parse(Console.ReadLine());
        }

        public override void xuat()
        {
            base.xuat();
            Console.WriteLine($"mssv: {_mssv}");
            Console.WriteLine($"email: {_email}");
            Console.WriteLine($"diem trung binh: {_dtb}");
        }

        public bool xetHocBong()
        {
            return this.dtb >= 8;
        }


    }
}
