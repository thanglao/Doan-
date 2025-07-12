namespace DoAn11
{
    partial class banhang
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            openFileDialog1 = new OpenFileDialog();
            panelHeader = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            panelHeaderDH = new Panel();
            label10 = new Label();
            panelMain = new Panel();
            panel4 = new Panel();
            btngiam = new Button();
            btntang = new Button();
            btnxoa = new Button();
            btnthem = new Button();
            btnthanhtoan = new Button();
            txttongtien = new TextBox();
            txtchietkhau = new TextBox();
            label12 = new Label();
            label11 = new Label();
            dataGridViewHoaDon = new DataGridView();
            label9 = new Label();
            panel2 = new Panel();
            btnban16 = new Button();
            btnban15 = new Button();
            btnban14 = new Button();
            btnban13 = new Button();
            btnban12 = new Button();
            btnban11 = new Button();
            btnban10 = new Button();
            btnban9 = new Button();
            btnban8 = new Button();
            btnban7 = new Button();
            btnban6 = new Button();
            btnban5 = new Button();
            btnban4 = new Button();
            btnban3 = new Button();
            btnban2 = new Button();
            btnban1 = new Button();
            panel1 = new Panel();
            label4 = new Label();
            label5 = new Label();
            panelHeader.SuspendLayout();
            panelHeaderDH.SuspendLayout();
            panelMain.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoaDon).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Lime;
            panelHeader.Controls.Add(panelHeaderDH);
            panelHeader.CustomizableEdges = customizableEdges1;
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelHeader.Size = new Size(1316, 94);
            panelHeader.TabIndex = 0;
            // 
            // panelHeaderDH
            // 
            panelHeaderDH.BackColor = Color.FromArgb(52, 31, 19);
            panelHeaderDH.Controls.Add(label10);
            panelHeaderDH.Dock = DockStyle.Top;
            panelHeaderDH.Location = new Point(0, 0);
            panelHeaderDH.Name = "panelHeaderDH";
            panelHeaderDH.Size = new Size(1316, 95);
            panelHeaderDH.TabIndex = 2;
            panelHeaderDH.Paint += panelHeaderDH_Paint;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Goldenrod;
            label10.Location = new Point(35, 27);
            label10.Name = "label10";
            label10.Size = new Size(409, 82);
            label10.TabIndex = 0;
            label10.Text = "☕ QUẢN LÝ QUÁN CÀ PHÊ\r\n\r\n";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.Snow;
            panelMain.Controls.Add(panel4);
            panelMain.Controls.Add(panel2);
            panelMain.Controls.Add(panel1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 94);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(20);
            panelMain.Size = new Size(1316, 781);
            panelMain.TabIndex = 2;
            panelMain.Paint += panelMain_Paint;
            // 
            // panel4
            // 
            panel4.Controls.Add(btngiam);
            panel4.Controls.Add(btntang);
            panel4.Controls.Add(btnxoa);
            panel4.Controls.Add(btnthem);
            panel4.Controls.Add(btnthanhtoan);
            panel4.Controls.Add(txttongtien);
            panel4.Controls.Add(txtchietkhau);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(dataGridViewHoaDon);
            panel4.Controls.Add(label9);
            panel4.Location = new Point(618, 30);
            panel4.Name = "panel4";
            panel4.Size = new Size(675, 604);
            panel4.TabIndex = 9;
            // 
            // btngiam
            // 
            btngiam.BackColor = Color.SeaShell;
            btngiam.Location = new Point(570, 315);
            btngiam.Name = "btngiam";
            btngiam.Size = new Size(94, 34);
            btngiam.TabIndex = 27;
            btngiam.Text = "Giảm";
            btngiam.UseVisualStyleBackColor = false;
            btngiam.Click += btngiam_Click_1;
            // 
            // btntang
            // 
            btntang.BackColor = SystemColors.ScrollBar;
            btntang.Location = new Point(453, 315);
            btntang.Name = "btntang";
            btntang.Size = new Size(94, 34);
            btntang.TabIndex = 26;
            btntang.Text = "Tăng";
            btntang.UseVisualStyleBackColor = false;
            btntang.Click += btntang_Click_1;
            // 
            // btnxoa
            // 
            btnxoa.BackColor = Color.Red;
            btnxoa.Location = new Point(326, 315);
            btnxoa.Name = "btnxoa";
            btnxoa.Size = new Size(94, 34);
            btnxoa.TabIndex = 25;
            btnxoa.Text = "Xóa";
            btnxoa.UseVisualStyleBackColor = false;
            btnxoa.Click += button2_Click_2;
            // 
            // btnthem
            // 
            btnthem.BackColor = Color.SpringGreen;
            btnthem.Location = new Point(202, 315);
            btnthem.Name = "btnthem";
            btnthem.Size = new Size(94, 34);
            btnthem.TabIndex = 24;
            btnthem.Text = "Thêm";
            btnthem.UseVisualStyleBackColor = false;
            btnthem.Click += btnthem_Click_1;
            // 
            // btnthanhtoan
            // 
            btnthanhtoan.BackColor = Color.FromArgb(76, 175, 80);
            btnthanhtoan.Location = new Point(514, 402);
            btnthanhtoan.Name = "btnthanhtoan";
            btnthanhtoan.Size = new Size(133, 104);
            btnthanhtoan.TabIndex = 19;
            btnthanhtoan.Text = "Thanh toán";
            btnthanhtoan.UseVisualStyleBackColor = false;
            btnthanhtoan.Click += btnthanhtoan_Click;
            // 
            // txttongtien
            // 
            txttongtien.Location = new Point(178, 462);
            txttongtien.Multiline = true;
            txttongtien.Name = "txttongtien";
            txttongtien.Size = new Size(293, 33);
            txttongtien.TabIndex = 23;
            // 
            // txtchietkhau
            // 
            txtchietkhau.Location = new Point(178, 407);
            txtchietkhau.Name = "txtchietkhau";
            txtchietkhau.Size = new Size(293, 30);
            txtchietkhau.TabIndex = 22;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(61, 475);
            label12.Name = "label12";
            label12.Size = new Size(90, 23);
            label12.TabIndex = 21;
            label12.Text = "Tổng Tiền";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(61, 414);
            label11.Name = "label11";
            label11.Size = new Size(97, 23);
            label11.TabIndex = 19;
            label11.Text = "Chiết Khấu";
            // 
            // dataGridViewHoaDon
            // 
            dataGridViewHoaDon.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHoaDon.Location = new Point(13, 41);
            dataGridViewHoaDon.Name = "dataGridViewHoaDon";
            dataGridViewHoaDon.RowHeadersWidth = 51;
            dataGridViewHoaDon.Size = new Size(651, 245);
            dataGridViewHoaDon.TabIndex = 20;
            dataGridViewHoaDon.CellContentClick += dataGridViewHoaDon_CellContentClick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.DeepSkyBlue;
            label9.Location = new Point(273, 10);
            label9.Name = "label9";
            label9.Size = new Size(159, 28);
            label9.TabIndex = 19;
            label9.Text = "Bàn đang chọn:";
            label9.Click += label9_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnban16);
            panel2.Controls.Add(btnban15);
            panel2.Controls.Add(btnban14);
            panel2.Controls.Add(btnban13);
            panel2.Controls.Add(btnban12);
            panel2.Controls.Add(btnban11);
            panel2.Controls.Add(btnban10);
            panel2.Controls.Add(btnban9);
            panel2.Controls.Add(btnban8);
            panel2.Controls.Add(btnban7);
            panel2.Controls.Add(btnban6);
            panel2.Controls.Add(btnban5);
            panel2.Controls.Add(btnban4);
            panel2.Controls.Add(btnban3);
            panel2.Controls.Add(btnban2);
            panel2.Controls.Add(btnban1);
            panel2.Location = new Point(6, 186);
            panel2.Name = "panel2";
            panel2.Size = new Size(604, 701);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // btnban16
            // 
            btnban16.BackColor = Color.DodgerBlue;
            btnban16.ForeColor = Color.Snow;
            btnban16.Location = new Point(468, 386);
            btnban16.Name = "btnban16";
            btnban16.Size = new Size(111, 75);
            btnban16.TabIndex = 15;
            btnban16.Text = "Bàn 16";
            btnban16.UseVisualStyleBackColor = false;
            btnban16.Click += btnban16_Click;
            // 
            // btnban15
            // 
            btnban15.BackColor = Color.DodgerBlue;
            btnban15.ForeColor = Color.Snow;
            btnban15.Location = new Point(324, 386);
            btnban15.Name = "btnban15";
            btnban15.Size = new Size(111, 75);
            btnban15.TabIndex = 14;
            btnban15.Text = "Bàn 15";
            btnban15.UseVisualStyleBackColor = false;
            // 
            // btnban14
            // 
            btnban14.BackColor = Color.DodgerBlue;
            btnban14.ForeColor = Color.Snow;
            btnban14.Location = new Point(165, 386);
            btnban14.Name = "btnban14";
            btnban14.Size = new Size(111, 75);
            btnban14.TabIndex = 13;
            btnban14.Text = "Bàn 14";
            btnban14.UseVisualStyleBackColor = false;
            // 
            // btnban13
            // 
            btnban13.BackColor = Color.DodgerBlue;
            btnban13.ForeColor = Color.Snow;
            btnban13.Location = new Point(18, 386);
            btnban13.Name = "btnban13";
            btnban13.Size = new Size(111, 75);
            btnban13.TabIndex = 12;
            btnban13.Text = "Bàn 13";
            btnban13.UseVisualStyleBackColor = false;
            // 
            // btnban12
            // 
            btnban12.BackColor = Color.DodgerBlue;
            btnban12.ForeColor = Color.Snow;
            btnban12.Location = new Point(468, 258);
            btnban12.Name = "btnban12";
            btnban12.Size = new Size(111, 75);
            btnban12.TabIndex = 11;
            btnban12.Text = "Bàn 12";
            btnban12.UseVisualStyleBackColor = false;
            // 
            // btnban11
            // 
            btnban11.BackColor = Color.DodgerBlue;
            btnban11.ForeColor = Color.Snow;
            btnban11.Location = new Point(324, 258);
            btnban11.Name = "btnban11";
            btnban11.Size = new Size(111, 75);
            btnban11.TabIndex = 10;
            btnban11.Text = "Bàn 11";
            btnban11.UseVisualStyleBackColor = false;
            // 
            // btnban10
            // 
            btnban10.BackColor = Color.DodgerBlue;
            btnban10.ForeColor = Color.Snow;
            btnban10.Location = new Point(165, 258);
            btnban10.Name = "btnban10";
            btnban10.Size = new Size(111, 75);
            btnban10.TabIndex = 9;
            btnban10.Text = "Bàn 10";
            btnban10.UseVisualStyleBackColor = false;
            // 
            // btnban9
            // 
            btnban9.BackColor = Color.DodgerBlue;
            btnban9.ForeColor = Color.Snow;
            btnban9.Location = new Point(18, 258);
            btnban9.Name = "btnban9";
            btnban9.Size = new Size(111, 75);
            btnban9.TabIndex = 8;
            btnban9.Text = "Bàn 9";
            btnban9.UseVisualStyleBackColor = false;
            // 
            // btnban8
            // 
            btnban8.BackColor = Color.DodgerBlue;
            btnban8.ForeColor = Color.Snow;
            btnban8.Location = new Point(468, 139);
            btnban8.Name = "btnban8";
            btnban8.Size = new Size(111, 75);
            btnban8.TabIndex = 7;
            btnban8.Text = "Bàn 8";
            btnban8.UseVisualStyleBackColor = false;
            btnban8.Click += btnban8_Click;
            // 
            // btnban7
            // 
            btnban7.BackColor = Color.DodgerBlue;
            btnban7.ForeColor = Color.Snow;
            btnban7.Location = new Point(324, 139);
            btnban7.Name = "btnban7";
            btnban7.Size = new Size(111, 75);
            btnban7.TabIndex = 6;
            btnban7.Text = "Bàn 7";
            btnban7.UseVisualStyleBackColor = false;
            btnban7.Click += btnban7_Click;
            // 
            // btnban6
            // 
            btnban6.BackColor = Color.DodgerBlue;
            btnban6.ForeColor = Color.Snow;
            btnban6.Location = new Point(165, 139);
            btnban6.Name = "btnban6";
            btnban6.Size = new Size(111, 75);
            btnban6.TabIndex = 5;
            btnban6.Text = "Bàn 6";
            btnban6.UseVisualStyleBackColor = false;
            btnban6.Click += btnban6_Click;
            // 
            // btnban5
            // 
            btnban5.BackColor = Color.DodgerBlue;
            btnban5.ForeColor = Color.Snow;
            btnban5.Location = new Point(18, 139);
            btnban5.Name = "btnban5";
            btnban5.Size = new Size(111, 75);
            btnban5.TabIndex = 4;
            btnban5.Text = "Bàn 5";
            btnban5.UseVisualStyleBackColor = false;
            btnban5.Click += btnban5_Click;
            // 
            // btnban4
            // 
            btnban4.BackColor = Color.DodgerBlue;
            btnban4.ForeColor = Color.Snow;
            btnban4.Location = new Point(468, 25);
            btnban4.Name = "btnban4";
            btnban4.Size = new Size(111, 75);
            btnban4.TabIndex = 3;
            btnban4.Text = "Bàn 4";
            btnban4.UseVisualStyleBackColor = false;
            btnban4.Click += btnban4_Click;
            // 
            // btnban3
            // 
            btnban3.BackColor = Color.DodgerBlue;
            btnban3.ForeColor = Color.Snow;
            btnban3.Location = new Point(324, 25);
            btnban3.Name = "btnban3";
            btnban3.Size = new Size(111, 75);
            btnban3.TabIndex = 2;
            btnban3.Text = "Bàn 3";
            btnban3.UseVisualStyleBackColor = false;
            btnban3.Click += btnban3_Click;
            // 
            // btnban2
            // 
            btnban2.BackColor = Color.DodgerBlue;
            btnban2.ForeColor = Color.Snow;
            btnban2.Location = new Point(165, 25);
            btnban2.Name = "btnban2";
            btnban2.Size = new Size(111, 75);
            btnban2.TabIndex = 1;
            btnban2.Text = "Bàn 2";
            btnban2.UseVisualStyleBackColor = false;
            btnban2.Click += button2_Click_1;
            // 
            // btnban1
            // 
            btnban1.BackColor = Color.DodgerBlue;
            btnban1.ForeColor = Color.Snow;
            btnban1.Location = new Point(18, 25);
            btnban1.Name = "btnban1";
            btnban1.Size = new Size(111, 75);
            btnban1.TabIndex = 0;
            btnban1.Text = "Bàn 1";
            btnban1.UseVisualStyleBackColor = false;
            btnban1.Click += btnban1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(164, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(280, 120);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint_2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(90, 20);
            label4.Name = "label4";
            label4.Size = new Size(165, 23);
            label4.TabIndex = 1;
            label4.Text = "Đơn Hàng Hôm Nay";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(81, 69);
            label5.TabIndex = 0;
            label5.Text = "📋";
            // 
            // banhang
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SandyBrown;
            ClientSize = new Size(1316, 875);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "banhang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ☕ Quản Lý Quán Cà Phê - Coffee Shop Management";
            Load += Form1_Load;
            panelHeader.ResumeLayout(false);
            panelHeaderDH.ResumeLayout(false);
            panelHeaderDH.PerformLayout();
            panelMain.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoaDon).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel panelHeader;
        private Panel panelMain;
        private Panel panel1;
        private Label label4;
        private Label label5;
        private Panel panelHeaderDH;
        private Label label10;
        private Panel panel2;
        private Button btnban1;
        private Button btnban16;
        private Button btnban15;
        private Button btnban14;
        private Button btnban13;
        private Button btnban12;
        private Button btnban11;
        private Button btnban10;
        private Button btnban9;
        private Button btnban8;
        private Button btnban7;
        private Button btnban6;
        private Button btnban5;
        private Button btnban4;
        private Button btnban3;
        private Button btnban2;
        private Panel panel4;
        private Label label9;
        private Label label12;
        private Label label11;
        private DataGridView dataGridViewHoaDon;
        private Button btnthanhtoan;
        private TextBox txttongtien;
        private TextBox txtchietkhau;
        private Button btnthem;
        private Button btnxoa;
        private Button btngiam;
        private Button btntang;
    }
}
