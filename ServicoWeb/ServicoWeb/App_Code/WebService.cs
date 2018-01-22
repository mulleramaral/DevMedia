using System.Collections.Generic;
using System.Web.Services;


public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService
{
    [WebMethod]
    public int Somar(int x,int y)
    {
        return x + y;
    }

    [WebMethod]
    public List<Cliente> getClientes()
    {
        var result = new List<Cliente>();
        result.Add(new Cliente { Id = 1, Nome = "Guinter" });
        result.Add(new Cliente { Id = 2, Nome = "Rudolfo" });
        result.Add(new Cliente { Id = 3, Nome = "Wesley" });
        return result;
    }
}
