using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class Student
    {
        private int studentNo;
        public int StudentNo
        {
            get { return studentNo; }
            set { this.studentNo = value; }
        }

        private string loginPwd;
        public string LoginPwd {
            get { return loginPwd; }
            set { this.loginPwd = value; }
        }

        private string studentName;
        public string StudentName
        {
            get { return studentName; }
            set { this.studentName = value; }
        }

        private string sex;
        public string Sex
        {
            get { return sex; }
            set { this.sex = value; }
        }

        private int gradeId;
        public int GradeId {
            get { return gradeId; }
            set { this.gradeId = value; }
        }

        private string phone;
        public string Phone {
            get { return phone; }
            set { this.sex = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { this.address = value; }
        }
        private DateTime borndate;
        public DateTime Borndate
        {
            get { return borndate; }
            set
            {
                this.borndate = value;
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }
    }
}
