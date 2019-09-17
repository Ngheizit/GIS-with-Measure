using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShape
{
    class MeasureUtil
    {
        /// <summary>
        /// 最小值
        /// </summary>
        /// <param name="dbs">数值集合</param>
        /// <returns></returns>
        public static double Min(params double[] dbs)
        {
            double min = dbs[0];
            for(int i = 1;i < dbs.Length; i++)
            {
                if (dbs[i] < min)
                    min = dbs[i];
            }
            return min;
        }
        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="dbs">数值集合</param>
        /// <returns></returns>
        public static double Max(params double[] dbs)
        {
            double max = dbs[0];
            for (int i = 1; i < dbs.Length; i++)
            {
                if (dbs[i] > max)
                    max = dbs[i];
            }
            return max;
        }
        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="dbs">数值集合</param>
        /// <returns></returns>
        public static double Sum(params double[] dbs)
        {
            double sum = 0.0;
            for(int i = 0; i < dbs.Length; i++)
                sum += dbs[i];
            return sum;
        }
        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="dbs">数值集合</param>
        /// <returns></returns>
        public static double Average(params double[] dbs)
        {
            return Sum(dbs) / dbs.Length;
        }


        /// <summary>
        /// 空间布局的测度
        /// </summary>
        public static class SpatialLayout
        {
            /// <summary>
            /// 点状分布
            /// </summary>
            public static class Point
            {
                /// <summary>
                /// 最邻近平均距离的测度
                /// </summary>
                public static class Neighbor
                {
                    /// <summary>
                    /// 最近邻平均距离
                    /// </summary>
                    /// <param name="points">点集</param>
                    /// <returns></returns>
                    public static double NearestNeighborAverage(params PointClass[] points)
                    {
                        List<double> mins = new List<double> { }; // 存储每个点与相对最近邻点的距离
                        for (int i = 0; i < points.Length; i++) // 遍历每个点
                        {
                            double[] distances = new double[points.Length - 1];
                            for (int j = 0, n = 0; j < points.Length; j++) // 遍历除当前点的其他点，并加以存储
                            {
                                if (i == j)
                                    continue;
                                distances[n++] = PointClass.GetDistance(points[i], points[j]);
                            }
                            mins.Add(Min(distances));
                        }
                        return mins.Average(); // 所有最小值取平均
                    }
                    /// <summary>
                    /// 理论的随机型（普阿松分布型）的最近邻平均距离
                    /// </summary>
                    /// <param name="points">点集</param>
                    /// <returns></returns>
                    public static double NearestNeighborAverage_Puason(params PointClass[] points)
                    {
                        return 1.0 / (2 * Math.Sqrt(points.Length / PointClass.GetExtent(points)));
                    }
                    /// <summary>
                    /// 邻近指数 R
                    ///  → R = 1，随机型分布；
                    ///  → R ＜ 1，趋于凝集分布；
                    ///  → R ＞ 1，趋于离散的均匀分布；
                    /// </summary>
                    /// <param name="points">点集</param>
                    /// <returns></returns>
                    public static double R(params PointClass[] points)
                    {
                        return NearestNeighborAverage(points) / NearestNeighborAverage_Puason(points);
                    }
                }
                /// <summary>
                /// 中心位置的测度
                /// </summary>
                public static class Central
                {
                    /// <summary>
                    /// 平均中心
                    /// </summary>
                    /// <param name="points">点集</param>
                    /// <returns></returns>
                    public static PointClass Average(params PointClass[] points)
                    {
                        double sumX = 0.0,
                               sumY = 0.0;
                        int len = points.Length;
                        for(int i = 0; i < len; i++)
                        {
                            sumX += points[i].X;
                            sumY += points[i].Y;
                        }
                        return new PointClass(sumX / len, sumY / len);
                    }
                    /// <summary>
                    /// 中项中心
                    /// </summary>
                    /// <param name="points"></param>
                    /// <returns></returns>
                    public static double[] Medium(params PointClass[] points)
                    {
                        if(points.Length % 2 == 0)
                        {
                            int mid_f = points.Length / 2 - 1,
                                mid_t = points.Length / 2;
                            List<double> xs = new List<double> { };
                            List<double> ys = new List<double> { };
                            for(int i = 0; i < points.Length; i++)
                            {
                                xs.Add(points[i].X);
                                ys.Add(points[i].Y);
                            }
                            xs.Sort(); ys.Sort();
                            return new double[] { xs[mid_f], xs[mid_t], ys[mid_f], ys[mid_t] };
                        }
                        else
                        {
                            return new double[] { };
                        }
                    }
                }
            }
        }
    }
}
