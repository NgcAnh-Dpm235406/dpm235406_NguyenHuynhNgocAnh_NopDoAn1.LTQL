using DAO;
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
        public DataTable LayDanhSachLoaiPhong()
        {
            // BUS gọi xuống DAO
            return LoaiPhong_DAO.LayDSLoaiPhong();
        }
    }
}
