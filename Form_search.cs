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
    public partial class Form_search : Form
    {
        public Form_search()
        {
            InitializeComponent();
        }
        void initheadtitle()
        {
            dataGridView1.Columns[0].HeaderText = "学生编号";
            dataGridView1.Columns[1].HeaderText = "学生姓名";
            dataGridView1.Columns[2].HeaderText = "学生性别";
            dataGridView1.Columns[3].HeaderText = "学生年龄";
            dataGridView1.Columns[4].HeaderText = "出生日期";
            dataGridView1.Columns[5].HeaderText = "手机号码";
            dataGridView1.Columns[6].HeaderText = "家庭地址";
            dataGridView1.Columns[7].HeaderText = "电子邮箱";
            dataGridView1.Columns[8].HeaderText = "专   业";
        }

        private void cb_search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_searchtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cb_search.Text == string.Empty)
            {
                dataGridView1.DataSource = studentinfoBLL.getallstudentinfo();
                initheadtitle();
            }
            else
            {
                if (txt_searchtxt.Text != string.Empty)
                {
                    studentinfo studentsearch = new studentinfo();
                    switch (cb_search.SelectedIndex)
                    {
                        case 0: studentsearch.studentid = Int32.Parse(txt_searchtxt.Text); break;
                        case 1: studentsearch.Name = txt_searchtxt.Text; break;
                    }
                    dataGridView1.DataSource = studentinfoBLL.getstudentinfolist(studentsearch);
                    initheadtitle();
                }
                else MessageBox.Show("请输入要查询的" + cb_search.Text);
            }
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
