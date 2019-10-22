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
            Console.WriteLine(WxzUtils.StatSpatial.wxzAverageCenter(
                new WxzUtils.FeatureClass.Point(3.21, 2.97),
                new WxzUtils.FeatureClass.Point(3.58, 4.23),
                new WxzUtils.FeatureClass.Point(5.32, 4.47),
                new WxzUtils.FeatureClass.Point(6.47, 4.58),
                new WxzUtils.FeatureClass.Point(6.54, 5.98),
                new WxzUtils.FeatureClass.Point(6.78, 6.31),
                new WxzUtils.FeatureClass.Point(7.45, 6.35),
                new WxzUtils.FeatureClass.Point(7.81, 6.41),
                new WxzUtils.FeatureClass.Point(8.92, 6.89),
                new WxzUtils.FeatureClass.Point(9.65, 7.43)
            ));

            //Console.WriteLine(WxzUtils.StatSpatial.wxzNNADistance(
            //    new WxzUtils.FeatureClass.Point(3.5, 5.8),
            //    new WxzUtils.FeatureClass.Point(0.8, 4.6),
            //    new WxzUtils.FeatureClass.Point(1.3, 4.8),
            //    new WxzUtils.FeatureClass.Point(2.6, 4.1),
            //    new WxzUtils.FeatureClass.Point(4.7, 4.2),
            //    new WxzUtils.FeatureClass.Point(1.5, 3.8),
            //    new WxzUtils.FeatureClass.Point(2.6, 3.8),
            //    new WxzUtils.FeatureClass.Point(2.2, 3.1),
            //    new WxzUtils.FeatureClass.Point(3.8, 3.7),
            //    new WxzUtils.FeatureClass.Point(4.7, 3.9),
            //    new WxzUtils.FeatureClass.Point(0.9, 2.9),
            //    new WxzUtils.FeatureClass.Point(1.7, 2.3),
            //    new WxzUtils.FeatureClass.Point(2.5, 2.5),
            //    new WxzUtils.FeatureClass.Point(3.2, 2.2),
            //    new WxzUtils.FeatureClass.Point(3.7, 2.9),
            //    new WxzUtils.FeatureClass.Point(4.7, 2.2),
            //    new WxzUtils.FeatureClass.Point(2.8, 1.8),
            //    new WxzUtils.FeatureClass.Point(3.8, 1.9),
            //    new WxzUtils.FeatureClass.Point(4.5, 1.4),
            //    new WxzUtils.FeatureClass.Point(1.5, 0.8),
            //    new WxzUtils.FeatureClass.Point(2.3, 0.9)
            //));
            //Console.WriteLine(MeasureUtil.SpatialLayout.Point.Neighbor.NearestNeighborAverage(
            //    new PointClass(3.5, 5.8),
            //    new PointClass(0.8, 4.6),
            //    new PointClass(1.3, 4.8),
            //    new PointClass(2.6, 4.1),
            //    new PointClass(4.7, 4.2),
            //    new PointClass(1.5, 3.8),
            //    new PointClass(2.6, 3.8),
            //    new PointClass(2.2, 3.1),
            //    new PointClass(3.8, 3.7),
            //    new PointClass(4.7, 3.9),
            //    new PointClass(0.9, 2.9),
            //    new PointClass(1.7, 2.3),
            //    new PointClass(2.5, 2.5),
            //    new PointClass(3.2, 2.2),
            //    new PointClass(3.7, 2.9),
            //    new PointClass(4.7, 2.2),
            //    new PointClass(2.8, 1.8),
            //    new PointClass(3.8, 1.9),
            //    new PointClass(4.5, 1.4),
            //    new PointClass(1.5, 0.8),
            //    new PointClass(2.3, 0.9)
            //));

            Console.ReadKey();
        }
    }
}
