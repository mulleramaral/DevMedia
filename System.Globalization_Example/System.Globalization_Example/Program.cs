using System.Globalization;

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
            CultureInfo cultureInfo = new CultureInfo("pt-BR");

            #endregion
        }
    }
}
