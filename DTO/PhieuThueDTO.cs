using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuThue_DTO
    {
        private int iMaPhieu;
        public int IMaPhieu { get => iMaPhieu; set => iMaPhieu = value; }

        private int iMaPhong;
        public int IMaPhong { get => iMaPhong; set => iMaPhong = value; }

        private int iMaKH;
        public int IMaKH { get => iMaKH; set => iMaKH = value; }

        private DateTime dtNgayCheckIn;
        public DateTime DtNgayCheckIn { get => dtNgayCheckIn; set => dtNgayCheckIn = value; }

        private DateTime dtNgayCheckOutDuKien;
        public DateTime DtNgayCheckOutDuKien { get => dtNgayCheckOutDuKien; set => dtNgayCheckOutDuKien = value; }

        private string sTrangThai;
        public string STrangThai { get => sTrangThai; set => sTrangThai = value; }
    }
}
