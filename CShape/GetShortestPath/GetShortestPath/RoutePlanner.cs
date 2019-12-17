using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetShortestPath
{
    public class RoutePlanner
    {
        public RoutePlanner()
        {
        }

        #region Paln
        //获取权值最小的路径
        public RoutePlanResult Paln(ArrayList nodeList, string originID, string destID)
        {
            PlanCourse planCourse = new PlanCourse(nodeList, originID);

            Node curNode = this.GetMinWeightRudeNode(planCourse, nodeList, originID);

            #region 计算过程
            while (curNode != null)
            {
                PassedPath curPath = planCourse[curNode.ID];
                foreach (Edge edge in curNode.EdgeList)
                {
                    PassedPath targetPath = planCourse[edge.EndNodeID];
                    if (targetPath == null)
                        continue;
                    double tempWeight = curPath.Weight + edge.Weight;

                    if (tempWeight < targetPath.Weight)
                    {
                        targetPath.Weight = tempWeight;
                        targetPath.PassedIDList.Clear();

                        for (int i = 0; i < curPath.PassedIDList.Count; i++)
                        {
                            targetPath.PassedIDList.Add(curPath.PassedIDList[i].ToString());
                        }

                        targetPath.PassedIDList.Add(curNode.ID);
                    }
                }

                //标志为已处理
                planCourse[curNode.ID].BeProcessed = true;
                //获取下一个未处理节点
                curNode = this.GetMinWeightRudeNode(planCourse, nodeList, originID);
            }
            #endregion



            //表示规划结束
            return this.GetResult(planCourse, destID);
        }
        #endregion

        #region private method
        #region GetResult
        //从PlanCourse表中取出目标节点的PassedPath，这个PassedPath即是规划结果
        private RoutePlanResult GetResult(PlanCourse planCourse, string destID)
        {
            PassedPath pPath = planCourse[destID];

            if (pPath.Weight == int.MaxValue)
            {
                RoutePlanResult result1 = new RoutePlanResult(null, int.MaxValue);
                return result1;
            }

            string[] passedNodeIDs = new string[pPath.PassedIDList.Count];
            for (int i = 0; i < passedNodeIDs.Length; i++)
            {
                passedNodeIDs[i] = pPath.PassedIDList[i].ToString();
            }
            RoutePlanResult result = new RoutePlanResult(passedNodeIDs, pPath.Weight);

            return result;
        }
        #endregion

        #region GetMinWeightRudeNode
        //从PlanCourse取出一个当前累积权值最小，并且没有被处理过的节点
        private Node GetMinWeightRudeNode(PlanCourse planCourse, ArrayList nodeList, string originID)
        {
            double weight = double.MaxValue;
            Node destNode = null;

            foreach (Node node in nodeList)
            {
                if (node.ID == originID)
                {
                    continue;
                }

                PassedPath pPath = planCourse[node.ID];
                if (pPath.BeProcessed)
                {
                    continue;
                }

                if (pPath.Weight < weight)
                {
                    weight = pPath.Weight;
                    destNode = node;
                }
            }

            return destNode;
        }
        #endregion
        #endregion
    }
}
