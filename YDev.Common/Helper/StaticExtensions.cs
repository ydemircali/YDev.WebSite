using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YDev.Common.Helper
{
    public static class StaticExtensions
    {
        public static string ToLink(this string inValue)
        {

            string newValue = inValue.ToLower().Trim();
            newValue = string.Join(" ", newValue.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)));

            newValue = newValue.Replace("ç", "c").Replace("ı", "i").Replace("ğ","g")
                .Replace("ş","s").Replace("ö","o").Replace("ü","u").Replace(" ","-");

            return newValue;
        }

    }
}
