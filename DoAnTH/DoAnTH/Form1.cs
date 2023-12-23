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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bacSiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void benhNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void loaiThuocToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void thuocToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void phieuKhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CTruyCapDuLieu.khoiTao().docfile();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CTruyCapDuLieu.khoiTao().ghifile();
        }
    }
}