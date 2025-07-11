using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn11.Models
{
    public class HoaDon
    {
        public int HoaDonId { get; set; }                 // Mã hóa đơn
        public int SoBan { get; set; }                    // Số bàn (kiểu số)
        public decimal TongTien { get; set; }             // Tổng tiền
        public DateTime NgayLap { get; set; }             // Ngày lập
        public DateTime ThoiGian => NgayLap;              // Để tương thích với phần thống kê
        public List<OrderDetail> DanhSachMon { get; set; } = new List<OrderDetail>();
    }
}
