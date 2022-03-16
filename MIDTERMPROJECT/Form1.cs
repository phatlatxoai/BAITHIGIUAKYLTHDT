using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDTERMPROJECT
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// liên kết vỡi database tên Quanlylophoc as db
        /// </summary>
        QUANLYLOPHOCEntities1 db = new QUANLYLOPHOCEntities1();
        /// <summary>
        ///Tạo biến toàn cục MASOSINHVIEN
        /// </summary>
        public string MASOSINHVIEN;

        // Hàm thêm sinh viên vào trong CSDL sau đó reload lại trên datagv
        void addsv(string mssv, string hoten, string gioitinh, string email)
        {
            SINHVIEN sv = new SINHVIEN();
            sv.MSSV = mssv.Trim();
            sv.EMAIL = email.Trim();
            sv.HOTEN = hoten.Trim();
            sv.GIOITINH = gioitinh.Trim();
            db.SINHVIENs.Add(sv);
            db.SaveChanges();
            dataGridView1.DataSource = db.SINHVIENs.ToList();
        }
        // Hàm sửa thông tin sinh viên ở trong CSDL sau đó reload lại trên datagv
        void updatesv(string mssv, string hoten, string gioitinh, string email)
        {
            SINHVIEN sv = db.SINHVIENs.Where(c => c.MSSV == mssv).FirstOrDefault();
            sv.HOTEN = hoten;
            sv.EMAIL = email;
            sv.GIOITINH= gioitinh;
            db.SaveChanges();
            dataGridView1.DataSource = db.SINHVIENs.ToList();
        }
        // xóa thông sinh viên lưu ý nhớ đưa vào tham số là mã số sinh viên
        void deletesv(string mssv)
        {
            SINHVIEN mysv = db.SINHVIENs.Where(c => c.MSSV.Equals(mssv)).FirstOrDefault();
            db.SINHVIENs.Remove(mysv);
            db.SaveChanges();
            dataGridView1.DataSource = db.SINHVIENs.ToList();
        }
        public Form1()
        {
            InitializeComponent();
        }

        // hàm lấy mã số sinh viên cell được click trong dtgv sau đó gán cho biến toàn cục MASOSINHVIEN
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MASOSINHVIEN = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        // hiện data vào làm gtdv
        private void Form1_Load(object sender, EventArgs e)

        {
            dataGridView1.DataSource = db.SINHVIENs.ToList();

        }
        
        // event thêm
        private void btThem_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2();
            form2.them_checked = true;// gán biên tên them)checked của form 2 thành True.  để nhận biết khi thêm
            form2.mysinhvien = new Form2.getsinhvien(addsv);// Nhận dữ liệu form2 đưa vào hàm addsv
            form2.ShowDialog();



        }
      
        // event sửa
        private void btSua_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.sua_checked = true;// gán biên tên sua_checked của form 2 thành True.  để nhận biết khi sửa
            form2.MASOSINHVIEN = MASOSINHVIEN;
            form2.mysinhvien = new Form2.getsinhvien(updatesv);// Nhận dữ liệu form2 đưa vào hàm updatesv
            form2.ShowDialog();





        }
        //event xóa
        private void btXoa_Click(object sender, EventArgs e)
        {
            deletesv(MASOSINHVIEN);
        }
    }
}
