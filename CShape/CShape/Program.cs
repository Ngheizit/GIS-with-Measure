using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShape
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] dbs = new double[]
            {
                12, 83, 50, 35, 55, 50, 72, 40, 85, 29, 65, 75
            };
            int[] ints = new int[]
            {
                12, 83, 50, 35, 55, 50, 72, 40, 85, 29, 65, 75
            };
            Console.WriteLine(WxzUtils.StatIndicators.wxzVariation(dbs));

            Console.ReadKey();
        }
    }
}
