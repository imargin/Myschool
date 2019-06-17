using System;
using System.Data.SqlClient;

namespace MySchool
{
    class AdminDao
    {
        public bool Login(string name, string pwd)
        {
            int r = 0;
            SqlConnection conn = DBUtil.GetConn();
            try
            {
                string sql = "select count(0) from admin " + $"where loginId='{name}' and loginPwd='{pwd}'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                r = (int)cmd.ExecuteScalar();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                try
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.Message);
                }
            }

            return r > 0;
        }
    }
}
