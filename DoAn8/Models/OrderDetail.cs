using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn11.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderID { get; set; }
        public int BanId { get; set; } // Giữ lại để tương thích với code cũ
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int SoLuong { get; set; }
        public decimal Price { get; set; }
        public decimal ThanhTien { get; set; }
        public DateTime ThoiGian { get; set; }
    }
}
