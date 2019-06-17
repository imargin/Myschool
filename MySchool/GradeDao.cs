using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class GradeDao
    {
        internal int insert(Grade grade)
        {            
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into grade ");
            sb.Append("values ('{0}')");
            return DBUtil.ExecuteNonQuery(sb.ToString(),
                new string[] { grade.GradeName });
        }
    }
}
