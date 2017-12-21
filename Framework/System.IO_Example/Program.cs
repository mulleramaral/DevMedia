using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The quick brown fox jumps over the lazy dog");
            File.AppendAllText(@"C:\Users\Miiller\Desktop\teste.txt",sb.ToString());

            string[] values = { "Line 1", "Line 2", "Line 3" };
            File.AppendAllLines(@"C:\Users\miiller\Desktop\teste.txt", values);
        }
    }
}
