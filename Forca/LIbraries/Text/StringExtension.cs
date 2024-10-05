using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.LIbraries.Text
{
    public static class StringExtension
    {
        public static List<Int32> GetPositions(this String s, String value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");


            List<int> indexes = new List<int>();

            for (int index = 0; ; index += value.Length)
            {
                index = s.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}
