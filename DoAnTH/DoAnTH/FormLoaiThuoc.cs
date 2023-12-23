using DoAnTH.CXL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnTH
{
    public partial class FormLoaiThuoc : Form
    {
        readonly CXuLyLT xuly = new CXuLyLT();
        CLoaiThuoc LT = new CLoaiThuoc();
        ErrorProvider erp = new ErrorProvider();
        public FormLoaiThuoc()
        {
            InitializeComponent();
            HienThi();
        }
        void clear()
        {
            txtMa.Text = " ";
            txtTen.Text = " ";
        }
        private void HienThi()
        {
            dgvLoaiThuoc.DataSource = xuly.getALL().ToList();
            clear();
            dgvLoaiThuoc.ClearSelection();
        }
        private bool IsValidData()
        {
            erp.SetError(txtMa, "");
            erp.SetError(txtTen, "");
            bool problem = false;
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                erp.SetError(txtMa, "Không để trống!");
                problem = true;
            }
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                erp.SetError(txtTen, "Không để trống!");
                problem = true;
            }

            return !problem;
        }

        private void FormLoaiThuoc_Load(object sender, EventArgs e)
        {
            dgvLoaiThuoc.AutoGenerateColumns = false;
        }
        private CLoaiThuoc getLT()
        {
            CLoaiThuoc lt = new CLoaiThuoc();
            lt.MaLoaiThuoc = txtMa.Text;
            lt.TenLoaiThuoc = txtTen.Text;
            return lt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                CLoaiThuoc lt = getLT();
                xuly.them(lt);
                HienThi();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (LT == null)
            {
                MessageBox.Show("Chọn thông tin cần xóa ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!xuly.xoa(LT))
            {
                MessageBox.Show("Xoa that bai!");
            }
            HienThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                CLoaiThuoc newlt = getLT();
                if (!xuly.sua(newlt))
                {
                    MessageBox.Show("Sửa thất bại!");
                }
                HienThi();
            }
        }

        private void dgvLoaiThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                LT = (CLoaiThuoc)dgvLoaiThuoc.Rows[e.RowIndex].DataBoundItem;
                txtMa.Text = LT.MaLoaiThuoc.ToString();
                txtTen.Text = LT.TenLoaiThuoc.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Ma = txtTim.Text;
            List<CLoaiThuoc> lt = xuly.getLike(Ma);

            if (lt != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = lt;
                dgvLoaiThuoc.DataSource = bs;
            }
            else
            {
                MessageBox.Show("Không tìm thấy!");
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            dgvLoaiThuoc.DataSource = xuly.getALL().ToList();
        }
    }
}
