namespace PhanSo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhanSo ps1 = new PhanSo();
            PhanSo ps2 = new PhanSo();

            Console.WriteLine("Nhap phan so thu nhat:");
            ps1.nhap();
            Console.WriteLine("Nhap phan so thu hai:");
            ps2.nhap();
            PhanSo tong = ps1.tong(ps2);
            Console.Write("Tong hai phan so la: ");
            tong.xuat();

            PhanSo hieu = ps1.hieu(ps2);
            Console.Write("Hieu hai phan so la: ");
            hieu.xuat();

            PhanSo tich = ps1.tich(ps2);
            Console.Write("Tich hai phan so la: ");
            tich.xuat();

            PhanSo thuong = ps1.thuong(ps2);
            Console.Write("Thuong hai phan so la: ");
            thuong.xuat();




        }
    }
}
