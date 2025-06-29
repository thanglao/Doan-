using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DoAn8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Bo góc cho TextBox và Button
            RoundControl(txtEmail);
            RoundControl(txtMatKhau);
            RoundControl(btnDangNhap);

            // Tùy chỉnh nút đăng nhập
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void RoundControl(Control control)
        {
            int radius = 15;
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = control.ClientRectangle;

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Bỏ qua nếu không dùng
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

        }
    }
}
