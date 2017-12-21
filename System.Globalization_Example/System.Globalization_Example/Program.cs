using System.Globalization;
using System.Threading;

namespace System.Globalization_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Calendar
            Calendar cal;
            DateTime dt = new DateTime(2012, 1, 1, new GregorianCalendar());
            #endregion

            #region CultureInfo
            CultureInfo cit = System.Threading.Thread.CurrentThread.CurrentCulture;

            CultureInfo ciUI = Thread.CurrentThread.CurrentUICulture;

            CultureInfo ci = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

            CultureInfo cinv = CultureInfo.InvariantCulture;

            Console.Write(System.Globalization_Example.Main.DESCRICAO);
            Console.ReadKey();
            #endregion
        }
    }
}
