using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new cadastroEntities();
            var cli = new cliente
            {
                Nome = "Muller",
                Email = "miilleramaral@gmail.com"
            };

            db.clientes.Add(cli);
            db.SaveChanges();

            var contato1 = new contato
            {
                Tipo = "EMAIL",
                Contato = "miilleramaral@gmail.com",
                cliente = cli
            };

            var contato2 = new contato
            {
                Tipo = "TELEFONE",
                Contato = "34541738",
                cliente = cli
            };

            db.contatos.Add(contato1);
            db.contatos.Add(contato2);
            db.SaveChanges();

            var clileticia = new cliente
            {
                Nome = "Leticia",
                Email = "leticia@gmail.com"
            };

            clileticia.contatos.Add(new contato
            {
                Tipo = "FONE",
                Contato = "34541738"
            });

            clileticia.contatos.Add(new contato
            {
                Tipo = "EMAIL",
                Contato = "leticia@gmail.com"
            });

            db.clientes.Add(clileticia);
            db.SaveChanges();
            Console.WriteLine("Registros inserido com sucesso");
        }
    }
}
