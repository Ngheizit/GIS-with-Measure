using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShape.WxzUtils
{
    /// <summary>
    /// 统计分组工具类
    /// </summary>
    class StatGroup
    {
        #region 全距
        /// <summary>
        /// 全距：获取给定统计数据的全距（极差）
        /// 求全距 R=最大值-最小值
        /// </summary>
        /// <param name="dbs">需要进行全距计算的统计数据</param>
        /// <returns>返回统计数据的全距（极差）</returns>
        public static double wxzRange(params double[] dbs)
        { return dbs.Max() - dbs.Min(); }
        /// <summary>
        /// 获取给定统计数据的全距（极差）
        /// 求全距 R=最大值-最小值
        /// </summary>
        /// <param name="ints">需要进行全距计算的统计数据</param>
        /// <returns>返回统计数据的全距（极差）</returns>
        public static double wxzRange(params int[] ints)
        { return ints.Max() - ints.Min(); }
        #endregion

        #region 组数
        /// <summary>
        /// 根据给定统计量确定组数
        /// 确定组数 n=1+3.32lgN
        /// </summary>
        /// <param name="n">总计统计量</param>
        /// <returns>返回统计分组数</returns>
        public static int wxzGroupsNumber(int n)
        { return (int)Math.Ceiling(1 + 3.32 * Math.Log10(n)); }// 向上取整 
        /// <summary>
        /// 确定统计数据的组数
        /// 确定组数 n=1+3.32lgN
        /// </summary>
        /// <param name="dbs">统计数组</param>
        /// <returns>返回统计分组数</returns>
        public static int wxzGroupsNumber(params double[] dbs)
        { return wxzGroupsNumber(dbs.Length); }
        /// <summary>
        /// 确定统计数据的组数
        /// 确定组数 n=1+3.32lgN
        /// </summary>
        /// <param name="ints">统计数组</param>
        /// <returns>返回统计分组数</returns>
        public static int wxzGroupsNumber(params int[] ints)
        { return wxzGroupsNumber(ints.Length); }
        #endregion

        #region 组距
        /// <summary>
        /// 组距：根据统计数据计算分组组距
        /// 计算组距 h=R/n
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的分组组距</returns>
        public static double wxzGroupsInterval(params double[] dbs)
        { return wxzRange(dbs) / wxzGroupsNumber(dbs.Length); }
        /// <summary>
        /// 组距：根据统计数据计算分组组距
        /// 计算组距 h=R/n
        /// </summary>
        /// <param name="ints">组距：根据统计数据计算分组组距</param>
        /// <returns>返回统计数据的分组组距</returns>
        public static double wxzGroupsInterval(params int[] ints) 
        { return wxzRange(ints) / wxzGroupsNumber(ints.Length); }
        #endregion

        #region 组限
        /// <summary>
        /// 组限：根据统计数据确定组限
        /// 第一组下限 = 最小值-0.5*h
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <returns>返回统计数据的分组的第一组下限</returns>
        public static double wxzGroupsLimit(params double[] dbs)
        { return dbs.Min() - 0.5 * wxzGroupsInterval(dbs); }
        /// <summary>
        /// 组限：根据统计数据确定组限
        /// 第一组下限 = 最小值-0.5*h
        /// </summary>
        /// <param name="ints">统计数据</param>
        /// <returns>返回统计数据的分组的第一组下限</returns>
        public static double wxzGroupsLimit(params int[] ints)
        { return ints.Min() - 0.5 * wxzGroupsInterval(ints); } 
        /// <summary>
        /// 上下限
        /// </summary>
        public enum wxzGroupUpDown
        {
            /// <summary>
            /// 上限
            /// </summary>
            up,
            /// <summary>
            /// 下限
            /// </summary>
            down
        }
        /// <summary>
        /// 组限：根据统计数据确定组限
        /// </summary>
        /// <param name="dbs">统计数据</param>
        /// <param name="groupIndex">第几组的组限,索引从0开始</param>
        /// <param name="upDown">上限还是下限</param>
        /// <returns>返回统计数据第groupIndex组的upDown限</returns>
        public static double wxzGroupsLimit(double[] dbs, int groupIndex = 0, wxzGroupUpDown upDown = wxzGroupUpDown.down)
        {
            double groupMinValue = wxzGroupsLimit(dbs), h = wxzGroupsInterval(dbs); // 第一组下限  和 组距
            if(upDown == wxzGroupUpDown.down) // 第groupIndex组下限
            { return groupMinValue + h * groupIndex; }
            else                           // 第groupIndex组上限
            {  return groupMinValue + h * (groupIndex + 1); }
        }
        #endregion
    }
}
