namespace DoAn11.Forms
{
    partial class donhang
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
            panelHeaderDH = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            button3 = new Button();
            button1 = new Button();
            button4 = new Button();
            button5 = new Button();
            button2 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelDanhSachDH = new Panel();
            dgvChiTietMon = new DataGridView();
            panel3 = new Panel();
            label2 = new Label();
            panel1 = new Panel();
            dgvDanhSachDH = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            label3 = new Label();
            panelHeaderDH.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelDanhSachDH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietMon).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachDH).BeginInit();
            SuspendLayout();
            // 
            // panelHeaderDH
            // 
            panelHeaderDH.BackColor = Color.FromArgb(52, 31, 19);
            panelHeaderDH.Controls.Add(label1);
            panelHeaderDH.Dock = DockStyle.Top;
            panelHeaderDH.Location = new Point(0, 0);
            panelHeaderDH.Name = "panelHeaderDH";
            panelHeaderDH.Size = new Size(1146, 1000);
            panelHeaderDH.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Goldenrod;
            label1.Location = new Point(35, 27);
            label1.Name = "label1";
            label1.Size = new Size(372, 41);
            label1.TabIndex = 0;
            label1.Text = "📋 QUẢN LÝ ĐƠN HÀNG";
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(0, 101);
            panel2.Name = "panel2";
            panel2.Size = new Size(1588, 82);
            panel2.TabIndex = 1;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(33, 150, 243);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(329, 12);
            button3.Name = "button3";
            button3.Size = new Size(138, 40);
            button3.TabIndex = 3;
            button3.Text = "Đang chuẩn bị";
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Goldenrod;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(15, 12);
            button1.Name = "button1";
            button1.Size = new Size(127, 40);
            button1.TabIndex = 1;
            button1.Text = "Tất cả";
            button1.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(76, 175, 80);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(490, 12);
            button4.Name = "button4";
            button4.Size = new Size(138, 40);
            button4.TabIndex = 4;
            button4.Text = "Hoàn thành";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Red;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(650, 12);
            button5.Name = "button5";
            button5.Size = new Size(138, 40);
            button5.TabIndex = 5;
            button5.Text = "Đã hủy";
            button5.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 152, 0);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(166, 12);
            button2.Name = "button2";
            button2.Size = new Size(138, 40);
            button2.TabIndex = 2;
            button2.Text = "Chờ sử lý";
            button2.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(panelDanhSachDH, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 189);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1609, 762);
            tableLayoutPanel1.TabIndex = 2;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // panelDanhSachDH
            // 
            panelDanhSachDH.BackColor = Color.White;
            panelDanhSachDH.Controls.Add(dgvChiTietMon);
            panelDanhSachDH.Controls.Add(panel3);
            panelDanhSachDH.Dock = DockStyle.Bottom;
            panelDanhSachDH.Location = new Point(566, 3);
            panelDanhSachDH.Name = "panelDanhSachDH";
            panelDanhSachDH.Padding = new Padding(10);
            panelDanhSachDH.Size = new Size(557, 756);
            panelDanhSachDH.TabIndex = 0;
            // 
            // dgvChiTietMon
            // 
            dgvChiTietMon.BackgroundColor = Color.White;
            dgvChiTietMon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietMon.Location = new Point(3, 57);
            dgvChiTietMon.Name = "dgvChiTietMon";
            dgvChiTietMon.RowHeadersWidth = 51;
            dgvChiTietMon.Size = new Size(551, 238);
            dgvChiTietMon.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(248, 246, 240);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(557, 59);
            panel3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(143, 16);
            label2.Name = "label2";
            label2.Size = new Size(244, 28);
            label2.TabIndex = 2;
            label2.Text = "📄 CHI TIẾT ĐƠN HÀNG";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvDanhSachDH);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(557, 756);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // dgvDanhSachDH
            // 
            dgvDanhSachDH.BackgroundColor = Color.White;
            dgvDanhSachDH.BorderStyle = BorderStyle.None;
            dgvDanhSachDH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachDH.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgvDanhSachDH.EnableHeadersVisualStyles = false;
            dgvDanhSachDH.Location = new Point(0, 57);
            dgvDanhSachDH.Margin = new Padding(0, 40, 0, 0);
            dgvDanhSachDH.Name = "dgvDanhSachDH";
            dgvDanhSachDH.RowHeadersVisible = false;
            dgvDanhSachDH.RowHeadersWidth = 51;
            dgvDanhSachDH.Size = new Size(557, 714);
            dgvDanhSachDH.TabIndex = 3;
            // 
            // Column1
            // 
            Column1.HeaderText = "Mã ĐH";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 85;
            // 
            // Column2
            // 
            Column2.HeaderText = " Thời gian";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 120;
            // 
            // Column3
            // 
            Column3.HeaderText = "Khách hàng";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.HeaderText = "Tổng tiền";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 110;
            // 
            // Column5
            // 
            Column5.HeaderText = "Trạng thái";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 110;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(122, 16);
            label3.Name = "label3";
            label3.Size = new Size(282, 28);
            label3.TabIndex = 2;
            label3.Text = "📋 DANH SÁCH ĐƠN HÀNG";
            // 
            // donhang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 246, 240);
            ClientSize = new Size(1146, 953);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            Controls.Add(panelHeaderDH);
            Name = "donhang";
            Text = "📋 Quản Lý Đơn Hàng - Coffee";
            panelHeaderDH.ResumeLayout(false);
            panelHeaderDH.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panelDanhSachDH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTietMon).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachDH).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeaderDH;
        private Label label1;
        private Panel panel2;
        private Button button3;
        private Button button1;
        private Button button4;
        private Button button5;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelDanhSachDH;
        private Panel panel1;
        private DataGridView dgvDanhSachDH;
        private Label label3;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridView dgvChiTietMon;
        private Panel panel3;
        private Label label2;
    }
}