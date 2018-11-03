using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mycontracts
{
    class studentinfo
    {
        public int studentid { set; get; }//ID
        public string Name { set; get; }//姓名
        public string sex { set; get; }//性别
        public int Age { set; get; }//年龄
        public DateTime Birthdate { set; get; }//出生日期
        public string Phone { set; get; }//手机号码
        public string Homeaddress { set; get; }//家庭地址
        public string Email { set; get; }//邮箱
        public string Profession { set; get; }//专业profession
    }
}
