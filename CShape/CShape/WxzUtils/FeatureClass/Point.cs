using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShape.WxzUtils.FeatureClass
{
    class Point
    {
        private double x;
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        private double y;
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public Point(double x = 0, double y = 0)
        { this.x = x; this.y = y; }
        public Point(int x = 0, int y = 0)
        { this.x = x; this.y = y; }

    }
}
