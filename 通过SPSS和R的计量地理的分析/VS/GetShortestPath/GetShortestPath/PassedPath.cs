using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetShortestPath
{
    class PassedPath
    {
        private string curNodeID;
        public bool BeProcessed
        {
            get { return this.beProcessed; }
            set { this.beProcessed = value; }
        }
        private bool beProcessed;   //是否已被处理
        public string CurNodeID
        {
            get { return this.curNodeID; }
        }
        private double weight;        //累积的权值
        public double Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
        private ArrayList passedIDList; //路径
        public ArrayList PassedIDList
        {
            get { return this.passedIDList; }
        }

        public PassedPath(string ID)
        {
            this.curNodeID = ID;
            this.weight = double.MaxValue;
            this.passedIDList = new ArrayList();
            this.beProcessed = false;
        }
    }
}
