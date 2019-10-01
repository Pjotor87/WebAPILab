using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebAPILab.Helpers
{
    public static class CurrencyHelper
    {
        public static IList<string> GetCurrencyCodes(string currencyCodesFilePath, Encoding encoding = null)
        {
            if (!File.Exists(currencyCodesFilePath))
                throw new FileNotFoundException($"The file at path: {currencyCodesFilePath} does not exist.");
            else
                return File.ReadAllLines(currencyCodesFilePath, encoding == null ? Encoding.Default : encoding);
        }
    }
}