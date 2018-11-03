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
    public partial class Form_add : Form
    {
        public Form_add()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            studentinfo studentinfo = new studentinfo();
            studentinfo.studentid = Int32.Parse(txt_studengid.Text );
            studentinfo.Name = txt_name.Text;
            if (rb_man.Checked)
                studentinfo.sex = "男";
            else if (rb_woman.Checked)
                studentinfo.sex = "女";
            studentinfo.Age = Int32.Parse(txt_age.Text);
            studentinfo.Birthdate = DateTime.Parse(dt_birthdate.Text);
            studentinfo.Phone = txt_phone.Text;
            studentinfo.Email = txt_email.Text;
            studentinfo.Homeaddress = txt_homeaddress.Text;
            studentinfo.Profession = txt_profession.Text;
            if (studentinfoBLL.Addstudentinfo(studentinfo))
            { MessageBox.Show("添加成功！"); }
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
