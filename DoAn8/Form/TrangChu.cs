using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn8
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void menu710_Load(object sender, EventArgs e)
        {

        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            btnThongKe.MouseEnter += (s, e) => btnThongKe.BackColor = Color.FromArgb(255, 193, 7);  // Cam vàng
            btnThongKe.MouseLeave += (s, e) => btnThongKe.BackColor = Color.FromArgb(62, 39, 35);

        }
    }
}
