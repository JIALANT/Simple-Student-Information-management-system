using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace mycontracts
{
    class studentinfoBLL
    {
        //创建学生文档
        private static string _basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\xml\Students.xml";
        public static void CreateStudentXml()
        {
            XDocument studentDoc = new XDocument();
            XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            studentDoc.Declaration = xDeclaration;
            XElement xElement = new XElement("studentcontract");
            studentDoc.Add(xElement);
            studentDoc.Save(_basePath);
        }
        //增加学生信息
        public  static bool Addstudentinfo(studentinfo param)
        {
            XElement xml = XElement.Load(_basePath);
            XElement studentXml = new XElement("student");            
            studentXml.Add(new XAttribute("studentid", param.studentid));           
            studentXml.Add(new XElement("name", param.Name));
            studentXml.Add(new XElement("sex",param .sex));
            studentXml.Add(new XElement("age", param.Age.ToString()));
            studentXml.Add(new XElement("birthdate", param.Birthdate.ToString("yyyy-MM-dd")));
            studentXml.Add(new XElement("phone", param.Phone));
            studentXml.Add(new XElement("homeaddress",param .Homeaddress));
            studentXml.Add(new XElement("email", param.Email));
            studentXml.Add(new XElement("profession", param.Profession));
            xml.Add(studentXml);
            xml.Save(_basePath);
            return true;
        }
        //修改学生信息
        public static bool UpdateStudentinfo(studentinfo param)
        {
            bool result=false;
            if(param .studentid>0)
            {
                XElement xml=XElement .Load (_basePath);
                XElement studentxml=(from db in xml.Descendants("student")
                                     where db.Attribute ("studentid").Value ==param .studentid.ToString()
                                     select db).Single ();
                studentxml.SetElementValue("name",param .Name);
                studentxml .SetElementValue ("sex",param .sex);
                studentxml .SetElementValue ("age",param .Age.ToString());
                studentxml .SetElementValue ("birthdate", param.Birthdate.ToString("yyyy-MM-dd"));
                studentxml .SetElementValue("phone", param.Phone);
                studentxml .SetElementValue("homeaddress",param .Homeaddress);
                studentxml .SetElementValue("email", param.Email);
                studentxml .SetElementValue("profession", param.Profession);
                xml.Save (_basePath);
                result =true;
            }
            return result;
        }
            //删除信息
        public static bool Deletestudentinfo(int studentid)
        {
            bool result = false;
            if (studentid > 0)
            {
                XElement xml = XElement.Load(_basePath);
                XElement studentxml = (from db in xml.Descendants("student")
                                       where db.Attribute("studentid").Value == studentid.ToString()
                                       select db).Single();
                studentxml.Remove();
                xml.Save(_basePath);
                result = true;
            }
            return result;
        }
        //查询全部
        public static List<studentinfo> getallstudentinfo()
        {
            List<studentinfo> studentlist = new List<studentinfo>();
            XElement xml = XElement.Load(_basePath);
            var studentvar = xml.Descendants("student");
            studentlist = (from student in studentvar
                           select new  studentinfo 
                               {
                                  studentid = Int32.Parse(student.Attribute("studentid").Value),
                                  Name = student.Element("name").Value,
                                  Age = Int32.Parse(student.Element("age").Value),
                                   sex = student.Element("sex").Value,
                                   Birthdate = DateTime.Parse(student.Element("birthdate").Value),
                                   Phone = student.Element("phone").Value,
                                    Homeaddress = student.Element("homeaddress").Value,
                                  Email = student.Element("email").Value,
                                Profession = student.Element("profession").Value
                               }).ToList();  
            return studentlist;
        }
        //根据学号查询
        public static studentinfo getstudentinfo(int studentid)
        {
            studentinfo Studentinfo = new studentinfo();
            XElement xml = XElement.Load(_basePath);
            Studentinfo = (from student in xml.Descendants("student")
                           where student.Attribute("studentid").Value == studentid.ToString()
                           select new studentinfo
                           {
                               studentid = Int32.Parse(student.Attribute("studentid").Value),
                               Name = student.Element("name").Value,
                               Age = Int32.Parse(student.Element("age").Value),
                               sex = student.Element("sex").Value,
                               Birthdate = DateTime.Parse(student.Element("birthdate").Value),
                               Phone = student.Element("phone").Value,
                               Homeaddress = student.Element("homeaddress").Value,
                               Email = student.Element("email").Value,
                               Profession = student.Element("profession").Value
                           }).Single();
            return Studentinfo;
        }
        //根据姓名查询
        public static studentinfo getstudentinfo(string name)
        {
            studentinfo Studentinfo = new studentinfo();
            XElement xml = XElement.Load(_basePath);
            Studentinfo = (from student in xml.Descendants("student")
                           where student.Attribute("name").Value == name
                           select new studentinfo
                           {
                               studentid = Int32.Parse(student.Attribute("studentid").Value),
                               Name = student.Element("name").Value,
                               Age = Int32.Parse(student.Element("age").Value),
                               sex = student.Element("sex").Value,
                               Birthdate = DateTime.Parse(student.Element("birthdate").Value),
                               Phone = student.Element("phone").Value,
                               Homeaddress = student.Element("homeaddress").Value,
                               Email = student.Element("email").Value,
                               Profession = student.Element("profession").Value
                           }).Single();
            return Studentinfo;
        }
        //获取列表
        public static List<studentinfo> getstudentinfolist(studentinfo param)
        {
            List<studentinfo> studentlist = new List<studentinfo>();
            XElement xml = XElement.Load(_basePath);
            var studentvar = xml.Descendants("student");
            if (param.studentid != 0)
            {
                studentvar = xml.Descendants("student").Where(a => a.Attribute("studentid").Value
                    == param.studentid.ToString());
            }
            else if (!string.IsNullOrEmpty(param.Name))
            {
                studentvar = xml.Descendants("student").Where(a => a.Attribute("studentid").Value
                    == param.Name);
            }
            studentlist = (from student in studentvar
                           select new studentinfo
                               {
                                   studentid = Int32.Parse(student.Attribute("studentid").Value),
                                   Name = student.Element("name").Value,
                                   Age = Int32.Parse(student.Element("age").Value),
                                   sex = student.Element("sex").Value,
                                   Birthdate = DateTime.Parse(student.Element("birthdate").Value),
                                   Phone = student.Element("phone").Value,
                                   Homeaddress = student.Element("homeaddress").Value,
                                   Email = student.Element("email").Value,
                                   Profession = student.Element("profession").Value
                               }).ToList();
            return studentlist;
        }
   }
}
