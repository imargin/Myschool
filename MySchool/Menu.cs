using System;
using System.Collections.Generic;

namespace MySchool
{
    class Menu
    {
        private StudentDao stuDao = new StudentDao();
        private GradeDao gradeDao = new GradeDao();

        private bool Login()
        {
            Console.Write("请输入用户名：");
            string name = Console.ReadLine();
            Console.Write("请输入密码：");
            string pwd = Console.ReadLine();

            // 调用 AdminDao 的查询方法
            AdminDao adminDao = new AdminDao();
            return adminDao.Login(name, pwd);
        }

        public  void ShowMainMenu()
        {
            if (!Login())
            {
                Console.WriteLine("登录失败，用户名或密码错误");
                return;
            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("==========请选择操作键==========");
                Console.WriteLine("1. 查询学生数量");
                Console.WriteLine("2. 查看学生用户列表");
                Console.WriteLine("3. 查询指定学生的所有基本信息");
                Console.WriteLine("4. 按姓名查询学生信息");
                Console.WriteLine("5. 插入年级信息");
                Console.WriteLine("6. 修改学生生日信息");
                Console.WriteLine("7. 删除学生信息");
                Console.WriteLine("8. 退出");
                Console.WriteLine("================================");
                Console.Write("请选择：");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CountStudent();
                        break;
                    case "2":
                        ShowStudentList();
                        break;
                    case "3":
                        FindStudentById();
                        break;
                    case "4":
                        FindByName();
                        break;
                    case "5":
                        AddGrade();
                        break;
                    case "6":
                        UpdateBorndate();
                        break;
                    case "7":
                        DeleteStu();
                        break;
                    case "8":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("选项错误，请重新选择...");
                        break;                   
                }
                Console.WriteLine();
            }            
        }

        private void DeleteStu()
        {
            Console.Write("请输入学号：");
            int stuNo = int.Parse(Console.ReadLine());
            int r = stuDao.Delete(stuNo);
            if(r > 0)
            {
                Console.WriteLine("删除成功");
            }
            else
            {
                Console.WriteLine("删除失败");
            }
        }

        private void UpdateBorndate()
        {
            Console.Write("请输入学号：");
            int stuNo = int.Parse(Console.ReadLine());
            Student stu = stuDao.FindById(stuNo);
            
            if (stu != null)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("学号：" + stu.StudentNo);
                Console.WriteLine("姓名：" + stu.StudentName);
                Console.WriteLine("性别：" + stu.Sex);
                Console.WriteLine("生日：" + stu.Borndate);
                Console.WriteLine("--------------------------------");
                Console.Write("请输入新的出生日期：");
                string borndate = Console.ReadLine();
                stu.Borndate = DateTime.Parse(borndate);
                int r = stuDao.update(stu);
                if(r > 0)
                {
                    Console.WriteLine("修改成功");
                }
                else
                {
                    Console.WriteLine("修改失败");
                }
            }
            else
            {
                Console.WriteLine("没有该学员");
            }
        }

        private void AddGrade()
        {
            Console.Write("请输入年级名：");
            string gradeName = Console.ReadLine();
            Grade grade = new Grade(gradeName);
            int r = gradeDao.insert(grade);
            if(r > 0)
            {
                Console.WriteLine("添加年级成功");
            }
            else
            {
                Console.WriteLine("添加年级失败");
            }
        }

        private void FindByName()
        {
            Console.Write("请输入学生姓名：");
            string name = Console.ReadLine();
            List<Student> list = stuDao.FindByName(name);
            Console.WriteLine("-------------------------------------------------------------------------");
            if (list.Count > 0)
            {                
                Console.WriteLine("学号\t姓名\t性别\t年级\t电话\t地址\t生日\tEmail");
                Console.WriteLine("-------------------------------------------------------------------------");
                foreach (Student s in list)
                {
                    Console.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",
                        s.StudentNo, s.StudentName, s.Sex, s.GradeId, s.Phone, s.Address,
                        s.Borndate, s.Email));
                }
            }
            else
            {
                Console.WriteLine("查无此人");
            }
            Console.WriteLine("-------------------------------------------------------------------------");
        }

        private void FindStudentById()
        {
            Console.Write("请输入学号：");
            int stuNo = int.Parse(Console.ReadLine());
            Student stu = stuDao.FindById(stuNo);
            Console.WriteLine("--------------------------------");
            if(stu != null)
            {        
                Console.WriteLine("学号：" + stu.StudentNo);
                Console.WriteLine("姓名：" + stu.StudentName);
                Console.WriteLine("性别：" + stu.Sex);
                Console.WriteLine("年级：" + stu.GradeId);
                Console.WriteLine("电话：" + stu.Phone);
                Console.WriteLine("地址：" + stu.Address);
                Console.WriteLine("生日：" + stu.Borndate);
                Console.WriteLine("Email：" + stu.Email);
            }
            else
            {
                Console.WriteLine("没有该学员");
            }
            Console.WriteLine("--------------------------------");
        }

        private void ShowStudentList()
        {
            List<Student> list = stuDao.FindAll();
            Console.WriteLine("--------------------------");
            Console.WriteLine("学号\t姓名");
            Console.WriteLine("--------------------------");
            foreach(Student s in list)
            {
                Console.WriteLine(s.StudentNo + "\t" + s.StudentName);
            }
            Console.WriteLine("--------------------------");
        }

        private void CountStudent()
        {
            int c = stuDao.Count();
            Console.WriteLine(string.Format("共有 {0} 个学生.", c));
        }
    }
}
