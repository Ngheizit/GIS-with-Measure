using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShape.WxzUtils
{
    /// <summary>
    /// 统计指标统计类
    /// </summary>
    class StatIndicators
    {
        #region 平均值
        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的平均值</returns>
        public static double wxzAverage(params double[] dbs)
        { return dbs.Sum() / dbs.Length; }
        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据的平均值</returns>
        public static double wxzAverage(params int[] ints)
        { return (double)ints.Sum() / ints.Length; }
        #endregion

        #region 中位数
        /// <summary>
        /// 中位数
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的中位数</returns>
        public static double wxzMedian(params double[] dbs)
        { return dbs.Length % 2 == 0 ? dbs[dbs.Length / 2] : (dbs[dbs.Length / 2] - dbs[dbs.Length / 2 + 1]) / 2; }
        /// <summary>
        /// 中位数
        /// </summary>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据的中位数</returns>
        public static double wxzMedian(params int[] ints)
        { return ints.Length % 2 == 0 ? ints[ints.Length / 2] : (ints[ints.Length / 2] - ints[ints.Length / 2 + 1]) / 2; }
        #endregion

        #region 众数
        // ...
        #endregion

        #region 离差
        /// <summary>
        /// 离差
        /// </summary>
        /// <param name="index">统计数据的第几统计量，索引从0开始</param>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据第index统计量的离差</returns>
        public static double wxzDeviation(int index, params double[] dbs)
        { return dbs[index] - wxzAverage(dbs); }
        /// <summary>
        /// 离差
        /// </summary>
        /// <param name="index">统计数据的第几统计量，索引从0开始</param>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据第index统计量的离差</returns>
        public static double wxzDeviation(int index, params int[] ints)
        { return ints[index] - wxzAverage(ints); }
        #endregion

        #region 离差平方和
        /// <summary>
        /// 离差平方和
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的离差平方和</returns>
        public static double wxzDeviationSquareSum(params double[] dbs)
        {
            double sum = 0;
            for (int i = 0; i < dbs.Length; i++)
            { sum += Math.Pow(wxzDeviation(i, dbs), 2); }
            return sum;
        }
        /// <summary>
        /// 离差平方和
        /// </summary>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据的离差平方和</returns>
        public static double wxzDeviationSquareSum(params int[] ints)
        {
            double sum = 0;
            for (int i = 0; i < ints.Length; i++)
            { sum += Math.Pow(wxzDeviation(i, ints), 2); }
            return sum;
        }
        #endregion

        #region 方差
        /// <summary>
        /// 方差
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的方差</returns>
        public static double wxzVariance(params double[] dbs)
        { return wxzDeviationSquareSum(dbs) / dbs.Length; }
        /// <summary>
        /// 方差 - 样本方差
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的方差</returns>
        public static double wxzVarianceUnbiased(params double[] dbs)
        { return wxzDeviationSquareSum(dbs) / (dbs.Length - 1); }
        /// <summary>
        /// 方差
        /// </summary>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据的方差</returns>
        public static double wxzVariance(params int[] ints)
        { return wxzDeviationSquareSum(ints) / ints.Length; }
        /// <summary>
        /// 方差 - 样本方差
        /// </summary>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据的方差</returns>
        public static double wxzVarianceUnbiased(params int[] ints)
        { return wxzDeviationSquareSum(ints) / (ints.Length - 1); }
        #endregion

        #region 标准差
        /// <summary>
        /// 标准差
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的标准差</returns>
        public static double wxzStandardDeviation(params double[] dbs)
        { return Math.Sqrt(wxzVariance(dbs)); }
        /// <summary>
        /// 标准差 - 以样品方差对标准差进行无偏估计
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的标准差</returns>
        public static double wxzStandardDeviationUnbiased(params double[] dbs)
        { return Math.Sqrt(wxzVarianceUnbiased(dbs)); }
        /// <summary>
        /// 标准差
        /// </summary>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据的标准差</returns>
        public static double wxzStandardDeviation(params int[] ints)
        { return Math.Sqrt(wxzVariance(ints)); }
        /// <summary>
        /// 标准差 - 以样品方差对标准差进行无偏估计
        /// </summary>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据的标准差</returns>
        public static double wxzStandardDeviationUnbiased(params int[] ints)
        { return Math.Sqrt(wxzVarianceUnbiased(ints)); }
        #endregion

        #region 变异系数
        /// <summary>
        /// 变异系数
        /// 表示统计数据的相对变化（波动）程度
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的变异系数</returns>
        public static double wxzVariation(params double[] dbs)
        { return wxzStandardDeviationUnbiased(dbs) / wxzAverage(dbs); }
        /// <summary>
        /// 变异系数
        /// 表示统计数据的相对变化（波动）程度
        /// </summary>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据的变异系数</returns>
        public static double wxzVariation(params int[] ints)
        { return wxzStandardDeviationUnbiased(ints) / wxzAverage(ints); }
        #endregion

        #region 偏度系数
        /// <summary>
        /// 偏度系数
        /// 测度数据分布的不对称性情况
        /// 刻画以平均值为中心的偏向情况
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的偏差系数</returns>
        public static double wxzSkewness(params double[] dbs)
        {
            double sum = 0, len = dbs.Length, ave = wxzAverage(dbs), standardDeviation = wxzStandardDeviation(dbs);
            for (int i = 0; i < len; i++)
            { sum += 1.0 / len * Math.Pow((dbs[i] - ave) / standardDeviation, 3); }
            return sum;
        }
        /// <summary>
        /// 偏度系数
        /// 测度数据分布的不对称性情况
        /// 刻画以平均值为中心的偏向情况
        /// </summary>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据的偏差系数</returns>
        public static double wxzSkewness(params int[] ints)
        {
            double sum = 0, len = ints.Length, ave = wxzAverage(ints), standardDeviation = wxzStandardDeviation(ints);
            for (int i = 0; i < len; i++)
            { sum += 1.0 / len * Math.Pow((ints[i] - ave) / standardDeviation, 3); }
            return sum;
        }
        #endregion

        #region 峰度系数
        /// <summary>
        /// 峰度系数
        /// 测度数据在均值附近的集中程度
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的峰度系数</returns>
        public static double wxzKurtosis(params double[] dbs)
        {
            double sum = 0, len = dbs.Length, ave = wxzAverage(dbs), standardDeviation = wxzStandardDeviation(dbs);
            for (int i = 0; i < len; i++)
            { sum += 1.0 / len * Math.Pow((dbs[i] - ave) / standardDeviation, 4); }
            return sum - 3;
        }
        /// <summary>
        /// 峰度系数
        /// 测度数据在均值附近的集中程度
        /// </summary>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据的峰度系数</returns>
        public static double wxzKurtosis(params int[] ints)
        {
            double sum = 0, len = ints.Length, ave = wxzAverage(ints), standardDeviation = wxzStandardDeviation(ints);
            for (int i = 0; i < len; i++)
            { sum += 1.0 / len * Math.Pow((ints[i] - ave) / standardDeviation, 4); }
            return sum - 3;
        } 
        #endregion
    }
}
