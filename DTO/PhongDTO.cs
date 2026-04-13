using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Phong_DTO
    {
        private int iMaPhong;
        public int IMaPhong { get => iMaPhong; set => iMaPhong = value; }

        private string sTenPhong;
        public string STenPhong { get => sTenPhong; set => sTenPhong = value; }

        private int iMaLoai;
        public int IMaLoai { get => iMaLoai; set => iMaLoai = value; }

        private string sTrangThai;
        public string STrangThai { get => sTrangThai; set => sTrangThai = value; }

        private decimal dTongTien;
        public decimal DTongTien { get => dTongTien; set => dTongTien = value; }


        private string sTenLoai;
        public string STenLoai { get => sTenLoai; set => sTenLoai = value; }

        private decimal dGiaNgay;
        public decimal DGiaNgay { get => dGiaNgay; set => dGiaNgay = value; }

        private decimal dGiaGio;
        public decimal DGiaGio { get => dGiaGio; set => dGiaGio = value; }

        private int iSoNgay;
        public int ISoNgay { get => iSoNgay; set => iSoNgay = value; }

        private int iSoGio;
        public int ISoGio { get => iSoGio; set => iSoGio = value; }
    }
}
