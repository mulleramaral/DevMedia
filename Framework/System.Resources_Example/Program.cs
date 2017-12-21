namespace System.Resources_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Resources.ResourceManager rm = new Resources.ResourceManager(typeof(System.Resources_Example.Recurso));
            System.Globalization.CultureInfo cultureInfo = new Globalization.CultureInfo("pt-BR");
            string d = rm.GetString("DESCRICAO",cultureInfo);
            Console.WriteLine(d);
            Console.ReadKey();
        }
    }
}
