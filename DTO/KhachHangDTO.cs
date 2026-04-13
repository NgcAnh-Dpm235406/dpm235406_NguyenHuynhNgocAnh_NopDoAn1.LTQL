using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang_DTO
    {
        private int iMaKH;
        public int IMaKH
        {
            get { return iMaKH; }
            set { iMaKH = value; }
        }

        private string sHoTen;
        public string SHoTen
        {
            get { return sHoTen; }
            set { sHoTen = value; }
        }

        private string sCCCD;
        public string SCCCD
        {
            get { return sCCCD; }
            set { sCCCD = value; }
        }

        private string sSDT;
        public string SSDT
        {
            get { return sSDT; }
            set { sSDT = value; }
        }

        private string sDiaChi;
        public string SDiaChi
        {
            get { return sDiaChi; }
            set { sDiaChi = value; }
        }

        private string sQuocTich;
        public string SQuocTich
        {
            get { return sQuocTich; }
            set { sQuocTich = value; }
        }
    }
}
