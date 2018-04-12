using System;
using System.Linq;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new cadastroEntities();

            //Inserir();
            Consultar1(db);


            // Linq
            Consultar2(db);
            Consultar3(db);

            Console.ReadLine();
        }

        private static void Consultar3(cadastroEntities db)
        {
            var qRy = from c in db.contatos
                      select new
                      { nome = c.cliente.Nome, Contato = c.Contato };
            foreach (var cli in qRy)
                Console.WriteLine(cli.nome + " - " + cli.Contato);
        }

        private static void Consultar2(cadastroEntities db)
        {
            var qry = from cli in db.clientes
                      where cli.Nome.Contains("m")
                      orderby cli.Nome
                      select cli;
            foreach (var cli in qry)
                Console.WriteLine(cli.Nome + cli.Email);
        }

        private static void Consultar1(cadastroEntities db)
        {
            foreach (var cli in db.clientes)
            {
                Console.WriteLine(cli.Nome);
                foreach (var cont in cli.contatos)
                {
                    Console.WriteLine(cont.Tipo);
                    Console.WriteLine(cont.Contato);
                }
            }
        }

        private static void Inserir()
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
