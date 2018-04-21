using static System.Console;
using static System.Convert;

namespace ExemploNullDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Informe valor do pedido: ");
            var valor = ToDouble(ReadLine());
            var pedido = new Pedido();
            pedido.Pagar += v => WriteLine($"Pago valor de {v} no boleto");
            pedido.Fechar(valor);
            ReadLine();
        }

        //private static void Pedido_Pagar(double valor)
        //{
        //    new Boleto().Pagar(valor);
        //}
    }
}
