using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mycontracts
{
    public partial class Form_edit : Form
    {
        public int studentid_edit = 0;
        public Form_edit()
        {
            InitializeComponent();
            
        }
        public void initcontrol()
        {
            studentinfo studentinfo = studentinfoBLL.getstudentinfo(studentid_edit);
            if (studentinfo != null)
            {
                txt_stuengid.Text = studentinfo.studentid.ToString();
                txt_name.Text = studentinfo.Name;
                if (studentinfo.sex == "男")
                {
                    rb_man.Checked = true;
                    rb_woman.Checked = false;
                }
                else
                {
                    rb_woman.Checked = true;
                    rb_man.Checked = false;
                }
                txt_age.Text = studentinfo.Age.ToString();
                dt_birthdate.Text = studentinfo.Birthdate.ToString();
                txt_phone.Text = studentinfo.Phone;
                txt_email.Text = studentinfo.Email;
                txt_familyaddress.Text  = studentinfo.Homeaddress;
                txt_profession.Text = studentinfo.Profession;
            }
         }
        private void Form_edit_Load(object sender, EventArgs e)
        {
            initcontrol();
        }

        private void txt_stuengid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            studentinfo studentinfo = studentinfoBLL.getstudentinfo(studentid_edit);
            studentinfo.studentid = Int32.Parse(txt_stuengid.Text);
            studentinfo.Name = txt_name.Text;
            if (rb_man.Checked)
                studentinfo.sex = "男";
            else if (rb_woman.Checked)
                studentinfo.sex = "女";
            studentinfo.Age = Int32.Parse(txt_age.Text);
            studentinfo.Birthdate = DateTime.Parse(dt_birthdate.Text);
            studentinfo.Phone = txt_phone.Text;
            studentinfo.Email = txt_email.Text;
            studentinfo.Homeaddress = txt_familyaddress.Text;
            studentinfo.Profession = txt_profession.Text;
            if (studentinfoBLL.UpdateStudentinfo(studentinfo))
                MessageBox.Show("修改成功！");
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
        }
    }

