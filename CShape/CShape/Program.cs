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

            PointClass d = MeasureUtil.SpatialLayout.Point.Central.Average(
                new PointClass(3.58, 6.89),
                new PointClass(7.45, 6.41),
                new PointClass(3.21, 4.23),
                new PointClass(6.47, 4.58),
                new PointClass(5.32, 6.31),
                new PointClass(6.54, 2.97),
                new PointClass(7.81, 6.35),
                new PointClass(9.65, 7.43),
                new PointClass(6.78, 5.98),
                new PointClass(8.92, 4.47)
            );
            //Console.WriteLine(d);

            PointClass d2 = MeasureUtil.SpatialLayout.Point.Central.Average(
                new PointClass(4.5, 5.8),
                new PointClass(1.1, 4.2),
                new PointClass(1.3, 4.3),
                new PointClass(2.4, 4.5),
                new PointClass(4.2, 3.9),
                new PointClass(1.4, 5.1),
                new PointClass(2.7, 3.7),
                new PointClass(2, 2.9),
                new PointClass(4.2, 3.5),
                new PointClass(5.1, 2.9)
            );
            double[] d3 = MeasureUtil.SpatialLayout.Point.Central.Medium(
                new PointClass(4.5, 5.8),
                new PointClass(1.1, 4.2),
                new PointClass(1.3, 4.3),
                new PointClass(2.4, 4.5),
                new PointClass(4.2, 3.9),
                new PointClass(1.4, 5.1),
                new PointClass(2.7, 3.7),
                new PointClass(2, 2.9),
                new PointClass(4.2, 3.5),
                new PointClass(5.1, 2.9)
            );
            Console.WriteLine(d2);
            Console.WriteLine(d3[0]);
            Console.WriteLine(d3[1]);
            Console.WriteLine(d3[2]);
            Console.WriteLine(d3[3]);

            Console.ReadKey();
        }
    }
}
