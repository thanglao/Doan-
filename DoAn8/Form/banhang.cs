using DoAn11.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using DoAn11.Forms;
using System;

namespace DoAn11
{
    public partial class Form1 : Form
    {
        private decimal doanhThuHomNay = 0;
        private System.Threading.Timer timerCapNhatDoanhThu;
        private List<OrderDetail> danhSachMonGoi = new List<OrderDetail>();
        private List<OrderDetail> currentOrder = new List<OrderDetail>();
        private Dictionary<int, List<OrderDetail>> donHangTheoBan = new Dictionary<int, List<OrderDetail>>();
        private int banDangChon = 0;
        private decimal tongTien = 0;
        private List<HoaDon> danhSachHoaDon = new List<HoaDon>();
        private int selectedRowIndex = -1; // Để lưu dòng được chọn

        // Event để thông báo khi có món được chọn
        public event Action<MenuItem> OnMonDuocChon;

        // Dictionary để lưu trạng thái bàn
        private Dictionary<int, bool> trangThaiBan = new Dictionary<int, bool>();

        public Form1()
        {
            InitializeComponent();
            KhoiTaoTrangThaiBan();
            KhoiTaoDataGridView();
            KhoiTaoDoanhThu();
            HienThiDanhSachHoaDon();
            timerCapNhatDoanhThu = new System.Threading.Timer(Timer_CapNhatDoanhThu, null, 0, 60000);
        }

        private void KhoiTaoDataGridView()
        {
            // Thiết lập DataGridView để hiển thị món ăn
            dataGridViewHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHoaDon.MultiSelect = false;
            dataGridViewHoaDon.AllowUserToAddRows = false;
            dataGridViewHoaDon.ReadOnly = true;

            // Thiết lập columns nếu chưa có
            if (dataGridViewHoaDon.Columns.Count == 0)
            {
                dataGridViewHoaDon.Columns.Add("ItemName", "Tên món");
                dataGridViewHoaDon.Columns.Add("SoLuong", "Số lượng");
                dataGridViewHoaDon.Columns.Add("Price", "Đơn giá");
                dataGridViewHoaDon.Columns.Add("ThanhTien", "Thành tiền");

                // Thiết lập width cho columns
                dataGridViewHoaDon.Columns["ItemName"].Width = 200;
                dataGridViewHoaDon.Columns["SoLuong"].Width = 100;
                dataGridViewHoaDon.Columns["Price"].Width = 120;
                dataGridViewHoaDon.Columns["ThanhTien"].Width = 120;
            }

            // Thêm event handler cho việc chọn dòng
            dataGridViewHoaDon.SelectionChanged += DataGridViewHoaDon_SelectionChanged;
        }

