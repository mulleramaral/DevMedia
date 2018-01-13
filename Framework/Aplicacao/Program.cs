using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Aplicacao
{
    class Program
    {
        static void Main(string[] args)
        {
            //string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cadastro;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //string ConnectionString = getConnectionStringFromConfig();

            //using (var conn = new SqlConnection(ConnectionString))
            //{
            //    Console.WriteLine("Connection string" + ConnectionString);
            //    conn.Open();
            //    Console.WriteLine("Conexão com o banco de dados efetuada com sucesso...");
            //    Console.WriteLine("Estado da conexão: " + conn.State);
            //    conn.Close();
            //    Console.WriteLine("Estado da conexão: " + conn.State);
            //}

            //Entrada de dados
            //Console.WriteLine("Informe o nome do cliente: ");
            //var nome = Console.ReadLine();
            //Console.WriteLine("Informe o e-mail do cliente: ");
            //var email = Console.ReadLine();

            // gravação dos dados via codigo fonte commandText
            //var conStr = getConnectionStringFromConfig();
            //var conn = new SqlConnection(conStr);
            //var sql = "INSERT INTO clientes(nome,email) VALUES(@nome,@email)";
            //var cmd = new SqlCommand(sql,conn);
            //cmd.Parameters.AddWithValue("@nome", nome);
            //cmd.Parameters.AddWithValue("@email", email);
            //conn.Open();
            //try
            //{
            //    cmd.ExecuteNonQuery();
            //    Console.WriteLine("Registro inserido com sucesso");
            //}
            //finally
            //{
            //    conn.Close();
            //}


            // gravação dos dados via StoredProcedure
            //var sql = "InsertCliente";
            //var cmd = new SqlCommand(sql, conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("nome", nome);
            //cmd.Parameters.AddWithValue("email", email);
            //conn.Open();
            //try
            //{
            //    cmd.ExecuteNonQuery();
            //    Console.WriteLine("Registro inserido com sucesso");
            //}
            //finally
            //{
            //    conn.Close();
            //}

            //var ConStr = getConnectionStringFromConfig();
            //using (var conn = new SqlConnection(ConStr))
            //{
            //    conn.Open();
            //    var trans = conn.BeginTransaction();
            //    try
            //    {
            //        var sql1 = "insert into clientes(nome,email) VALUES(@nome,@email)";
            //        var sql2 = "DELETE FROM clientes WHERE id = 1";
            //        var cmd1 = conn.CreateCommand();
            //        cmd1.CommandText = sql1;
            //        cmd1.Parameters.AddWithValue("@nome", nome);
            //        cmd1.Parameters.AddWithValue("@email", email);
            //        cmd1.Transaction = trans;
            //        var cmd2 = conn.CreateCommand();
            //        cmd2.CommandText = sql2;
            //        cmd2.Transaction = trans;
            //        //Executa dados em uma unica transação
            //        cmd1.ExecuteNonQuery();
            //        cmd2.ExecuteNonQuery();
            //        // tenta efetivar as operações no DB
            //        trans.Commit();
            //    }
            //    catch (Exception E)
            //    {
            //        trans.Rollback();
            //        Console.WriteLine("Erro ao executar transação " + E.GetType());
            //    }
            //}

            // Consulta ao banco e iterar com datareader
            //var conn = new SqlConnection(getConnectionStringFromConfig());
            //var sql1 = "SELECT * FROM clientes";

            //var cmd = new SqlCommand("SelectClientesProdutos", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //conn.Open();
            //var dr = cmd.ExecuteReader();
            //Console.WriteLine("Listagem de clientes");
            //Console.WriteLine("----------------------------------");
            //while (dr.Read())
            //{
            //    Console.WriteLine("Código: " + dr[0].ToString());
            //    Console.WriteLine("Nome: " + dr[1].ToString());
            //    Console.WriteLine("Email: " + dr[2].ToString());
            //    Console.WriteLine("----------------------------------");
            //}
            //dr.NextResult();
            //Console.WriteLine("Listagem de Produtos");
            //Console.WriteLine("----------------------------------");
            //while (dr.Read())
            //{
            //    Console.WriteLine("Código:" + dr[0].ToString());
            //    Console.WriteLine("Nome: " + dr[1].ToString());
            //    Console.WriteLine("----------------------------------");
            //}
            //conn.Close();
            //Console.ReadLine();

            // Usando SqlDataAdapter


            //var conn = new SqlConnection(getConnectionStringFromConfig());
            //var sql = "select * from clientes";
            //var cmd = new SqlCommand(sql, conn);
            //var ds = new DataSet("Cadastro");
            //var da = new SqlDataAdapter(cmd);
            //da.Fill(ds,"cliente");
            //var dt = ds.Tables["cliente"];
            //foreach (DataRow row in dt.Rows)
            //{
            //    Console.WriteLine("Id: " + row[0].ToString());
            //    Console.WriteLine("Nome: " + row[1].ToString());
            //    Console.WriteLine("Email: " + row[2].ToString());
            //}
            //ds.WriteXml(@".\dados.xml");
            //Console.ReadLine();

            // Relacionamento
            var conn = new SqlConnection(getConnectionStringFromConfig());
            var sql1 = "SELECT * FROM clientes";
            var sql2 = "SELECT * FROM contatos";
            var cmd1 = new SqlCommand(sql1, conn);
            var cmd2 = new SqlCommand(sql2, conn);
            var ds = new DataSet("clientes");
            var da1 = new SqlDataAdapter(cmd1);
            var da2 = new SqlDataAdapter(cmd2);
            da1.Fill(ds,"clientes");
            da2.Fill(ds,"contatos");
            var dtClientes = ds.Tables[0];
            var dtContatos = ds.Tables[1];
            DataRelation relation = ds.Relations.Add(
                "ClientesContatos",
                dtClientes.Columns["Id"],
                dtContatos.Columns["IdCliente"]
                );

            foreach (DataRow cli in dtClientes.Rows)
            {
                Console.WriteLine("Nome cliente: " + cli[1].ToString());
                foreach (DataRow cont in cli.GetChildRows(relation))
                    Console.WriteLine(cont[0].ToString() + " - " + cont[1].ToString());
            }

            Console.ReadLine();
        }

        private static string getConnectionStringFromBuilder()
        {
            var ConBuilder = new SqlConnectionStringBuilder();
            ConBuilder.DataSource = @"(localdb)\MSSQLLocalDB";
            ConBuilder.InitialCatalog = "cadastro";
            ConBuilder.IntegratedSecurity = true;
            var ConnectionString = ConBuilder.ConnectionString;
            return ConnectionString;
        }

        private static string getConnectionStringFromConfig()
        {
            return ConfigurationManager.ConnectionStrings["cadastro"].ConnectionString;
        }
    }
}
