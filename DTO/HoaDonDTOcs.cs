using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon_DTO
    {
        private int iMaHD;
        public int IMaHD { get => iMaHD; set => iMaHD = value; }

        private int iMaPhieu;
        public int IMaPhieu { get => iMaPhieu; set => iMaPhieu = value; }

        private string sHoTen;
        public string SHoTen { get => sHoTen; set => sHoTen = value; }

        private string sTenPhong;
        public string STenPhong { get => sTenPhong; set => sTenPhong = value; }

        private DateTime dtNgayThanhToan;
        public DateTime DtNgayThanhToan { get => dtNgayThanhToan; set => dtNgayThanhToan = value; }

        private decimal dTongTienPhong;
        public decimal DTongTienPhong { get => dTongTienPhong; set => dTongTienPhong = value; }

        private decimal dTongTienDV;
        public decimal DTongTienDV { get => dTongTienDV; set => dTongTienDV = value; }

        private decimal dTongTienThanhToan;
        public decimal DTongTienThanhToan { get => dTongTienThanhToan; set => dTongTienThanhToan = value; }
    }
}
