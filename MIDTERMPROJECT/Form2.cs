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
    public partial class Form2 : Form
    {
        QUANLYLOPHOCEntities1 db = new QUANLYLOPHOCEntities1();
        public bool sua_checked;
        public bool them_checked;
        public string MASOSINHVIEN;



        public Form2()
        {
            InitializeComponent();
        }
        // Tạo phương thức vận chuyển từ form2 về form1
        public delegate void getsinhvien(string mssv, string hoten, string gioitinh, string email);
        public getsinhvien mysinhvien;
        // Tạo phương thức vận chuyển từ form2 về form1
        

     
        private void btLuu_Click(object sender, EventArgs e)
        {
           

            if (them_checked == true)
            {
                if (rbNam.Checked ==  true)
                {
                    // Đưa dữ liều từ form2 qua form 1
                    mysinhvien(txtMssv.Text,txtHoten.Text,rbNam.Text,txtEmail.Text);
                }
                else
                {
                    mysinhvien(txtMssv.Text, txtHoten.Text, rbNu.Text, txtEmail.Text);
                }
          
                
                this.Close();
                them_checked = false;


            }
            
            else if (sua_checked == true)
            {
                if (rbNam.Checked == true)
                {
                    mysinhvien(txtMssv.Text, txtHoten.Text, rbNam.Text, txtEmail.Text);
                }
                else
                {
                    mysinhvien(txtMssv.Text, txtHoten.Text, rbNu.Text, txtEmail.Text);
                }

                

            }
            
           
               


           



        }
        

        private void Form2_Load(object sender, EventArgs e)
        {
            if (sua_checked == true)
            {
                SINHVIEN sv = db.SINHVIENs.Where(c => c.MSSV.Equals(MASOSINHVIEN)).FirstOrDefault();
                txtEmail.Text = sv.EMAIL.Trim();
                txtHoten.Text = sv.HOTEN.Trim();
                txtMssv.Text = sv.MSSV.Trim();
                
                if(sv.GIOITINH.Trim() == "Nam")
                {
                    rbNam.Checked = true;
                }
                else if (sv.GIOITINH.Trim() == "Nữ")
                {
                    rbNu.Checked = true;
                }
                
            }
        }
    }
}
