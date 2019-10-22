using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CShape.WxzUtils
{
    class StatSpatial
    {
        /// <summary>
        /// 计算平面上两点间的最短距离
        /// </summary>
        /// <param name="p1">第一个点</param>
        /// <param name="p2">第二个点</param>
        /// <returns>返回两点间的距离</returns>
        public static double wxzDistance(FeatureClass.Point p1, FeatureClass.Point p2)
        { return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)); }

        /// <summary>
        /// 计算点集的外接矩形面积
        /// </summary>
        /// <param name="points">点集</param>
        /// <returns>返回外接矩形面积</returns>
        public static double wxzExtent(params FeatureClass.Point[] points)
        {
            int len = points.Length;
            double[] xs = new double[len], ys = new double[len];
            for (int i = 0; i < len; i++)
            {
                xs[i] = points[i].X; ys[i] = points[i].Y;
            }
            return (xs.Max() - xs.Min()) * (ys.Max() - ys.Min());
        }

        /// <summary>
        /// 计算点集的平均中心
        /// </summary>
        /// <param name="points">点集</param>
        /// <returns>返回点集的平均中心</returns>
        public static FeatureClass.Point wxzAverageCenter(params FeatureClass.Point[] points)
        {
            int len = points.Length;
            double[] xs = new double[len], ys = new double[len];
            for (int i = 0; i < len; i++)
            {
                xs[i] = points[i].X; ys[i] = points[i].Y;
            }
            return new FeatureClass.Point(StatIndicators.wxzAverage(xs), StatIndicators.wxzAverage(ys))
        }

        /// <summary>
        /// 计算最邻近平均距离
        /// </summary>
        /// <param name="index">最邻近距离的基准点</param>
        /// <param name="points">统计点集</param>
        /// <returns>返回以第index个点作为基准点的最邻近平均距离</returns>
        public static double wxzNNADistance(params FeatureClass.Point[] points)
        {
            int len = points.Length;
            double sum = 0;
            for (int i = 0; i < len; i++)
            {
                FeatureClass.Point targetPt = points[i];
                double minDistance = 999999999;
                for (int j = 0; j < len; j++)
                {
                    if(i != j)
                    {
                        double distance = wxzDistance(targetPt, points[j]);
                        if (distance < minDistance)
                            minDistance = distance;
                    }
                }
                sum += minDistance;
            }
            return sum / len;
        }

        /// <summary>
        /// 邻近指数 R
        /// R=1  =>  随机型分布
        /// R<1  =>  趋向于凝集型分布
        /// R>1  =>  趋向于离散型的均匀分布
        /// </summary>
        /// <param name="points">点集</param>
        /// <returns>返回点集的邻近指数</returns>
        public static double wxzProximity(params FeatureClass.Point[] points)
        {
            double D = points.Length / wxzExtent(points); // 点的密度
            double de = 1.0 / (2 * Math.Sqrt(D)); // 理论的随机分布型的最近邻平均距离
            return wxzNNADistance(points) / de;
        }
    }
}
