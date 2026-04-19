using DTO;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DichVu_BUS
    {
        public static List<DichVu_DTO> LayDanhSachDichVu()
        {
            return DichVu_DAO.LayDanhSachDichVu();
        }

        public static bool ThemDichVu(DichVu_DTO dv)
        {
            return DichVu_DAO.ThemDichVu(dv);
        }

        public static bool SuaDichVu(DichVu_DTO dv)
        {
            return DichVu_DAO.SuaDichVu(dv);
        }

        public static bool XoaDichVu(int maDV)
        {
            return DichVu_DAO.XoaDichVu(maDV);
        }

        public static List<string> LayDanhSachDonViTinh()
        {
            return DichVu_DAO.LayDanhSachDonViTinh();
        }
    }
}
