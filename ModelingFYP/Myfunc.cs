using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingFYP
{
    class Myfunc
    {
        public static double Func1 (double x1, double x2)
        {
            //return 4+ x1 + 2 * x2;
            return 4 + x1 + 2 * x2 + x1 * x2 + 0.5 * x1 *x1 + 5 * x2 *x2;
        }
    }
}
