using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShape
{
    class PointClass
    {
        private double x;
        public double X
        { get { return this.x; } }
        private double y;
        public double Y
        { get { return this.y; } }

        public PointClass(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "(" + this.x + ", " + this.y + ")";
        }

        /// <summary>
        /// 计算两点间的直线距离
        /// </summary>
        /// <param name="pt1">其一点</param>
        /// <param name="pt2">另一点</param>
        /// <returns></returns>
        public static double GetDistance(PointClass pt1, PointClass pt2)
        {
            return Math.Sqrt(Math.Pow(pt1.x - pt2.x, 2) + Math.Pow(pt1.y - pt2.y, 2));
        }

        /// <summary>
        /// 计算点集的外包络矩形面积
        /// </summary>
        /// <param name="points">点集合</param>
        /// <returns></returns>
        public static double GetExtent(params PointClass[] points)
        {
            double minX = points[0].x,
                   maxX = points[0].x,
                   minY = points[0].y,
                   maxY = points[0].y;
           
            for (int i = 1; i < points.Length; i++)
            {
                if (points[i].x < minX)
                    minX = points[i].x;
                if (points[i].x > maxX)
                    maxX = points[i].x;
                if (points[i].y < minY)
                    minY = points[i].y;
                if (points[i].y > maxY)
                    maxY = points[i].y;
            }
            return (maxX - minX) * (maxY - minY);
        }

    }
}
