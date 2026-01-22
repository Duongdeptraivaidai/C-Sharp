using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanSo
{
    internal class PhanSo
    {   
        private int _mauSo;
        private int _tuSo;
        public PhanSo(int ts, int ms)
        {
            _tuSo = ts;
            _mauSo = ms;
        }

        public PhanSo()
        {
            _tuSo = 0;
            _mauSo = 1;
        }


        public void nhap()
        {
    
            Console.Write ("Nhap vao tu so: ");
            _tuSo = int.Parse(Console.ReadLine());
            do
            {
                Console.Write ("Nhap vao mau so: ");
                _mauSo = int.Parse(Console.ReadLine());
            } while (_mauSo == 0);
        }
        public void xuat()
        {
            Console.WriteLine($"    {_tuSo}/{_mauSo}");
        }

        private int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        public void RutGon()
        {
            int ucln = UCLN(_tuSo, _mauSo);
            _tuSo /= ucln;
            _mauSo /= ucln;
        }

        public PhanSo tong(PhanSo ps)
        {
            PhanSo kq = new PhanSo();
            kq._tuSo = _tuSo * ps._mauSo + ps._tuSo * _mauSo;
            kq._mauSo = _mauSo * ps._mauSo;
            kq.RutGon();
            return kq;
        }

        public PhanSo hieu(PhanSo ps) {
            PhanSo kq = new PhanSo();
            kq._tuSo = _tuSo * ps._mauSo - ps._tuSo * _mauSo;
            kq._mauSo = _mauSo * ps._mauSo;
            kq.RutGon();
            return kq;
        }

        public PhanSo tich(PhanSo ps) {
            PhanSo kq = new PhanSo();
            kq._tuSo = _tuSo* ps._tuSo;
            kq._mauSo=_mauSo * ps._mauSo;
            kq.RutGon();
            return kq;
        }

        public PhanSo thuong(PhanSo ps)
        {
            PhanSo kq = new PhanSo();
            kq._tuSo = _tuSo*ps._mauSo;
            kq._mauSo=_mauSo *ps._tuSo;
            kq.RutGon();
            return kq;
        }

    }

   }
