using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Review: I would move that to Prabez.Core.Extensions.String
namespace MobileRcp.Core.Extensions
{
    public static class FirstLetterToUpperExtensionMethod
    {
        public static string FirstLetterToUpper(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return str[0].ToString().ToUpper() + str.Substring(1);
        }
    }
}
