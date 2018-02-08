using System;
using System.Linq;

namespace EfPostgresql
{
    class Program
    {
        static void Main(string[] args)
        {
            EfContext contexto = new EfContext();
            contexto.produto.ToList().ForEach(a => Console.WriteLine(a.Descricao));
            Console.ReadLine();
        }
    }
}
