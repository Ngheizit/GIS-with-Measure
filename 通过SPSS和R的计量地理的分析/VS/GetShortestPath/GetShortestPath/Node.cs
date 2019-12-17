using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetShortestPath
{
    class Node
    {
        private string iD;
        public string ID { get { return this.iD; } }
        private ArrayList edgeList;//Edge的集合－－出边表
        public ArrayList EdgeList { get { return this.edgeList; } }

        public Node(string id)
        {
            this.iD = id;
            this.edgeList = new ArrayList();
        }

    }
}
