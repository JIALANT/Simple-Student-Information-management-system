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
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            initcontracts(); 
        }
        void initcontracts()
            {
                if (System.IO.File.Exists(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\xml\Students.xml"))
                {
                    dataGridView1 .DataSource =studentinfoBLL .getallstudentinfo ();
                }
                else 
                {
                    studentinfoBLL .CreateStudentXml ();
                    dataGridView1 .DataSource =studentinfoBLL .getallstudentinfo ();
                }
            dataGridView1 .Columns [0].HeaderText="学生编号";
            dataGridView1 .Columns [1].HeaderText="学生姓名";
            dataGridView1 .Columns [2].HeaderText="学生性别";
            dataGridView1 .Columns [3].HeaderText="学生年龄";
            dataGridView1 .Columns [4].HeaderText="出生日期";
            dataGridView1 .Columns [5].HeaderText="手机号码";
            dataGridView1 .Columns [6].HeaderText="家庭地址";
            dataGridView1 .Columns [7].HeaderText="电子邮箱";
            dataGridView1 .Columns [8].HeaderText="专   业";   
                }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolstrip_add_Click(object sender, EventArgs e)
        {
            Form_add formadd = new Form_add();
            formadd.ShowDialog();
            initcontracts();
        }

        private void toolStrip_search_Click(object sender, EventArgs e)
        {
            Form_search formsearch = new Form_search();
            formsearch.ShowDialog();
        }

        private void toolStrip_delete_Click(object sender, EventArgs e)
        {
         if (dataGridView1.SelectedRows.Count == 1)
         {
             if (MessageBox.Show("确定要删除此学生的信息？", "确认信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
             MessageBoxDefaultButton.Button2) == DialogResult.Yes)
             {
                 int selectrow = Int32.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0]
                     .Value.ToString());
                 if (studentinfoBLL.Deletestudentinfo(selectrow))
                     MessageBox.Show("删除成功！");
                 else
                     MessageBox.Show("删除失败，请检查是否选中学生信息！");
                 initcontracts();
             }             
          }
          else
                 MessageBox.Show("请选中后再点击删除按钮");
        }

        private void toolStrip_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int selectrow = Int32.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]
                    .Cells[0].Value.ToString());
                Form_edit formedit = new Form_edit();
                formedit.studentid_edit = selectrow;
                formedit.ShowDialog();
                initcontracts();
            }
            else
                MessageBox.Show("请选中一行后再点击编辑按钮！");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
    }
}
