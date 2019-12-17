using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace LorentzCurve
{
    class Program
    {

        static FileStream fs = new FileStream("result.txt", FileMode.OpenOrCreate, FileAccess.Write);
        static StreamWriter sw = new StreamWriter(fs, Encoding.Default);
        
        static void Main(string[] args)
        {
            string header = "ID,R值,子集,总集,子集累积,总集累积";
            sw.WriteLine(header);

            string dataFile = "./data.txt";
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID"));
            dt.Columns.Add(new DataColumn("RValue"));
            dt.Columns.Add(new DataColumn("Sub"));
            dt.Columns.Add(new DataColumn("Agg"));


            StreamReader sr = new StreamReader(dataFile, Encoding.Default);
            string line;
            int i = 1;
            while ((line = sr.ReadLine()) != null)
            {
                double subset = Convert.ToDouble(line.Split(',')[0]);
                double aggregate = Convert.ToDouble(line.Split(',')[1]);
                double r = subset / aggregate;
                dt.Rows.Add(i++, r, subset, aggregate);
            }
            PrintDataTable(dt);

            Console.WriteLine("------------------------------");
            Console.WriteLine("------------------------------");
            DataView dv = new DataView(dt);
            dv.Sort = "RValue DESC";
            PrintDataTable(dv);



            sw.Close();
            fs.Close();
            File.Delete("result.csv");
            File.Move("result.txt", "result.csv");
            Console.ReadKey();
        }

        private static void PrintDataTable(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + " ");
                }
                Console.Write("\n");
            }
        }
        private static void PrintDataTable(DataView dv)
        {
            double sum_sub = 0;
            double sum_agg = 0;
            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                for (int j = 0; j < dv.Table.Columns.Count; j++)
                {
                    Console.Write(dv[i][j] + " ");
                    sw.Write(dv[i][j] + ",");
                    if (j > dv.Table.Columns.Count - 2)
                    {
                        sum_sub += Convert.ToDouble(dv[i][j - 1]);
                        sum_agg += Convert.ToDouble(dv[i][j]);
                        Console.Write(sum_sub + " " + sum_agg);
                        sw.Write(sum_sub + "," + sum_agg);
                    }
                }
                Console.Write("\n");
                sw.Write("\n");
            }
        }
    }
}
