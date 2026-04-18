using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DichVu_DTO
    {
        private int iMaDV;
        public int IMaDV { get => iMaDV; set => iMaDV = value; }

        private string sTenDV;
        public string STenDV { get => sTenDV; set => sTenDV = value; }

        private decimal dGiaDV;
        public decimal DGiaDV { get => dGiaDV; set => dGiaDV = value; }

        private string sDonViTinh;
        public string SDonViTinh { get => sDonViTinh; set => sDonViTinh = value; }

        private int iMaPhong;
        public int IMaPhong { get => iMaPhong; set => iMaPhong = value; }

        private string sTenPhong;
        public string STenPhong { get => sTenPhong; set => sTenPhong = value; }
    }
}
