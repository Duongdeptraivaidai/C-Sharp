using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    public class Person
    {
        private string _ten = "", _phai = "", _ngaySinh = "", _diaChi = "";

        public string ten { get => _ten; set => _ten = value; }
        public string phai { get => _phai; set => _phai = value; }
        public string ngaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string diaChi { get => _diaChi; set => _diaChi = value; }

        public Person() { }

        public Person(string ten, string phai, string ngaySinh, string diaChi)
        {
            _ten = ten;
            _phai = phai;
            _ngaySinh = ngaySinh;
            _diaChi = diaChi;
        }

        ~Person() { }

        public virtual void nhap()
        {
            Console.Write("Nhap ten: ");
            this.ten = Console.ReadLine();
            Console.Write("Nhap phai: ");
            this.phai = Console.ReadLine();
            Console.Write("Nhap ngay sinh: ");
            this.ngaySinh = Console.ReadLine();
            Console.Write("Nhap dia chi: ");
            this.diaChi = Console.ReadLine();
        }

        public virtual void xuat()
        {
            Console.WriteLine($"Ten: {_ten}");
            Console.WriteLine($"Phai: {_phai}");
            Console.WriteLine($"Ngay sinh: {_ngaySinh}");
            Console.WriteLine($"Dia chi: {_diaChi}");
        }
    }
}
