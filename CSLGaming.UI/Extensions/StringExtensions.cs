using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLGaming.API.Extensions.Extensions
{
    public static class StringExtensions
    {
        public static string Truncate(this string input, int maxLength)
        {
            if (input == null || input.Length <= maxLength)
            {
                return input;
            }
            else
            {
                return input.Substring(0, maxLength).Trim() + "...";
            }
        }
    }
}
