using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    class Program
    {
        static void Main(string[] args)
        {
            new Menu().ShowMainMenu();

            //DBUtil.Update("update student set studentName='{0}' " +
            //    "where studentNo={1}", new string[] {"张三", "10005" });

            Console.WriteLine("谢谢使用");   
            Console.ReadLine();
        }
    }
}
