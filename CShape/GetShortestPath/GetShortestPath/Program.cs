using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GetShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList nodeList = new ArrayList();


            StreamReader sr = new StreamReader("./data.txt", Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] strs = line.Split(',');
                string nodeID = strs[0];
                Node n = new Node(nodeID);
                for (int i = 1; i < strs.Length; i++)
                {
                    Edge e = new Edge()
                    {
                        StartNodeID = n.ID,
                        EndNodeID = strs[i].Split(':')[0],
                        Weight = Convert.ToDouble(strs[i].Split(':')[1])
                    };
                    n.EdgeList.Add(e);
                }
                nodeList.Add(n);
            }

            RoutePlanner planner = new RoutePlanner();

            sr.Close();
            sr = new StreamReader("./fromto.txt", Encoding.Default);
            line = sr.ReadLine();

            RoutePlanResult result = planner.Paln(nodeList, line.Split(',')[0], line.Split(',')[1]);

            Console.WriteLine(String.Format("{0}-{1}最短路径：", line.Split(',')[0], line.Split(',')[1]));
            foreach (string path in result.getPassedNodeIDs())
            {
                Console.Write(path + " ");
            }
            Console.WriteLine(line.Split(',')[1]);
            Console.WriteLine(String.Format("权重为：{0}", result.getWeight()));

            planner = null;
            sr.Close();
            Console.ReadKey();
        }
    }
}
