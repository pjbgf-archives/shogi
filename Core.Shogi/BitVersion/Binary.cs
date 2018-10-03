using System;
using System.Text.RegularExpressions;

namespace Core.Shogi.BitVersion
{
    public class Binary
    {
        public static ushort ConvertToUInt16(string binary)
        {
            ushort value = 0;

            if (!string.IsNullOrEmpty(binary) &&
                Regex.IsMatch(binary, "^(0|1)+$", RegexOptions.Compiled | RegexOptions.Singleline))
            {
                var pow = binary.Length - 1;
                for (var i = 0; i < binary.Length; i++, pow--)
                    if (binary[i] == '1')
                        value += Convert.ToUInt16(Math.Pow(2, pow));
            }

            return value;
        }
    }
}