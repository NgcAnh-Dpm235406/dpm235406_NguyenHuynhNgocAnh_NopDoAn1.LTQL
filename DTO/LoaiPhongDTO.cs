using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiPhong_DTO
    {
        private int iMaLoai;
        public int IMaLoai { get => iMaLoai; set => iMaLoai = value; }

        private string sTenLoai;
        public string STenLoai { get => sTenLoai; set => sTenLoai = value; }

        private decimal dGiaNgay;
        public decimal DGiaNgay { get => dGiaNgay; set => dGiaNgay = value; }

        private decimal dGiaGio;
        public decimal DGiaGio { get => dGiaGio; set => dGiaGio = value; }

       
    }
}
