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
    public partial class FormThuoc : Form
    {
        readonly CXulyT xulyT = new CXulyT();
        CThuoc T = new CThuoc();
        ErrorProvider erp = new ErrorProvider();
        readonly CXuLyLT xulyLT = new CXuLyLT();
        public FormThuoc()
        {
            InitializeComponent();
            HienThi();
            htcmb();
        }
       
        void clear()
        {
            txtMaThuoc.Text = " ";
            txtTenThuoc.Text = " ";
            txtTacDung.Text = " ";
            txtLieuDung.Text = " ";
            txtCachDung.Text = " ";
        }
        private void HienThi()
        {
            dgvThuoc.DataSource = xulyT.getALL().ToList();
            clear();
            dgvThuoc.ClearSelection();
        }
        private bool IsValidData()
        {
            erp.SetError(txtMaThuoc, "");
            erp.SetError(txtTenThuoc, "");
            erp.SetError(txtTacDung, "");
            erp.SetError(txtLieuDung, "");
            erp.SetError(txtCachDung, "");
            bool problem = false;
            if (string.IsNullOrWhiteSpace(txtMaThuoc.Text))
            {
                erp.SetError(txtMaThuoc, "Không để trống!");
                problem = true;
            }
            if (string.IsNullOrWhiteSpace(txtTenThuoc.Text))
            {
                erp.SetError(txtTenThuoc, "Không để trống!");
                problem = true;
            }
            if (string.IsNullOrWhiteSpace(txtTacDung.Text))
            {
                erp.SetError(txtTacDung, "Không để trống!");
                problem = true;
            }
            if (string.IsNullOrWhiteSpace(txtLieuDung.Text))
            {
                erp.SetError(txtLieuDung, "Không để trống!");
                problem = true;
            }
            if (string.IsNullOrWhiteSpace(txtCachDung.Text))
            {
                erp.SetError(txtCachDung, "Không để trống!");
                problem = true;
            }
            return !problem;
        }
        private CThuoc getT()
        {
            CThuoc t = new CThuoc();
            t.MaThuoc = txtMaThuoc.Text;
            t.TenThuoc = txtTenThuoc.Text;
            t.CachDung = txtCachDung.Text;
            t.LieuDung = txtLieuDung.Text;
            t.TacDung = txtTacDung.Text;
            string maLoaiThuoc = (string)cmbLoaiThuoc.SelectedValue;
            t.LoaiThuoc = xulyLT.getMa(maLoaiThuoc);
            return t;
        }
        private void htcmb()
        {

            cmbLoaiThuoc.DataSource = xulyLT.getALL();
            cmbLoaiThuoc.ValueMember = "MaLoaiThuoc";
            cmbLoaiThuoc.DisplayMember = "TenLoaiThuoc";
        }
        private void txtMaThuoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormThuoc_Load(object sender, EventArgs e)
        {
            htcmb();
            dgvThuoc.AutoGenerateColumns = false;
            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                CThuoc lt = getT();
                xulyT.them(lt);
                HienThi();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                CThuoc newt = getT();
                if (!xulyT.sua(newt))
                {
                    MessageBox.Show("Sửa thất bại!");
                }
                HienThi();
            }
        }

        private void dgvThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                T = (CThuoc)dgvThuoc.Rows[e.RowIndex].DataBoundItem;
                txtMaThuoc.Text = T.MaThuoc.ToString();
                txtTenThuoc.Text = T.TenThuoc.ToString();
                txtTacDung.Text = T.TacDung.ToString();
                txtLieuDung.Text = T.LieuDung.ToString();
                txtCachDung.Text = T.CachDung.ToString();
                cmbLoaiThuoc.SelectedItem = (T.LoaiThuoc);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (T == null)
            {
                MessageBox.Show(@"Chọn thông tin cần xóa ", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!xulyT.xoa(T))
            {
                MessageBox.Show("Xóa thất bại!");
            }
            HienThi();
        }

        private void buttonTim_Click(object sender, EventArgs e)
        {
            string Ma = txtTim.Text;
            CThuoc t = xulyT.getMa(Ma);
            if (t != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = t;
                dgvThuoc.DataSource = bs;
            }
            else
            {
                MessageBox.Show("Không tìm thấy!");
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            dgvThuoc.DataSource = xulyT.getALL().ToList();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTim.Text))
            {
                string Ma = txtTim.Text;
                List<CThuoc> bn = xulyT.getLike(Ma);
                BindingSource bs = new BindingSource();
                bs.DataSource = bn;
                dgvThuoc.DataSource = bs;
            }
            else
            {
                HienThi();
            }
        }
    }
    }

