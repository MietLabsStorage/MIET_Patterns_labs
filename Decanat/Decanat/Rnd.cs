using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanat
{
    static class Rnd
    {
        public static Random Random { get; }

        static Rnd()
        {
            Random = new Random();
        }
    }
}
