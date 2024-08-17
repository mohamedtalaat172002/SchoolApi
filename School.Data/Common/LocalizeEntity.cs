using System.Globalization;
namespace School.Data.Common
{
    public class LocalizeEntity
    {
        public string Localize(string textAr, string textEN)
        {
            CultureInfo CultureInfo = Thread.CurrentThread.CurrentCulture;
            if (CultureInfo.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return textAr;
            return textEN;
        }

    }
}
