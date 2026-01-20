using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    public class Teacher : Person
    {
        private string _lopDay = "";
        private double _luongMotTiet = 0;
        private int _soTietDay = 0;

        public Teacher(string lopDay, double luongMotTiet, int soTietDay)
        {
            _lopDay = lopDay;
            _luongMotTiet = luongMotTiet;
            _soTietDay = soTietDay;
        }

        public Teacher() { }

        ~Teacher() { }

        public string LopDay { get { return _lopDay; } set { _lopDay = value; } }
        public double LuongMotTiet { get { return _luongMotTiet; } set { _luongMotTiet = value; } }
        public int SoTietDay { get { return _soTietDay; } set { _soTietDay = value; } }

        public override void nhap()
        {
            base.nhap();
            Console.Write("Nhap Lop day: "); LopDay = Console.ReadLine() ?? "";
            Console.Write("Nhap Luong 1 tiet: "); LuongMotTiet = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap So tiet day: "); SoTietDay = int.Parse(Console.ReadLine() ?? "0");
        }

        public override void xuat()
        {
            base.xuat();
            Console.WriteLine($"| Lop: {LopDay} | Luong: {tinhLuong()}");
        }

        public double tinhLuong() => _luongMotTiet * _soTietDay;
    }
}