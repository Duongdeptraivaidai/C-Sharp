using System;
using System.Collections.Generic;
using System.Linq;

namespace QLSV
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> dsSV = new List<Student>();
            List<Teacher> dsGV = new List<Teacher>();
            int chon;

            do
            {
                Console.WriteLine("\n--- MENU QUAN LY ---");
                Console.WriteLine("1. Quan ly Sinh Vien (Menu 7 chuc nang)");
                Console.WriteLine("2. Quan ly Giang Vien (Menu 4 chuc nang)");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon: ");
                chon = int.Parse(Console.ReadLine() ?? "0");

                if (chon == 1) MenuStudent(dsSV);
                else if (chon == 2) MenuTeacher(dsGV);

            } while (chon != 0);
        }

        static void MenuTeacher(List<Teacher> list)
        {
            int c;
            do
            {
                Console.WriteLine("\n-- QUAN LY GIANG VIEN --");
                Console.WriteLine("1. Nhap n giang vien\n2. Hien thi tat ca\n3. Luong cao nhat\n4. Quay lai");
                c = int.Parse(Console.ReadLine() ?? "0");
                switch (c)
                {
                    case 1:
                        Console.Write("Nhap n: "); int n = int.Parse(Console.ReadLine() ?? "0");
                        for (int i = 0; i < n; i++) { Teacher t = new Teacher(); t.nhap(); list.Add(t); }
                        break;
                    case 2:
                        list.ForEach(t => t.xuat());
                        break;
                    case 3:
                        if (list.Count > 0)
                        {
                            var max = list.Max(t => t.tinhLuong());
                            list.Where(t => t.tinhLuong() == max).ToList().ForEach(t => t.xuat());
                        }
                        break;
                }
            } while (c != 4);
        }

        static void MenuStudent(List<Student> list)
        {
            int c;
            do
            {
                Console.WriteLine("\n-- QUAN LY SINH VIEN --");
                Console.WriteLine("1. Nhap n sinh vien\n2. Hien thi tat ca\n3. Diem trung binh cao nhat\n4. Quay lai");
                c = int.Parse(Console.ReadLine() ?? "0");
                switch (c)
                {
                    case 1:
                        Console.Write("Nhap n: "); int n = int.Parse(Console.ReadLine() ?? "0");
                        for (int i = 0; i < n; i++) { Student s = new Student(); s.nhap(); list.Add(s); }
                        break;
                    case 2:
                        list.ForEach(s => s.xuat());
                        break;
                    case 3:
                        if (list.Count > 0)
                        {
                            var max = list.Max(s => s.dtb);
                            list.Where(s => s.dtb == max).ToList().ForEach(s => s.xuat());
                        }
                        break;
                }
            } while (c != 4);
        }
    }
}
