using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan_DTO
    {
        private int iMaTK;
        public int IMaTK { get => iMaTK; set => iMaTK = value; }

        private string sTenDangNhap;
        public string STenDangNhap { get => sTenDangNhap; set => sTenDangNhap = value; }

        private string sMatKhau;
        public string SMatKhau { get => sMatKhau; set => sMatKhau = value; }

        private string sHoTen;
        public string SHoTen { get => sHoTen; set => sHoTen = value; }

        private int iLoaiTaiKhoan;
        public int ILoaiTaiKhoan { get => iLoaiTaiKhoan; set => iLoaiTaiKhoan = value; }

        private bool bTrangThai;
        public bool BTrangThai { get => bTrangThai; set => bTrangThai = value; }
    }
}
