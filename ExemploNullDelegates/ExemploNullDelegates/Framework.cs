using static System.Console;

namespace ExemploNullDelegates
{
    public class Boleto
    {
        public void Pagar(double valor)
        {
            WriteLine($"Pago valor de {valor} no boleto");
        }
    }

    public delegate void PagarEvent (double valor);
    public class Pedido
    {
        public event PagarEvent Pagar;

        //Boleto boleto = new Boleto();
        public void Fechar(double valor)
        {
            //Delegação
            //boleto.Pagar(valor);

            //Delegação com delegate / event
            Pagar?.Invoke(valor);
        }
    }
}