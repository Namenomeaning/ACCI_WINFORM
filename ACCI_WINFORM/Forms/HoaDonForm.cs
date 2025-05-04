using ACCI_WINFORM.BUS;
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ACCI_WINFORM.Forms
{
    public partial class HoaDonForm : Form
    {
        private readonly HoaDonBUS hoaDonBUS = new HoaDonBUS();
        private readonly ChiTietHoaDonBUS chiTietHoaDonBUS = new ChiTietHoaDonBUS();
        private readonly DanhGiaBUS danhGiaBUS = new DanhGiaBUS();
        private readonly NhanVienBUS nhanVienBUS = new NhanVienBUS();

        private HoaDon currentHoaDon;
        private List<ChiTietHoaDon> chiTietHoaDons;

        public HoaDonForm(string maHoaDon)
        {
            InitializeComponent();
            LoadHoaDonData(maHoaDon);
        }

        private void HoaDonForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            // Configure DataGridView
            dgvChiTietHoaDon.AutoGenerateColumns = false;

            if (dgvChiTietHoaDon.Columns.Count == 0)
            {
                dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "MaDanhGia",
                    HeaderText = "Mã đánh giá",
                    DataPropertyName = "MaDanhGia",
                    Width = 100
                });
                dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TenDanhGia",
                    HeaderText = "Tên đánh giá",
                    DataPropertyName = "TenDanhGia",
                    Width = 200
                });
                dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "SoLuong",
                    HeaderText = "Số lượng",
                    DataPropertyName = "SoLuong",
                    Width = 80
                });
                dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "DonGia",
                    HeaderText = "Đơn giá",
                    DataPropertyName = "DonGia",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });
                dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ThanhTien",
                    HeaderText = "Thành tiền",
                    DataPropertyName = "ThanhTien",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });
            }
        }

        private void LoadHoaDonData(string maHoaDon)
        {
            try
            {
                // Fetch invoice data
                currentHoaDon = hoaDonBUS.LayHoaDon(maHoaDon);
                if (currentHoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                DisplayHoaDonInfo();

                // Fetch invoice details
                chiTietHoaDons = chiTietHoaDonBUS.LayDSChiTietHoaDon(maHoaDon);
                if (chiTietHoaDons != null && chiTietHoaDons.Count > 0)
                {
                    DisplayChiTietHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayHoaDonInfo()
        {
            // Display invoice header information
            txtMaHoaDon.Text = currentHoaDon.MaHoaDon;
            txtMaPhieuDK.Text = currentHoaDon.MaPhieuDK ?? "(không có)";

            // Get NhanVien name
            var nhanVien = nhanVienBUS.LayNhanVien(currentHoaDon.MaNV_KeToan);
            txtNhanVienLap.Text = nhanVien != null ? $"{nhanVien.HoTen} ({nhanVien.MaNhanVien})" : currentHoaDon.MaNV_KeToan;

            txtNgayLap.Text = currentHoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm");
            txtTrangThai.Text = GetTrangThaiText(currentHoaDon.TrangThaiTT);

            // Format currency values
            txtTongTienGoc.Text = string.Format("{0:N0} VND", currentHoaDon.TongTienGoc);
            txtSoTienGiam.Text = string.Format("{0:N0} VND", currentHoaDon.SoTienGiam);
            txtTongThuText.Text = string.Format("{0:N0} VND", currentHoaDon.TongThu);

            // Additional payment information
            if (currentHoaDon.NgayThanhToan.HasValue)
            {
                txtNgayThanhToan.Text = currentHoaDon.NgayThanhToan.Value.ToString("dd/MM/yyyy HH:mm");
                txtPhuongThucTT.Text = GetPaymentMethodText(currentHoaDon.PhuongThuc);
                txtMaGiaoDich.Text = !string.IsNullOrEmpty(currentHoaDon.MaGiaoDich) ? currentHoaDon.MaGiaoDich : "(không có)";
            }
            else
            {
                txtNgayThanhToan.Text = "(chưa thanh toán)";
                txtPhuongThucTT.Text = "(chưa có)";
                txtMaGiaoDich.Text = "(chưa có)";
            }

            // Show/hide payment button based on payment status
            btnThanhToan.Visible = currentHoaDon.TrangThaiTT != "DaTT";
        }

        private string GetTrangThaiText(string trangThaiTT)
        {
            return trangThaiTT switch
            {
                "ChuaTT" => "Chưa thanh toán",
                "DaTT" => "Đã thanh toán",
                "Huy" => "Đã hủy",
                _ => trangThaiTT
            };
        }

        private string GetPaymentMethodText(string phuongThuc)
        {
            return phuongThuc switch
            {
                "TienMat" => "Tiền mặt",
                "ChuyenKhoan" => "Chuyển khoản",
                _ => phuongThuc ?? "(không có)"
            };
        }

        // Helper class for grouped items
        private class ChiTietTongHop
        {
            public string MaDanhGia { get; set; }
            public string TenDanhGia { get; set; }
            public int SoLuong { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien { get; set; }
        }

        private void DisplayChiTietHoaDon()
        {
            try
            {
                // Create a dictionary to group items by MaDanhGia
                Dictionary<string, ChiTietTongHop> groupedItems = new Dictionary<string, ChiTietTongHop>();

                foreach (var chiTiet in chiTietHoaDons)
                {
                    if (!string.IsNullOrEmpty(chiTiet.MaDanhGia))
                    {
                        string maDanhGia = chiTiet.MaDanhGia;

                        // Get the DanhGia information if we haven't already
                        if (!groupedItems.ContainsKey(maDanhGia))
                        {
                            var danhGia = danhGiaBUS.LayDanhGia(maDanhGia);
                            string tenDanhGia = danhGia != null ? danhGia.TenDanhGia : "(không xác định)";

                            groupedItems[maDanhGia] = new ChiTietTongHop
                            {
                                MaDanhGia = maDanhGia,
                                TenDanhGia = tenDanhGia,
                                SoLuong = 0,
                                DonGia = chiTiet.DonGia,
                                ThanhTien = 0
                            };
                        }

                        // Add this item's quantity and amount
                        groupedItems[maDanhGia].SoLuong += chiTiet.SoLuong;
                        groupedItems[maDanhGia].ThanhTien += chiTiet.ThanhTien;
                    }
                }

                // Create a DataTable with aggregated data
                DataTable dt = new DataTable();
                dt.Columns.Add("MaDanhGia", typeof(string));
                dt.Columns.Add("TenDanhGia", typeof(string));
                dt.Columns.Add("SoLuong", typeof(int));
                dt.Columns.Add("DonGia", typeof(decimal));
                dt.Columns.Add("ThanhTien", typeof(decimal));

                // Add grouped data to DataTable
                foreach (var item in groupedItems.Values)
                {
                    dt.Rows.Add(
                        item.MaDanhGia,
                        item.TenDanhGia,
                        item.SoLuong,
                        item.DonGia,
                        item.ThanhTien
                    );
                }

                dgvChiTietHoaDon.DataSource = dt;

                // Add a total row at the bottom of the DataGridView
                if (dt.Rows.Count > 0)
                {
                    decimal tongTien = groupedItems.Values.Sum(item => item.ThanhTien);

                    // You could add a summary label below the grid instead of this approach
                    // For example: lblTongCong.Text = $"Tổng cộng: {string.Format("{0:N0} VND", tongTien)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị chi tiết hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (currentHoaDon.TrangThaiTT == "DaTT")
            {
                MessageBox.Show("Hóa đơn này đã được thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Create a payment form to get payment details
            using (var paymentForm = new Form())
            {
                paymentForm.Text = "Thanh toán hóa đơn";
                paymentForm.Size = new Size(400, 250);
                paymentForm.StartPosition = FormStartPosition.CenterParent;
                paymentForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                paymentForm.MaximizeBox = false;
                paymentForm.MinimizeBox = false;

                var lblPaymentMethod = new Label { Text = "Phương thức thanh toán:", Location = new Point(20, 20) };
                var cboPaymentMethod = new ComboBox
                {
                    Location = new Point(180, 17),
                    Size = new Size(180, 25),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cboPaymentMethod.Items.AddRange(new string[] { "TienMat", "ChuyenKhoan" });
                cboPaymentMethod.SelectedIndex = 0;

                var lblTransactionId = new Label { Text = "Mã giao dịch:", Location = new Point(20, 60) };
                var txtTransactionId = new TextBox { Location = new Point(180, 57), Size = new Size(180, 25) };
                txtTransactionId.Enabled = false; // Initially disabled for cash payment

                cboPaymentMethod.SelectedIndexChanged += (s, args) =>
                {
                    txtTransactionId.Enabled = cboPaymentMethod.SelectedItem.ToString() == "ChuyenKhoan";
                };

                var btnConfirm = new Button
                {
                    Text = "Xác nhận",
                    Location = new Point(150, 150),
                    Size = new Size(100, 30),
                    DialogResult = DialogResult.OK
                };

                paymentForm.Controls.AddRange(new Control[]
                {
                    lblPaymentMethod, cboPaymentMethod,
                    lblTransactionId, txtTransactionId,
                    btnConfirm
                });

                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    string phuongThuc = cboPaymentMethod.SelectedItem.ToString();
                    string maGiaoDich = phuongThuc == "ChuyenKhoan" ? txtTransactionId.Text : null;

                    if (phuongThuc == "ChuyenKhoan" && string.IsNullOrWhiteSpace(maGiaoDich))
                    {
                        MessageBox.Show("Vui lòng nhập mã giao dịch cho phương thức chuyển khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Update payment status
                    if (hoaDonBUS.CapNhatThanhToan(currentHoaDon.MaHoaDon, phuongThuc, maGiaoDich))
                    {
                        MessageBox.Show("Thanh toán hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHoaDonData(currentHoaDon.MaHoaDon); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
