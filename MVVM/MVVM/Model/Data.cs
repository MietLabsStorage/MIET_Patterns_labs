using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public static class Data
    {
        public static List<String> Strings { get; } = new List<string>()
        {
            "This a some text witch shown on this page",
            "Author of this string didn\'t know what he should write",
            "Oh, if you are here - click \'Right\' and you will know some new",
            "That program demonstrate MVVM pattern",
            "Pain"
        };
    }
}
