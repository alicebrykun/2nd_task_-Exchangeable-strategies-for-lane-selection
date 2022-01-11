using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgw
{
    class Destination
    {
        public double PercentageOfFail { get; protected set; }
        public int AttemptsToAddLoad { get; protected set; }
        public int LoadsDelivered { get; protected set; }
        private static Random rndNumber = new Random();

        public Destination(double fail)
        {
            PercentageOfFail = fail;
            AttemptsToAddLoad = 0;
            LoadsDelivered = 0;
        }
        public bool AddLoad()
        {
            AttemptsToAddLoad++;
            if (rndNumber.NextDouble() * 100 < PercentageOfFail)
            {
                return false;
            }
            else
            {
                LoadsDelivered++;
                return true;
            }
        }
        public double GetSuccessRate()
        {
            return (double)LoadsDelivered / (double)AttemptsToAddLoad;
        }
    }
}
