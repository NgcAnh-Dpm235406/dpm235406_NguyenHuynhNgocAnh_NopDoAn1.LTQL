using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiPhong_BUS
    {
        public static DataTable LayDanhSachLoaiPhong()
        {
            return LoaiPhong_DAO.LayDSLoaiPhong();
        }

        public static LoaiPhong_DTO LayLoaiPhongTheoMa(int maLoai)
        {
            return LoaiPhong_DAO.LayLoaiPhongTheoMa(maLoai);
        }



    }
}
