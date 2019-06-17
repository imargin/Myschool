using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MySchool
{
    class StudentDao
    {
        public int Count()
        {
            int r = 0;        
            SqlConnection conn = DBUtil.GetConn();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select count(0) ");
                sql.Append("from student ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
                r = (int)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                DBUtil.CloseAll(conn,null);
            }
            return r;
        }

        public List<Student> FindAll()
        {
            List<Student> list = new List<Student>();
            SqlConnection conn = DBUtil.GetConn();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select * from student");
                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student
                    {
                        StudentNo = (int) reader[0],
                        StudentName = reader["studentName"].ToString(),
                        GradeId = (int) reader["gradeId"],
                        LoginPwd = reader["loginPwd"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Sex = reader["sex"].ToString(),
                        Address = reader["address"].ToString(),
                        Borndate = (DateTime) reader["borndate"],
                        Email = reader["email"].ToString()
                    };
                    list.Add(s);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                DBUtil.CloseAll(conn,null);
            }

            return list;
        }

        internal int Delete(int stuNo)
        {
            int r = 0;
            SqlConnection conn = DBUtil.GetConn();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("delete from student ");
                sb.Append("where studentNo = {0}");
                string sql = string.Format(sb.ToString(),stuNo);
                SqlCommand cmd = new SqlCommand(sql, conn);
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                DBUtil.CloseAll(conn,null);
            }

            return r;
        }

        internal List<Student> FindByName(string name)
        {
            List<Student> list = new List<Student>();
            SqlConnection conn = DBUtil.GetConn();
            try
            {
                
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from student ");
                sb.Append("where studentName like '{0}'");
                string sql = string.Format(sb.ToString(), "%" + name + "%");
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student
                    {
                        StudentNo = (int) reader[0],
                        StudentName = reader["studentName"].ToString(),
                        GradeId = (int) reader["gradeId"],
                        LoginPwd = reader["loginPwd"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Sex = reader["sex"].ToString(),
                        Address = reader["address"].ToString(),
                        Borndate = (DateTime) reader["borndate"],
                        Email = reader["email"].ToString()
                    };
                    list.Add(s);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                DBUtil.CloseAll(conn,null);
            }

            return list;
        }

        internal int update(Student stu)
        {
            int r = 0;
            SqlConnection conn = DBUtil.GetConn();
            try
            {
                //Console.WriteLine(stu.Borndate.ToShortDateString().Substring(0, 8));
               
                StringBuilder sb = new StringBuilder();
                sb.Append("update student ");
                sb.Append("set loginPwd='{0}', ");
                sb.Append("studentName='{1}', ");
                sb.Append("sex='{2}', ");                
                sb.Append("gradeId={3}, ");
                sb.Append("phone='{4}', ");
                sb.Append("address='{5}', ");
                sb.Append("borndate='{6}', ");
                sb.Append("email='{7}' ");
                sb.Append("where studentNo = {8}");
                string sql = string.Format(sb.ToString(),
                    stu.LoginPwd, stu.StudentName, stu.Sex, stu.GradeId,
                    stu.Phone, stu.Address, stu.Borndate.ToShortDateString().Substring(0, 10),
                    stu.Email, stu.StudentNo);
                SqlCommand cmd = new SqlCommand(sql, conn);
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                DBUtil.CloseAll(conn,null);
            }

            return r;
        }

        internal Student FindById(int stuNo)
        {
            Student stu = null;
            SqlConnection conn = DBUtil.GetConn();

            try
            {
                
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from student ");
                sb.Append("where studentNo = {0}");
                string sql = string.Format(sb.ToString(), stuNo);
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    stu = new Student
                    {
                        StudentNo = (int) reader["studentNo"],
                        StudentName = reader["studentName"].ToString(),
                        Address = reader["address"].ToString(),
                        Borndate = (DateTime) reader["borndate"],
                        Email = reader["email"].ToString(),
                        GradeId = (int) reader["gradeId"],
                        LoginPwd = reader["loginPwd"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Sex = reader["sex"].ToString()
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
               DBUtil.CloseAll(conn,null);
            }
            return stu;
        }
    }
}
