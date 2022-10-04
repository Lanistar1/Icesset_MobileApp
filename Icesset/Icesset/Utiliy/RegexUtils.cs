using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Icesset.Utiliy
{
    public static class RegexUtils
    {
        public static Regex ValidEmailAddress()
        {
            return new Regex(@"^([\W\.\-]+)@([\W\-]+)((\.(W){2,3})+)$");
        }
        public static Regex MinLenght(int lenght)
        {
            return new Regex(@"(\s*(\S)\s*){" + lenght + @",}");
        }
        public static Regex ValidZipCode()
        {
            return new Regex(@"^\d{5}(?:[-\s]\d{4})?$");
        }
    }
}
