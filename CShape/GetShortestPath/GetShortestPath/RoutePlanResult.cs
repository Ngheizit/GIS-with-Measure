using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetShortestPath
{
    public class RoutePlanResult
    {
        private String[] passedNodeIDs;

        private double weight;

        public RoutePlanResult(String[] strings, double d)
        {
            this.passedNodeIDs = strings;
            this.weight = d;
        }

        /**
        * @return Returns the passedNodeIDs.
        */
        public String[] getPassedNodeIDs()
        {
            return passedNodeIDs;
        }

        /**
        * @param passedNodeIDs The passedNodeIDs to set.
        */
        public void setPassedNodeIDs(String[] passedNodeIDs)
        {
            this.passedNodeIDs = passedNodeIDs;
        }

        /**
        * @return Returns the weight.
        */
        public double getWeight()
        {
            return weight;
        }

        /**
        * @param weight The weight to set.
        */
        public void setWeight(double weight)
        {
            this.weight = weight;
        }
    }
}
