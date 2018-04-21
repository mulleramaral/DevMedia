using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            #region StringBuilder

            StringBuilder sb = new StringBuilder();

            sb.Append("New");
            sb.Append("York");

            sb.Insert(5, " HELLO ");
            sb.Remove(5, 6);
            sb.Replace('k', 'q');

            Console.Write(sb);
            sb.Clear();
            Console.ReadKey();

            #endregion

             

        }
    }
}
