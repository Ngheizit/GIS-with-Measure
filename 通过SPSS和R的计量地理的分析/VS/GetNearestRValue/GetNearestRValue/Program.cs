using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GetNearestRValue
{
    class Program
    {
        class PointClass
        {
            private double x;
            public double X { get { return this.x; } }
            private double y;
            public double Y { get { return this.y; } }
            public PointClass(double x, double y) {
                this.x = x;
                this.y = y;
            }
            public override string ToString() {
                return String.Format("({0}, {1})", this.x, this.y);
            }
            public static double GetXMax(List<PointClass> points) {
                double max = double.MinValue;
                foreach (PointClass pt in points) {
                    if (pt.x > max) {
                        max = pt.x;
                    }
                }
                return max;
            }
            public static double GetXMix(List<PointClass> points) {
                double min = double.MaxValue;
                foreach (PointClass pt in points) {
                    if (pt.x < min) {
                        min = pt.x;
                    }
                }
                return min;
            }
            public static double GetYMax(List<PointClass> points) {
                double max = double.MinValue;
                foreach (PointClass pt in points) {
                    if (pt.y > max) {
                        max = pt.y;
                    }
                }
                return max;
            }
            public static double GetYMix(List<PointClass> points) {
                double min = double.MaxValue;
                foreach (PointClass pt in points) {
                    if (pt.y < min) {
                        min = pt.y;
                    }
                }
                return min;
            }
            public static double GetXAve(List<PointClass> points) {
                double sum = 0;
                foreach (PointClass pt in points) {
                    sum += pt.x;
                }
                return sum / points.Count;
            }
            public static double GetYAve(List<PointClass> points)  {
                double sum = 0;
                foreach (PointClass pt in points) {
                    sum += pt.y;
                }
                return sum / points.Count;
            }
            public static double GetExtent(List<PointClass> points) {
                return (GetXMax(points) - GetXMix(points)) * (GetYMax(points) - GetYMix(points));
            }
            public static double GetDistance(PointClass pt1, PointClass pt2) {
                return Math.Sqrt(Math.Pow(pt2.x - pt1.x, 2) + Math.Pow(pt2.y - pt1.y, 2));
            }
        }

        private static void WriteLine(string str, StreamWriter sw) {
            Console.WriteLine(str);
            sw.WriteLine(str);
        }

        static void Main(string[] args)
        {
            string dataFile = "./data.txt";
            List<PointClass> data = GetData(dataFile);


            FileStream fs = new FileStream("result.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);

            Console.WriteLine("------------------------------");
            int count = data.Count;
            double XMin = PointClass.GetXMix(data);
            double XMax = PointClass.GetXMax(data);
            double YMin = PointClass.GetYMix(data);
            double YMax = PointClass.GetYMax(data);
            double XAve = PointClass.GetXAve(data);
            double YAve = PointClass.GetYAve(data);
            double area = PointClass.GetExtent(data);
            WriteLine(String.Format("点数：,{0}", count), sw);
            WriteLine(String.Format("X最小值：,{0}", XMin), sw);
            WriteLine(String.Format("X最大值：,{0}", XMax), sw);
            WriteLine(String.Format("Y最小值：,{0}", YMin), sw);
            WriteLine(String.Format("Y最大值：,{0}", YMax), sw);
            WriteLine(String.Format("X均值：,{0}", XAve), sw);
            WriteLine(String.Format("Y均值：,{0}", YAve), sw);
            WriteLine(String.Format("中位数：,{0}", new PointClass(XAve, YAve)), sw);
            WriteLine(String.Format("点集外接矩形面积：,{0}", area), sw);

            

            Console.WriteLine("------------------------------");
            WriteLine("距离矩阵：", sw);
            double[,] distances = new double[count, count];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i == j) {
                        distances[i, j] = double.NaN;
                    } else {
                        distances[i, j] = PointClass.GetDistance(data[i], data[j]);
                    }
                    Console.Write(Math.Round(distances[i, j], 2) + "\t");
                    sw.Write(distances[i, j] + ",");
                }
                Console.Write("\n");
                sw.Write("\n");
            }

            Console.WriteLine("------------------------------");
            WriteLine("最小值：", sw);
            double[] mins = new double[count];
            for (int i = 0; i < count; i++)
            {
                double min = double.MaxValue;
                for (int j = 0; j < count; j++) {
                    if (i != j) {
                        min = distances[i, j] < min ? distances[i, j] : min;
                    }
                }
                mins[i] = min;
                Console.Write(Math.Round(min, 2) + "\t");
                sw.Write(min + ",");
            }
            Console.Write("\n");
            sw.Write("\n");

            Console.WriteLine("------------------------------");
            double ave_mins = mins.Average(); // 最邻近平均距离
            double beauty_min = 1.0 / (2 * Math.Sqrt(count / area)); // 理想的随机性（普阿松分布型）的最近邻平均距离
            double RValue = ave_mins / beauty_min; // 最邻近指数 R
            WriteLine(String.Format("最邻近平均距离：\n{0}", ave_mins), sw);
            WriteLine(String.Format("理想的随机性（普阿松分布型）的最近邻平均距离：\n{0}", beauty_min), sw);
            WriteLine(String.Format("最邻近指数 R：\n{0}", RValue), sw);


            sw.Close();
            fs.Close();
            File.Delete("result.csv");
            File.Move("result.txt", "result.csv");


            Console.ReadKey();
        }

        private static List<PointClass> GetData(string dataFile)
        {
            List<PointClass> data = new List<PointClass>();
            StreamReader sr = new StreamReader(dataFile, Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null) {
                double x = Convert.ToDouble(line.Split(',')[0]);
                double y = Convert.ToDouble(line.Split(',')[1]);
                PointClass pt = new PointClass(x, y);
                Console.WriteLine(pt);
                data.Add(new PointClass(x, y));
            }
            return data;
        }
    }
}
