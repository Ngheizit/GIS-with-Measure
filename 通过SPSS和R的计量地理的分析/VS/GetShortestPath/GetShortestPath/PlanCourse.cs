﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetShortestPath
{
    class PlanCourse
    {
        private Hashtable htPassedPath;
        public PassedPath this[string nodeID] { get { return (PassedPath)this.htPassedPath[nodeID]; } }

        public PlanCourse(ArrayList nodeList, string originID)
        {
            this.htPassedPath = new Hashtable();

            Node originNode = null;
            foreach (Node node in nodeList)
            {
                if (node.ID == originID)
                {
                    originNode = node;
                }
                else
                {
                    PassedPath pPath = new PassedPath(node.ID);
                    this.htPassedPath.Add(node.ID, pPath);
                }
            }

            if (originNode == null)
            {
                throw new Exception("The origin node is not exist !");
            }

            this.InitializeWeight(originNode);
        }

        private void InitializeWeight(Node originNode)
        {
            if ((originNode.EdgeList == null) || (originNode.EdgeList.Count == 0))
            {
                return;
            }

            foreach (Edge edge in originNode.EdgeList)
            {
                PassedPath pPath = this[edge.EndNodeID];
                if (pPath == null)
                {
                    continue;
                }

                pPath.PassedIDList.Add(originNode.ID);
                pPath.Weight = edge.Weight;
            }
        }
    }
}