        private void DataGridViewHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewHoaDon.SelectedRows.Count > 0)
            {
                selectedRowIndex = dataGridViewHoaDon.SelectedRows[0].Index;
            }
        }

        private void KhoiTaoTrangThaiBan()
        {
            // Khởi tạo trạng thái cho 16 bàn
            for (int i = 1; i <= 16; i++)
            {
                trangThaiBan[i] = false; // false = trống, true = có khách
            }
        }

        private void HienThiDonHangBan(int banId)
        {
            banDangChon = banId;

            if (!donHangTheoBan.ContainsKey(banId))
            {
                donHangTheoBan[banId] = new List<OrderDetail>();
            }

            var danhSach = donHangTheoBan[banId];

            // Hiển thị lên DataGridView
            dataGridViewHoaDon.Rows.Clear();
            foreach (var item in danhSach)
            {
                dataGridViewHoaDon.Rows.Add(
                    item.ItemName,
                    item.SoLuong,
                    item.Price.ToString("N0"),
                    item.ThanhTien.ToString("N0")
                );
            }

            // Tính tổng tiền
            decimal tongTien = danhSach.Sum(x => x.ThanhTien);
            lbldoanhthu.Text = $"{tongTien:N0} VNĐ";

            // Cập nhật trạng thái bàn
            CapNhatTrangThaiBan(banId);
        }

        private void CapNhatTrangThaiBan(int banId)
        {
            bool coBan = donHangTheoBan.ContainsKey(banId) && donHangTheoBan[banId].Count > 0;
            trangThaiBan[banId] = coBan;

            // Cập nhật màu nút bàn
            Button btnBan = GetButtonByBanId(banId);
            if (btnBan != null)
            {
                btnBan.BackColor = coBan ? Color.Orange : Color.LightGreen;
                btnBan.ForeColor = coBan ? Color.White : Color.Black;
            }
        }

        private Button GetButtonByBanId(int banId)
        {
            // Tìm button theo ID bàn
            switch (banId)
            {
                case 1: return btnban1;
                case 2: return btnban2;
                case 3: return btnban3;
                case 4: return btnban4;
                case 5: return btnban5;
                case 6: return btnban6;
                case 7: return btnban7;
                case 8: return btnban8;
                case 9: return btnban9;
                case 10: return btnban10;
                case 11: return btnban11;
                case 12: return btnban12;
                case 13: return btnban13;
                case 14: return btnban14;
                case 15: return btnban15;
                case 16: return btnban16;
                default: return null;
            }
        }

        private void KhoiTaoDoanhThu()
        {
            doanhThuHomNay = 0;
            CapNhatHienThiDoanhThu();
            TaoDuLieuMau();
        }

        private void Timer_CapNhatDoanhThu(object sender)
        {
            try
            {
                // Sử dụng Invoke để cập nhật UI từ background thread
                this.Invoke(new Action(() =>
                {
                    TinhToanDoanhThuHomNay();
                    CapNhatHienThiDoanhThu();
                }));
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine($"Lỗi cập nhật doanh thu: {ex.Message}");
            }
        }

        private void TinhToanDoanhThuHomNay()
        {
            DateTime homNay = DateTime.Now.Date;
            doanhThuHomNay = danhSachHoaDon
                .Where(hd => hd.NgayLap.Date == homNay)
                .Sum(hd => hd.TongTien);
        }

        private void CapNhatHienThiDoanhThu()
        {
            if (lbldoanhthu != null)
            {
                lbldoanhthu.Text = $"{doanhThuHomNay:N0} VNĐ";

                // Thay đổi màu sắc theo mức doanh thu
                if (doanhThuHomNay >= 1000000)
                {
                    lbldoanhthu.ForeColor = Color.Green;
                }
                else if (doanhThuHomNay >= 500000)
                {
                    lbldoanhthu.ForeColor = Color.Orange;
                }
                else
                {
                    lbldoanhthu.ForeColor = Color.Red;
                }
            }
        }

        public void ThemHoaDonMoi(int soBan, List<OrderDetail> danhSachMon, decimal tongTien)
        {
            HoaDon hoaDonMoi = new HoaDon
            {
                HoaDonId = danhSachHoaDon.Count + 1,
                SoBan = soBan,
                TongTien = tongTien,
                NgayLap = DateTime.Now,
                DanhSachMon = new List<OrderDetail>(danhSachMon)
            };

            danhSachHoaDon.Add(hoaDonMoi);
            TinhToanDoanhThuHomNay();
            CapNhatHienThiDoanhThu();
            HienThiDanhSachHoaDon();

            MessageBox.Show($"Đã thêm hóa đơn mới!\nBàn: {soBan}\nTổng tiền: {tongTien:N0} VNĐ",
                          "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TaoDuLieuMau()
        {
            // Tạo một số hóa đơn mẫu cho demo
            var hoaDonMau1 = new HoaDon
            {
                HoaDonId = 1,
                SoBan = 1,
                TongTien = 150000,
                NgayLap = DateTime.Now.AddHours(-2),
                DanhSachMon = new List<OrderDetail>()
            };

            var hoaDonMau2 = new HoaDon
            {
                HoaDonId = 2,
                SoBan = 3,
                TongTien = 200000,
                NgayLap = DateTime.Now.AddHours(-1),
                DanhSachMon = new List<OrderDetail>()
            };

            danhSachHoaDon.AddRange(new[] { hoaDonMau1, hoaDonMau2 });
            TinhToanDoanhThuHomNay();
            CapNhatHienThiDoanhThu();
        }

        public decimal LayDoanhThuTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            return danhSachHoaDon
                .Where(hd => hd.NgayLap.Date >= tuNgay.Date && hd.NgayLap.Date <= denNgay.Date)
                .Sum(hd => hd.TongTien);
        }

        public void ThemMonVaoBan(MenuItem item)
        {
            if (banDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi gọi món!", "Chưa chọn bàn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!donHangTheoBan.ContainsKey(banDangChon))
            {
                donHangTheoBan[banDangChon] = new List<OrderDetail>();
            }

            var danhSach = donHangTheoBan[banDangChon];
            var existing = danhSach.FirstOrDefault(x => x.ItemID == item.ItemID);

            if (existing != null)
            {
                existing.SoLuong++;
                existing.ThanhTien = existing.SoLuong * existing.Price;
            }
            else
            {
                danhSach.Add(new OrderDetail
                {
                    OrderDetailId = danhSach.Count + 1,
                    BanId = banDangChon,
                    ItemID = item.ItemID,
                    ItemName = item.ItemName,
                    SoLuong = 1,
                    Price = item.Price,
                    ThanhTien = item.Price,
                    ThoiGian = DateTime.Now
                });
            }

            HienThiDonHangBan(banDangChon);
            
        }

        private void TangSoLuongMon()
        {
            try
            {
                if (banDangChon == 0)
                {
                    MessageBox.Show("Vui lòng chọn bàn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedRowIndex < 0 || selectedRowIndex >= dataGridViewHoaDon.Rows.Count)
                {
                    MessageBox.Show("Vui lòng chọn món cần tăng số lượng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!donHangTheoBan.ContainsKey(banDangChon))
                    return;

                var danhSach = donHangTheoBan[banDangChon];
                if (selectedRowIndex < danhSach.Count)
                {
                    var item = danhSach[selectedRowIndex];
                    item.SoLuong++;
                    item.ThanhTien = item.SoLuong * item.Price;

                    HienThiDonHangBan(banDangChon);
                   
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GiamSoLuongMon()
        {
            try
            {
                if (banDangChon == 0)
                {
                    MessageBox.Show("Vui lòng chọn bàn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedRowIndex < 0 || selectedRowIndex >= dataGridViewHoaDon.Rows.Count)
                {
                    MessageBox.Show("Vui lòng chọn món cần giảm số lượng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!donHangTheoBan.ContainsKey(banDangChon))
                    return;

                var danhSach = donHangTheoBan[banDangChon];
                if (selectedRowIndex < danhSach.Count)
                {
                    var item = danhSach[selectedRowIndex];

                    if (item.SoLuong > 1)
                    {
                        item.SoLuong--;
                        item.ThanhTien = item.SoLuong * item.Price;
                        HienThiDonHangBan(banDangChon);
                        MessageBox.Show($"Đã giảm số lượng {item.ItemName}", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var confirm = MessageBox.Show($"Món {item.ItemName} chỉ còn 1. Bạn có muốn xóa món này?",
                            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirm == DialogResult.Yes)
                        {
                            danhSach.RemoveAt(selectedRowIndex);
                            HienThiDonHangBan(banDangChon);
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        public void XoaMonKhoiBan(int itemId)
        {
            if (banDangChon == 0 || !donHangTheoBan.ContainsKey(banDangChon))
                return;

            var danhSach = donHangTheoBan[banDangChon];
            var item = danhSach.FirstOrDefault(x => x.ItemID == itemId);

            if (item != null)
            {
                if (item.SoLuong > 1)
                {
                    item.SoLuong--;
                    item.ThanhTien = item.SoLuong * item.Price;
                }
                else
                {
                    danhSach.Remove(item);
                }

                HienThiDonHangBan(banDangChon);
            }
        }

        private void HienThiDanhSachHoaDon()
        {
            // Chỉ hiển thị danh sách hóa đơn nếu không đang hiển thị món gọi
            if (banDangChon == 0)
            {
                if (dataGridViewHoaDon.Columns.Count != 4 || dataGridViewHoaDon.Columns[0].Name != "HoaDonId")
                {
                    dataGridViewHoaDon.Columns.Clear();
                    dataGridViewHoaDon.Columns.Add("HoaDonId", "Mã HĐ");
                    dataGridViewHoaDon.Columns.Add("SoBan", "Bàn");
                    dataGridViewHoaDon.Columns.Add("TongTien", "Tổng tiền");
                    dataGridViewHoaDon.Columns.Add("NgayLap", "Ngày lập");
                }

                dataGridViewHoaDon.Rows.Clear();
                foreach (var hd in danhSachHoaDon.OrderByDescending(x => x.NgayLap))
                {
                    dataGridViewHoaDon.Rows.Add(
                        hd.HoaDonId,
                        hd.SoBan,
                        hd.TongTien.ToString("N0") + " VNĐ",
                        hd.NgayLap.ToString("dd/MM/yyyy HH:mm")
                    );
                }
            }
        }

        // Button Event Handlers
        private void btnthem_Click(object sender, EventArgs e)
        {

        }

        private void btntang_Click(object sender, EventArgs e)
        {
            TangSoLuongMon();
        }

        private void btngiam_Click(object sender, EventArgs e)
        {
            GiamSoLuongMon();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (banDangChon == 0)
                {
                    MessageBox.Show("Vui lòng chọn bàn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedRowIndex < 0 || selectedRowIndex >= dataGridViewHoaDon.Rows.Count)
                {
                    MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!donHangTheoBan.ContainsKey(banDangChon))
                    return;

                var danhSach = donHangTheoBan[banDangChon];
                if (selectedRowIndex < danhSach.Count)
                {
                    var item = danhSach[selectedRowIndex];

                    var confirm = MessageBox.Show($"Bạn có chắc muốn xóa món {item.ItemName}?",
                        "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        danhSach.RemoveAt(selectedRowIndex);
                        HienThiDonHangBan(banDangChon);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            if (banDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn để thanh toán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!donHangTheoBan.ContainsKey(banDangChon) || donHangTheoBan[banDangChon].Count == 0)
            {
                MessageBox.Show("Bàn này chưa có món nào để thanh toán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dsMon = donHangTheoBan[banDangChon];
            decimal tongTien = dsMon.Sum(x => x.ThanhTien);

            var confirm = MessageBox.Show(
                $"Xác nhận thanh toán bàn {banDangChon} với tổng tiền {tongTien:N0} VNĐ?",
                "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Tạo hóa đơn mới
                ThemHoaDonMoi(banDangChon, dsMon, tongTien);

                // Xóa món gọi của bàn
                donHangTheoBan[banDangChon].Clear();
                HienThiDonHangBan(banDangChon);

                MessageBox.Show($"Thanh toán bàn {banDangChon} thành công!\nTổng tiền: {tongTien:N0} VNĐ",
                    "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Table Button Event Handlers
        private void btnban1_Click(object sender, EventArgs e) => HienThiDonHangBan(1);
        private void btnban2_Click(object sender, EventArgs e) => HienThiDonHangBan(2);
        private void btnban3_Click(object sender, EventArgs e) => HienThiDonHangBan(3);
        private void btnban4_Click(object sender, EventArgs e) => HienThiDonHangBan(4);
        private void btnban5_Click(object sender, EventArgs e) => HienThiDonHangBan(5);
        private void btnban6_Click(object sender, EventArgs e) => HienThiDonHangBan(6);
        private void btnban7_Click(object sender, EventArgs e) => HienThiDonHangBan(7);
        private void btnban8_Click(object sender, EventArgs e) => HienThiDonHangBan(8);
        private void btnban9_Click(object sender, EventArgs e) => HienThiDonHangBan(9);
        private void btnban10_Click(object sender, EventArgs e) => HienThiDonHangBan(10);
        private void btnban11_Click(object sender, EventArgs e) => HienThiDonHangBan(11);
        private void btnban12_Click(object sender, EventArgs e) => HienThiDonHangBan(12);
        private void btnban13_Click(object sender, EventArgs e) => HienThiDonHangBan(13);
        private void btnban14_Click(object sender, EventArgs e) => HienThiDonHangBan(14);
        private void btnban15_Click(object sender, EventArgs e) => HienThiDonHangBan(15);
        private void btnban16_Click(object sender, EventArgs e) => HienThiDonHangBan(16);

        // Menu and Staff Button Event Handlers
        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            FromNhanVien fromNhanVien_ = new FromNhanVien();
            fromNhanVien_.Show();
        }

        private void btnthucdon_Click(object sender, EventArgs e)
        {
            MEnu menuForm = new MEnu();
            menuForm.Show();
        }

        // Other Event Handlers (keeping empty ones for compatibility)
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void btnChonAnh_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel1_Paint_1(object sender, PaintEventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void button22_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void panelMain_Paint(object sender, PaintEventArgs e) { }
        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void lbldoanhthu_Click(object sender, EventArgs e) { }
        private void button2_Click_1(object sender, EventArgs e) { HienThiDonHangBan(2); }
        private void panelHeaderDH_Paint(object sender, PaintEventArgs e) { }
        private void panelNavigation_Paint(object sender, PaintEventArgs e) { }
        private void dataGridViewHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e) { }

        // Dispose timer when form closes
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timerCapNhatDoanhThu?.Dispose();
            base.OnFormClosed(e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (banDangChon == 0)
                {
                    MessageBox.Show("Vui lòng chọn bàn trước khi thêm món!", "Chưa chọn bàn",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mở form menu để chọn món
                MEnu menuForm = new MEnu();

                // Đăng ký event khi chọn món
                menuForm.OnMonDuocChon += (MenuItem selectedItem) =>
                {
                    ThemMonVaoBan(selectedItem);
                    menuForm.Close();
                };

                menuForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntang_Click_1(object sender, EventArgs e)
        {
            TangSoLuongMon();
        }

        private void btngiam_Click_1(object sender, EventArgs e)
        {
            GiamSoLuongMon();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (banDangChon == 0)
                {
                    MessageBox.Show("Vui lòng chọn bàn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedRowIndex < 0 || selectedRowIndex >= dataGridViewHoaDon.Rows.Count)
                {
                    MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!donHangTheoBan.ContainsKey(banDangChon))
                    return;

                var danhSach = donHangTheoBan[banDangChon];
                if (selectedRowIndex < danhSach.Count)
                {
                    var item = danhSach[selectedRowIndex];

                    var confirm = MessageBox.Show($"Bạn có chắc muốn xóa món {item.ItemName}?",
                        "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        danhSach.RemoveAt(selectedRowIndex);
                        HienThiDonHangBan(banDangChon);
                        MessageBox.Show($"Đã xóa món {item.ItemName}", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa món: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }
    }
}