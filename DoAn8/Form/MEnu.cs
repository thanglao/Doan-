using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn11.Models;

using DoAn11.DataAccess;


namespace DoAn11.Forms
{
    public partial class MEnu : Form
    {
        private string currentFilter = "Tất Cả";
        public event Action<MenuItem> OnMonDuocChon;

        public MEnu()
        {
            InitializeComponent();
            LoadDanhMuc();
            LoadMenu();
            LoadMenuToGrid();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }
        private List<MenuItem> allMenuItems = new List<MenuItem>();
        private void LoadDanhMuc()
        {
            cmbDanhMuc.Items.AddRange(new string[] { "Tất Cả", "Cà Phê", "Trà", "Bánh", "Đồ Ăn" });
            cmbDanhMuc.SelectedIndex = 0;
        }
        private void LoadMenu()
        {
            try
            {
                string category = cmbDanhMuc.SelectedItem?.ToString() ?? "Tất Cả";
                var list = MenuDAO.GetMenuByCategory(category == "Tất Cả" ? "" : category);

                flowMenuCards.Controls.Clear();

                foreach (var item in list)
                {
                    Panel panel = new Panel();
                    panel.Width = 150;
                    panel.Height = 180;
                    panel.Margin = new Padding(10);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Cursor = Cursors.Hand; // ✅ THÊM CON TRỎ TAY
                    panel.Tag = item.ItemID; // ✅ LUU ID ĐỂ TIỆN SỬ DỤNG

                    PictureBox pic = new PictureBox();
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.Width = 130;
                    pic.Height = 130;
                    pic.Location = new Point(10, 5);
                    pic.Cursor = Cursors.Hand; // ✅ THÊM CON TRỎ TAY

                    // Load ảnh an toàn
                    try
                    {
                        if (!string.IsNullOrEmpty(item.ImagePath) && File.Exists(item.ImagePath))
                        {
                            using (var originalImage = Image.FromFile(item.ImagePath))
                            {
                                pic.Image = new Bitmap(originalImage);
                            }
                        }
                        else
                        {
                            pic.Image = CreatePlaceholderImage();
                        }
                    }
                    catch (Exception ex)
                    {
                        pic.Image = CreatePlaceholderImage();
                        Console.WriteLine($"Lỗi load ảnh trong flowlayout: {ex.Message}");
                    }

                    Label lbl = new Label();
                    lbl.Text = $"{item.ItemName}\n{item.Price:N0} VND";
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Dock = DockStyle.Bottom;
                    lbl.Height = 40;
                    lbl.Font = new Font("Arial", 8, FontStyle.Bold);
                    lbl.Cursor = Cursors.Hand; // ✅ THÊM CON TRỎ TAY

                    // ✅ THÊM SỰ KIỆN CLICK
                    panel.Click += (s, e) => LoadMenuItemToForm(item.ItemID);
                    pic.Click += (s, e) => LoadMenuItemToForm(item.ItemID);
                    lbl.Click += (s, e) => LoadMenuItemToForm(item.ItemID);

                    panel.Controls.Add(pic);
                    panel.Controls.Add(lbl);
                    flowMenuCards.Controls.Add(panel);
                    panel.Click += (s, e) => OnMonDuocChon?.Invoke(item);
                    pic.Click += (s, e) => OnMonDuocChon?.Invoke(item);
                    lbl.Click += (s, e) => OnMonDuocChon?.Invoke(item);
                    panel.Tag = item; // vẫn giữ nếu cần
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load menu cards: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadMenuItemToForm(int itemId)
        {
            try
            {
                var menuItem = MenuDAO.GetMenuItemById(itemId);
                if (menuItem != null)
                {
                    txtMaMon.Text = menuItem.ItemID.ToString();
                    txtTenMon.Text = menuItem.ItemName;
                    cmbDanhMuc.Text = menuItem.Category;
                    txtGia.Text = menuItem.Price.ToString();
                    chkTrangThai.Checked = menuItem.IsAvailable;
                    txtImagePath.Text = menuItem.ImagePath ?? "";

                    // Load ảnh
                    if (!string.IsNullOrEmpty(menuItem.ImagePath) && File.Exists(menuItem.ImagePath))
                    {
                        using (var originalImage = Image.FromFile(menuItem.ImagePath))
                        {
                            picMonAn.Image = new Bitmap(originalImage);
                        }
                    }
                    else
                    {
                        picMonAn.Image = CreatePlaceholderImage();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load thông tin món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadMenuToGrid()
        {
            try
            {
                string category = cmbDanhMuc.SelectedItem?.ToString() ?? "Tất Cả";
                var list = MenuDAO.GetMenuByCategory(category == "Tất Cả" ? "" : category);

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                // Thêm các cột văn bản
                dataGridView1.Columns.Add("ItemID", "Mã món");
                dataGridView1.Columns.Add("ItemName", "Tên món");
                dataGridView1.Columns.Add("Category", "Danh mục");
                dataGridView1.Columns.Add("Price", "Giá");
                dataGridView1.Columns.Add("IsAvailable", "Trạng thái");

                // ✅ THÊM CỘT ẢNH
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "ImageColumn";
                imgCol.HeaderText = "Hình ảnh";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 120;
                dataGridView1.Columns.Add(imgCol);

                // Duyệt danh sách để thêm từng dòng
                foreach (var item in list)
                {
                    Image img = null;
                    try
                    {
                        if (!string.IsNullOrEmpty(item.ImagePath) && File.Exists(item.ImagePath))
                        {
                            using (var originalImage = Image.FromFile(item.ImagePath))
                            {
                                img = new Bitmap(originalImage);
                            }
                        }
                        else
                        {
                            img = CreatePlaceholderImage();
                        }
                    }
                    catch (Exception ex)
                    {
                        img = CreatePlaceholderImage();
                        Console.WriteLine($"Lỗi load ảnh: {ex.Message}");
                    }

                    dataGridView1.Rows.Add(
                        item.ItemID,
                        item.ItemName,
                        item.Category,
                        item.Price.ToString("N0") + " VND",
                        item.IsAvailable ? "✔" : "✘",
                        img
                    );
                }

                // ✅ THIẾT LẬP CHIỀU CAO DÒNG
                dataGridView1.RowTemplate.Height = 100;

                // ✅ THIẾT LẬP CHẾ ĐỘ HIỂN THỊ
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["ImageColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns["ImageColumn"].Width = 120;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load menu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Image CreatePlaceholderImage()
        {
            Bitmap placeholder = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(placeholder))
            {
                g.FillRectangle(Brushes.LightGray, 0, 0, 100, 100);
                g.DrawString("No Image", new Font("Arial", 8), Brushes.Black, 10, 45);
            }
            return placeholder;
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelButtonsMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowMenuCards_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkTrangThai_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ VALIDATION CƠ BẢN
                if (string.IsNullOrWhiteSpace(txtTenMon.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenMon.Focus();
                    return;
                }

                if (!decimal.TryParse(txtGia.Text, out decimal gia) || gia <= 0)
                {
                    MessageBox.Show("Vui lòng nhập giá hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGia.Focus();
                    return;
                }

                // ✅ VALIDATION BỔ SUNG
                if (cmbDanhMuc.SelectedIndex == -1 || string.IsNullOrEmpty(cmbDanhMuc.Text))
                {
                    MessageBox.Show("Vui lòng chọn danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDanhMuc.Focus();
                    return;
                }

                // ✅ VALIDATION ĐƯỜNG DẪN ẢNH (OPTIONAL)
                if (!string.IsNullOrEmpty(txtImagePath.Text.Trim()) && !File.Exists(txtImagePath.Text.Trim()))
                {
                    MessageBox.Show("Đường dẫn ảnh không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtImagePath.Focus();
                    return;
                }

                // ✅ KIỂM TRA XEM LÀ THÊM MỚI HAY CẬP NHẬT
                // Cách 1: Kiểm tra txtMaMon có rỗng/0 hay không
                bool isNewItem = string.IsNullOrEmpty(txtMaMon.Text.Trim()) || txtMaMon.Text.Trim() == "0";

                // Cách 2: Hoặc kiểm tra món có tồn tại trong DB hay không
                int itemId = 0;
                if (!string.IsNullOrEmpty(txtMaMon.Text.Trim()) && int.TryParse(txtMaMon.Text.Trim(), out itemId))
                {
                    var existingItem = MenuDAO.GetMenuItemById(itemId);
                    if (existingItem == null)
                    {
                        isNewItem = true; // Món không tồn tại trong DB
                    }
                }
                else
                {
                    isNewItem = true; // Không parse được ID hoặc rỗng
                }

                // ✅ TẠO OBJECT MENU ITEM
                var item = new MenuItem()
                {
                    ItemID = isNewItem ? 0 : itemId,
                    ItemName = txtTenMon.Text.Trim(),
                    Category = cmbDanhMuc.Text,
                    Price = gia,
                    IsAvailable = chkTrangThai.Checked,
                    ImagePath = string.IsNullOrEmpty(txtImagePath.Text.Trim()) ? null : txtImagePath.Text.Trim()
                };

                // ✅ THÊM HOẶC SỬA
                if (isNewItem)
                {
                    // ✅ KIỂM TRA TRÙNG TÊN KHI THÊM MỚI
                    if (MenuDAO.IsItemNameExists(item.ItemName))
                    {
                        MessageBox.Show("Tên món đã tồn tại! Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTenMon.Focus();
                        return;
                    }

                    MenuDAO.Insert(item);
                    MessageBox.Show("Thêm món mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ✅ KIỂM TRA TRÙNG TÊN KHI SỬA (LOẠI TRỪ CHÍNH NÓ)
                    if (MenuDAO.IsItemNameExists(item.ItemName, item.ItemID))
                    {
                        MessageBox.Show("Tên món đã tồn tại! Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTenMon.Focus();
                        return;
                    }

                    MenuDAO.Update(item);
                    MessageBox.Show("Cập nhật món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // ✅ REFRESH DỮ LIỆU
                LoadMenuToGrid();
                LoadMenu();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Chi tiết lỗi: {ex.ToString()}");
            }
        }
        private void ClearForm()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            cmbDanhMuc.SelectedIndex = 0;
            txtGia.Clear();
            txtImagePath.Clear();
            chkTrangThai.Checked = true;
            picMonAn.Image = null;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtMaMon.Text, out int id))
                {
                    var result = MessageBox.Show("Bạn có chắc muốn xóa món này?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        MenuDAO.Delete(id);
                        LoadMenuToGrid();
                        LoadMenu();
                        ClearForm();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txttimkiem.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttimkiem.Focus();
                    return;
                }

                // Tìm kiếm nâng cao
                var allItems = MenuDAO.GetMenuByCategory(""); // Lấy tất cả
                var results = allItems.Where(item =>
                    item.ItemName.ToLower().Contains(searchText.ToLower()) ||
                    item.Category.ToLower().Contains(searchText.ToLower()) ||
                    item.Price.ToString().Contains(searchText)
                ).ToList();

                if (results.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy kết quả nào cho từ khóa: '{searchText}'",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Hiển thị kết quả
                LoadFilteredItemsToGrid(results);
                LoadFilteredItemsToFlowLayout(results);

                // Hiển thị số lượng kết quả
                MessageBox.Show($"Tìm thấy {results.Count} kết quả cho từ khóa: '{searchText}'",
                    "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadFilteredItemsToFlowLayout(List<MenuItem> items)
        {
            try
            {
                flowMenuCards.Controls.Clear();

                foreach (var item in items)
                {
                    Panel panel = new Panel();
                    panel.Width = 150;
                    panel.Height = 180;
                    panel.Margin = new Padding(10);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Cursor = Cursors.Hand;
                    panel.Tag = item.ItemID;

                    PictureBox pic = new PictureBox();
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.Width = 130;
                    pic.Height = 130;
                    pic.Location = new Point(10, 5);
                    pic.Cursor = Cursors.Hand;

                    // Load ảnh an toàn
                    try
                    {
                        if (!string.IsNullOrEmpty(item.ImagePath) && File.Exists(item.ImagePath))
                        {
                            using (var originalImage = Image.FromFile(item.ImagePath))
                            {
                                pic.Image = new Bitmap(originalImage);
                            }
                        }
                        else
                        {
                            pic.Image = CreatePlaceholderImage();
                        }
                    }
                    catch
                    {
                        pic.Image = CreatePlaceholderImage();
                    }

                    Label lbl = new Label();
                    lbl.Text = $"{item.ItemName}\n{item.Price:N0} VND";
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Dock = DockStyle.Bottom;
                    lbl.Height = 40;
                    lbl.Font = new Font("Arial", 8, FontStyle.Bold);
                    lbl.Cursor = Cursors.Hand;

                    // Thêm sự kiện click
                    panel.Click += (s, e) => LoadMenuItemToForm(item.ItemID);
                    pic.Click += (s, e) => LoadMenuItemToForm(item.ItemID);
                    lbl.Click += (s, e) => LoadMenuItemToForm(item.ItemID);

                    panel.Controls.Add(pic);
                    panel.Controls.Add(lbl);
                    flowMenuCards.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load filtered flow layout: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Chọn ảnh món ăn";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.FilterIndex = 1;
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;


                    using (var originalImage = Image.FromFile(filePath))
                    {
                        picMonAn.Image = new Bitmap(originalImage);
                    }

                    txtImagePath.Text = filePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picMonAn_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    txtMaMon.Text = row.Cells["ItemID"].Value?.ToString() ?? "";
                    txtTenMon.Text = row.Cells["ItemName"].Value?.ToString() ?? "";
                    cmbDanhMuc.Text = row.Cells["Category"].Value?.ToString() ?? "";

                    string priceText = row.Cells["Price"].Value?.ToString() ?? "";
                    priceText = priceText.Replace(" VND", "").Replace(",", "");
                    txtGia.Text = priceText;

                    chkTrangThai.Checked = row.Cells["IsAvailable"].Value?.ToString() == "✔";

                    if (row.Cells["ImageColumn"].Value is Image img)
                    {
                        picMonAn.Image = new Bitmap(img);
                    }

                    int itemId = int.Parse(txtMaMon.Text);
                    var menuItem = MenuDAO.GetMenuItemById(itemId);
                    if (menuItem != null)
                    {
                        txtImagePath.Text = menuItem.ImagePath ?? "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi load dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AddClickEventToMenuCards()
        {
            foreach (Control control in flowMenuCards.Controls)
            {
                if (control is Panel panel)
                {
                    panel.Click += MenuCard_Click;
                    foreach (Control child in panel.Controls)
                    {
                        child.Click += MenuCard_Click;
                    }
                }
            }
        }
        private void MenuCard_Click(object sender, EventArgs e)
        {
            try
            {
                Panel panel = null;
                if (sender is Panel)
                    panel = (Panel)sender;
                else if (sender is Control control)
                    panel = control.Parent as Panel;

                if (panel != null)
                {
                    Label label = panel.Controls.OfType<Label>().FirstOrDefault();
                    if (label != null)
                    {
                        string[] parts = label.Text.Split('\n');
                        if (parts.Length >= 2)
                        {
                            string itemName = parts[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTabTea_Click(object sender, EventArgs e)
        {
            cmbDanhMuc.SelectedItem = "Trà";
        }

        private void btnTabCake_Click(object sender, EventArgs e)
        {
            cmbDanhMuc.SelectedItem = "Bánh";
        }

        private void btnTabSnack_Click(object sender, EventArgs e)
        {
            cmbDanhMuc.SelectedItem = "Đồ Ăn";
        }

        private void btnTabCoffee_Click(object sender, EventArgs e)
        {
            cmbDanhMuc.SelectedItem = "Cà Phê";
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadFilteredItemsToGrid(List<MenuItem> items)
        {
            try
            {
                dataGridView1.Rows.Clear();

                foreach (var item in items)
                {
                    Image img = null;
                    try
                    {
                        if (!string.IsNullOrEmpty(item.ImagePath) && File.Exists(item.ImagePath))
                        {
                            using (var originalImage = Image.FromFile(item.ImagePath))
                            {
                                img = new Bitmap(originalImage);
                            }
                        }
                        else
                        {
                            img = CreatePlaceholderImage();
                        }
                    }
                    catch
                    {
                        img = CreatePlaceholderImage();
                    }

                    dataGridView1.Rows.Add(
                        item.ItemID,
                        item.ItemName,
                        item.Category,
                        item.Price.ToString("N0") + " VND",
                        item.IsAvailable ? "✔" : "✘",
                        img
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load filtered items: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenuToGrid();
            LoadMenu();
        }

        private void splitMainMenu_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTabAll_Click(object sender, EventArgs e)
        {
            cmbDanhMuc.SelectedItem = "Tất Cả";
            txttimkiem.Text = "";
            LoadMenuToGrid();
            LoadMenu();
        }

        private void hu_Enter(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {

        }

        private void btnsua_Click(object sender, EventArgs e)
        {

        }

        private void MEnu_Load(object sender, EventArgs e)
        {

        }
    }
}
