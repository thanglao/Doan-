using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DoAn8
{
    public partial class GoiMonThanhToan : Form
    {
        public class Item
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }

        private List<Item> listItems = new List<Item>();

        public GoiMonThanhToan()
        {
            InitializeComponent();
            KhoiTaoSuKien();
        }

        private void KhoiTaoSuKien()
        {
            btnCaPheDen.Tag = "Cà Phê Đen";
            btnCaPheSua.Tag = "Cà Phê Sữa";
            btnTraSua.Tag = "Trà Sữa Truyền Thống";
            btnTraDao.Tag = "Trà Đào";
            btnBacXiu.Tag = "Bạc Xỉu";
            btnDenDa.Tag = "Đen Đá";

            btnCaPheDen.Click += btnThemMon_Click;
            btnCaPheSua.Click += btnThemMon_Click;
            btnTraSua.Click += btnThemMon_Click;
            btnTraDao.Click += btnThemMon_Click;
            btnBacXiu.Click += btnThemMon_Click;
            btnDenDa.Click += btnThemMon_Click;

            btnXoa.Click += btnXoa_Click;
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string tenMon = btn.Tag.ToString();
            decimal giaMon = 15000; // Tạm thời mỗi món đều 15.000đ

            var existingItem = listItems.Find(i => i.Name == tenMon);
            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                listItems.Add(new Item
                {
                    Name = tenMon,
                    Quantity = 1,
                    Price = giaMon
                });
            }

            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            decimal total = listItems.Sum(i => i.Price * i.Quantity);
            decimal discount = total * 0.05m;
            decimal vat = (total - discount) * 0.1m;
            decimal grandTotal = total - discount + vat;

            lblTamTinh.Text = total.ToString("N0") + " đ";
            lblGiamGia.Text = discount.ToString("N0") + " đ";
            lblVAT.Text = vat.ToString("N0") + " đ";
            lblTongCong.Text = grandTotal.ToString("N0") + " đ";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            listItems.Clear();
            CapNhatTongTien();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e) { }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void GoiMonThanhToan_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel24_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }
        private void panel_MouseEnter(object sender, EventArgs e)
        {
            var panel = sender as Guna.UI2.WinForms.Guna2Panel;
            panel.ShadowDecoration.Depth = 15;
            panel.ShadowDecoration.Shadow = new Padding(10);
            panel.FillColor = Color.FromArgb(245, 245, 245);

            // Giả lập Scale bằng tăng kích thước nhẹ
            panel.Size = new Size(panel.Width + 4, panel.Height + 4);
            panel.Location = new Point(panel.Left - 2, panel.Top - 2); // dịch lại để giữ tâm
        }

        private void panel_MouseLeave(object sender, EventArgs e)
        {
            var panel = sender as Guna.UI2.WinForms.Guna2Panel;
            panel.ShadowDecoration.Depth = 5;
            panel.ShadowDecoration.Shadow = new Padding(5);
            panel.FillColor = Color.White;

            // Thu nhỏ lại kích thước ban đầu
            panel.Size = new Size(panel.Width - 4, panel.Height - 4);
            panel.Location = new Point(panel.Left + 2, panel.Top + 2);
        }

    }
}
