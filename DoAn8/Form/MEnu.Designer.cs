namespace DoAn11.Forms
{
    partial class MEnu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeaderMenu = new Panel();
            panelCategoryTabs = new Panel();
            btnTabSnack = new Button();
            btnTabCake = new Button();
            btnTabTea = new Button();
            btnTabCoffee = new Button();
            btnTabAll = new Button();
            label1 = new Label();
            splitMainMenu = new SplitContainer();
            panelButtonsMenu = new Panel();
            btnluu = new Button();
            btnxoa = new Button();
            btnhuy = new Button();
            hu = new GroupBox();
            txtImagePath = new TextBox();
            label6 = new Label();
            chkTrangThai = new CheckBox();
            txtGia = new TextBox();
            label5 = new Label();
            cmbDanhMuc = new ComboBox();
            label4 = new Label();
            txtTenMon = new TextBox();
            label3 = new Label();
            txtMaMon = new TextBox();
            label2 = new Label();
            btnChonAnh = new Button();
            picMonAn = new PictureBox();
            flowMenuCards = new FlowLayoutPanel();
            dataGridView1 = new DataGridView();
            panelSearchMenu = new Panel();
            btntimkiem = new Button();
            txttimkiem = new TextBox();
            label7 = new Label();
            openFileDialog1 = new OpenFileDialog();
            panelHeaderMenu.SuspendLayout();
            panelCategoryTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMainMenu).BeginInit();
            splitMainMenu.Panel1.SuspendLayout();
            splitMainMenu.Panel2.SuspendLayout();
            splitMainMenu.SuspendLayout();
            panelButtonsMenu.SuspendLayout();
            hu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMonAn).BeginInit();
            flowMenuCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelSearchMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeaderMenu
            // 
            panelHeaderMenu.BackColor = Color.FromArgb(52, 31, 19);
            panelHeaderMenu.Controls.Add(panelCategoryTabs);
            panelHeaderMenu.Controls.Add(label1);
            panelHeaderMenu.Dock = DockStyle.Top;
            panelHeaderMenu.Location = new Point(0, 0);
            panelHeaderMenu.Name = "panelHeaderMenu";
            panelHeaderMenu.Size = new Size(1182, 116);
            panelHeaderMenu.TabIndex = 0;
            // 
            // panelCategoryTabs
            // 
            panelCategoryTabs.BackColor = Color.Transparent;
            panelCategoryTabs.Controls.Add(btnTabSnack);
            panelCategoryTabs.Controls.Add(btnTabCake);
            panelCategoryTabs.Controls.Add(btnTabTea);
            panelCategoryTabs.Controls.Add(btnTabCoffee);
            panelCategoryTabs.Controls.Add(btnTabAll);
            panelCategoryTabs.Location = new Point(3, 63);
            panelCategoryTabs.Name = "panelCategoryTabs";
            panelCategoryTabs.Size = new Size(653, 50);
            panelCategoryTabs.TabIndex = 1;
            // 
            // btnTabSnack
            // 
            btnTabSnack.BackColor = Color.Wheat;
            btnTabSnack.FlatStyle = FlatStyle.Flat;
            btnTabSnack.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTabSnack.ForeColor = Color.FromArgb(35, 31, 32);
            btnTabSnack.Location = new Point(520, 5);
            btnTabSnack.Name = "btnTabSnack";
            btnTabSnack.Size = new Size(120, 40);
            btnTabSnack.TabIndex = 4;
            btnTabSnack.Text = "\U0001f96a Đồ Ăn Nhẹ";
            btnTabSnack.UseVisualStyleBackColor = false;
            btnTabSnack.Click += btnTabSnack_Click;
            // 
            // btnTabCake
            // 
            btnTabCake.BackColor = Color.Wheat;
            btnTabCake.FlatStyle = FlatStyle.Flat;
            btnTabCake.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTabCake.ForeColor = Color.FromArgb(35, 31, 32);
            btnTabCake.Location = new Point(390, 5);
            btnTabCake.Name = "btnTabCake";
            btnTabCake.Size = new Size(120, 40);
            btnTabCake.TabIndex = 3;
            btnTabCake.Text = "\U0001f9c1 Bánh Ngọt";
            btnTabCake.UseVisualStyleBackColor = false;
            btnTabCake.Click += btnTabCake_Click;
            // 
            // btnTabTea
            // 
            btnTabTea.BackColor = Color.Wheat;
            btnTabTea.FlatStyle = FlatStyle.Flat;
            btnTabTea.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTabTea.ForeColor = Color.FromArgb(35, 31, 32);
            btnTabTea.Location = new Point(260, 5);
            btnTabTea.Name = "btnTabTea";
            btnTabTea.Size = new Size(120, 40);
            btnTabTea.TabIndex = 2;
            btnTabTea.Text = "🍵 Trà";
            btnTabTea.UseVisualStyleBackColor = false;
            btnTabTea.Click += btnTabTea_Click;
            // 
            // btnTabCoffee
            // 
            btnTabCoffee.BackColor = Color.Wheat;
            btnTabCoffee.FlatStyle = FlatStyle.Flat;
            btnTabCoffee.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTabCoffee.ForeColor = Color.FromArgb(35, 31, 32);
            btnTabCoffee.Location = new Point(130, 5);
            btnTabCoffee.Name = "btnTabCoffee";
            btnTabCoffee.Size = new Size(120, 40);
            btnTabCoffee.TabIndex = 1;
            btnTabCoffee.Text = "☕ Cà Phê";
            btnTabCoffee.UseVisualStyleBackColor = false;
            btnTabCoffee.Click += btnTabCoffee_Click;
            // 
            // btnTabAll
            // 
            btnTabAll.BackColor = Color.Goldenrod;
            btnTabAll.FlatStyle = FlatStyle.Flat;
            btnTabAll.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTabAll.ForeColor = Color.FromArgb(35, 31, 32);
            btnTabAll.Location = new Point(0, 5);
            btnTabAll.Name = "btnTabAll";
            btnTabAll.Size = new Size(120, 40);
            btnTabAll.TabIndex = 0;
            btnTabAll.Text = "☕ Tất Cả";
            btnTabAll.UseVisualStyleBackColor = false;
            btnTabAll.Click += btnTabAll_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Goldenrod;
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(367, 41);
            label1.TabIndex = 0;
            label1.Text = "🍽️ QUẢN LÝ THỰC ĐƠN";
            // 
            // splitMainMenu
            // 
            splitMainMenu.Dock = DockStyle.Fill;
            splitMainMenu.FixedPanel = FixedPanel.Panel1;
            splitMainMenu.Location = new Point(0, 116);
            splitMainMenu.Name = "splitMainMenu";
            // 
            // splitMainMenu.Panel1
            // 
            splitMainMenu.Panel1.Controls.Add(panelButtonsMenu);
            splitMainMenu.Panel1.Controls.Add(hu);
            splitMainMenu.Panel1.Padding = new Padding(20);
            splitMainMenu.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitMainMenu.Panel2
            // 
            splitMainMenu.Panel2.Controls.Add(flowMenuCards);
            splitMainMenu.Panel2.Controls.Add(panelSearchMenu);
            splitMainMenu.Panel2.Padding = new Padding(20);
            splitMainMenu.Size = new Size(1182, 851);
            splitMainMenu.SplitterDistance = 400;
            splitMainMenu.TabIndex = 1;
            // 
            // panelButtonsMenu
            // 
            panelButtonsMenu.BackColor = Color.Transparent;
            panelButtonsMenu.Controls.Add(btnluu);
            panelButtonsMenu.Controls.Add(btnxoa);
            panelButtonsMenu.Controls.Add(btnhuy);
            panelButtonsMenu.Location = new Point(27, 748);
            panelButtonsMenu.Name = "panelButtonsMenu";
            panelButtonsMenu.Size = new Size(350, 80);
            panelButtonsMenu.TabIndex = 0;
            panelButtonsMenu.Paint += panelButtonsMenu_Paint;
            // 
            // btnluu
            // 
            btnluu.BackColor = Color.FromArgb(33, 150, 243);
            btnluu.FlatStyle = FlatStyle.Flat;
            btnluu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnluu.ForeColor = Color.White;
            btnluu.Location = new Point(134, 19);
            btnluu.Name = "btnluu";
            btnluu.Size = new Size(90, 35);
            btnluu.TabIndex = 16;
            btnluu.Text = "Lưu";
            btnluu.UseVisualStyleBackColor = false;
            btnluu.Click += btnluu_Click;
            // 
            // btnxoa
            // 
            btnxoa.BackColor = Color.FromArgb(229, 57, 53);
            btnxoa.FlatStyle = FlatStyle.Flat;
            btnxoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnxoa.ForeColor = Color.White;
            btnxoa.Location = new Point(253, 19);
            btnxoa.Name = "btnxoa";
            btnxoa.Size = new Size(90, 35);
            btnxoa.TabIndex = 14;
            btnxoa.Text = "Xóa";
            btnxoa.UseVisualStyleBackColor = false;
            btnxoa.Click += btnxoa_Click;
            // 
            // btnhuy
            // 
            btnhuy.BackColor = Color.Maroon;
            btnhuy.FlatStyle = FlatStyle.Flat;
            btnhuy.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnhuy.ForeColor = Color.White;
            btnhuy.Location = new Point(16, 19);
            btnhuy.Name = "btnhuy";
            btnhuy.Size = new Size(90, 35);
            btnhuy.TabIndex = 15;
            btnhuy.Text = "Hủy";
            btnhuy.UseVisualStyleBackColor = false;
            btnhuy.Click += btnhuy_Click;
            // 
            // hu
            // 
            hu.BackColor = Color.White;
            hu.Controls.Add(txtImagePath);
            hu.Controls.Add(label6);
            hu.Controls.Add(chkTrangThai);
            hu.Controls.Add(txtGia);
            hu.Controls.Add(label5);
            hu.Controls.Add(cmbDanhMuc);
            hu.Controls.Add(label4);
            hu.Controls.Add(txtTenMon);
            hu.Controls.Add(label3);
            hu.Controls.Add(txtMaMon);
            hu.Controls.Add(label2);
            hu.Controls.Add(btnChonAnh);
            hu.Controls.Add(picMonAn);
            hu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hu.Location = new Point(12, 6);
            hu.Name = "hu";
            hu.Size = new Size(365, 719);
            hu.TabIndex = 0;
            hu.TabStop = false;
            hu.Text = "🍽️ THÔNG TIN MÓN ĂN ";
            hu.Enter += hu_Enter;
            // 
            // txtImagePath
            // 
            txtImagePath.Location = new Point(31, 299);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(300, 34);
            txtImagePath.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(31, 670);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 11;
            label6.Text = "Trạng Thái:";
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = CheckState.Checked;
            chkTrangThai.ForeColor = Color.FromArgb(76, 175, 80);
            chkTrangThai.Location = new Point(172, 664);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(159, 32);
            chkTrangThai.TabIndex = 10;
            chkTrangThai.Text = "✅ Đang bán";
            chkTrangThai.UseVisualStyleBackColor = true;
            chkTrangThai.CheckedChanged += chkTrangThai_CheckedChanged;
            // 
            // txtGia
            // 
            txtGia.Location = new Point(31, 612);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(300, 34);
            txtGia.TabIndex = 9;
            txtGia.TextAlign = HorizontalAlignment.Right;
            txtGia.TextChanged += txtGia_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 577);
            label5.Name = "label5";
            label5.Size = new Size(130, 23);
            label5.TabIndex = 8;
            label5.Text = "Giá bán (VNĐ):";
            // 
            // cmbDanhMuc
            // 
            cmbDanhMuc.FormattingEnabled = true;
            cmbDanhMuc.Location = new Point(31, 526);
            cmbDanhMuc.Name = "cmbDanhMuc";
            cmbDanhMuc.Size = new Size(300, 36);
            cmbDanhMuc.TabIndex = 7;
            cmbDanhMuc.SelectedIndexChanged += cmbDanhMuc_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 490);
            label4.Name = "label4";
            label4.Size = new Size(96, 23);
            label4.TabIndex = 6;
            label4.Text = "Danh mục:";
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(31, 441);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(300, 34);
            txtTenMon.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(34, 415);
            label3.Name = "label3";
            label3.Size = new Size(83, 23);
            label3.TabIndex = 4;
            label3.Text = "Tên món:";
            // 
            // txtMaMon
            // 
            txtMaMon.Location = new Point(31, 378);
            txtMaMon.Name = "txtMaMon";
            txtMaMon.Size = new Size(300, 34);
            txtMaMon.TabIndex = 3;
            txtMaMon.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 352);
            label2.Name = "label2";
            label2.Size = new Size(86, 23);
            label2.TabIndex = 2;
            label2.Text = "Mã món: ";
            label2.Click += label2_Click;
            // 
            // btnChonAnh
            // 
            btnChonAnh.BackColor = Color.Sienna;
            btnChonAnh.FlatStyle = FlatStyle.Flat;
            btnChonAnh.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(111, 241);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(144, 38);
            btnChonAnh.TabIndex = 1;
            btnChonAnh.Text = "📷 Chọn Hình";
            btnChonAnh.UseVisualStyleBackColor = false;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // picMonAn
            // 
            picMonAn.BackColor = Color.FromArgb(240, 237, 230);
            picMonAn.BorderStyle = BorderStyle.Fixed3D;
            picMonAn.Location = new Point(31, 35);
            picMonAn.Name = "picMonAn";
            picMonAn.Size = new Size(300, 200);
            picMonAn.SizeMode = PictureBoxSizeMode.StretchImage;
            picMonAn.TabIndex = 0;
            picMonAn.TabStop = false;
            picMonAn.Click += picMonAn_Click;
            // 
            // flowMenuCards
            // 
            flowMenuCards.AutoScroll = true;
            flowMenuCards.Controls.Add(dataGridView1);
            flowMenuCards.Dock = DockStyle.Fill;
            flowMenuCards.Location = new Point(20, 84);
            flowMenuCards.Name = "flowMenuCards";
            flowMenuCards.Padding = new Padding(10);
            flowMenuCards.Size = new Size(738, 747);
            flowMenuCards.TabIndex = 1;
            flowMenuCards.Paint += flowMenuCards_Paint;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Cornsilk;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 13);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(722, 731);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panelSearchMenu
            // 
            panelSearchMenu.Controls.Add(btntimkiem);
            panelSearchMenu.Controls.Add(txttimkiem);
            panelSearchMenu.Controls.Add(label7);
            panelSearchMenu.Dock = DockStyle.Top;
            panelSearchMenu.Location = new Point(20, 20);
            panelSearchMenu.Name = "panelSearchMenu";
            panelSearchMenu.Padding = new Padding(15);
            panelSearchMenu.Size = new Size(738, 64);
            panelSearchMenu.TabIndex = 0;
            // 
            // btntimkiem
            // 
            btntimkiem.BackColor = Color.Blue;
            btntimkiem.FlatStyle = FlatStyle.Flat;
            btntimkiem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btntimkiem.ForeColor = Color.White;
            btntimkiem.Location = new Point(615, 13);
            btntimkiem.Name = "btntimkiem";
            btntimkiem.Size = new Size(105, 35);
            btntimkiem.TabIndex = 15;
            btntimkiem.Text = "Tìm kiếm";
            btntimkiem.UseVisualStyleBackColor = false;
            btntimkiem.Click += button6_Click;
            // 
            // txttimkiem
            // 
            txttimkiem.Location = new Point(182, 18);
            txttimkiem.Name = "txttimkiem";
            txttimkiem.PlaceholderText = "Nhập tên món, danh mục...";
            txttimkiem.Size = new Size(400, 27);
            txttimkiem.TabIndex = 12;
            txttimkiem.TextChanged += txttimkiem_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(15, 20);
            label7.Name = "label7";
            label7.Size = new Size(161, 23);
            label7.TabIndex = 12;
            label7.Text = "🔍 Tìm kiếm món:";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // MEnu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 246, 240);
            ClientSize = new Size(1182, 967);
            Controls.Add(splitMainMenu);
            Controls.Add(panelHeaderMenu);
            ForeColor = Color.FromArgb(205, 186, 150);
            MinimumSize = new Size(1200, 700);
            Name = "MEnu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🍽️ Quản Lý Thực Đơn";
            Load += MEnu_Load;
            panelHeaderMenu.ResumeLayout(false);
            panelHeaderMenu.PerformLayout();
            panelCategoryTabs.ResumeLayout(false);
            splitMainMenu.Panel1.ResumeLayout(false);
            splitMainMenu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMainMenu).EndInit();
            splitMainMenu.ResumeLayout(false);
            panelButtonsMenu.ResumeLayout(false);
            hu.ResumeLayout(false);
            hu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMonAn).EndInit();
            flowMenuCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelSearchMenu.ResumeLayout(false);
            panelSearchMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeaderMenu;
        private Label label1;
        private Panel panelCategoryTabs;
        private Button btnTabCoffee;
        private Button btnTabAll;
        private Button btnTabSnack;
        private Button btnTabCake;
        private Button btnTabTea;
        private SplitContainer splitMainMenu;
        private GroupBox hu;
        private PictureBox picMonAn;
        private Label label2;
        private Button btnChonAnh;
        private TextBox txtMaMon;
        private Label label4;
        private TextBox txtTenMon;
        private Label label3;
        private CheckBox chkTrangThai;
        private TextBox txtGia;
        private Label label5;
        private ComboBox cmbDanhMuc;
        private Panel panelButtonsMenu;
        private Button btnxoa;
        private Label label6;
        private Button btnluu;
        private Panel panelSearchMenu;
        private Label label7;
        private Button btntimkiem;
        private TextBox txttimkiem;
        private OpenFileDialog openFileDialog1;
        private TextBox txtImagePath;
        private FlowLayoutPanel flowMenuCards;
        private DataGridView dataGridView1;
        private Button btnhuy;
    }
}