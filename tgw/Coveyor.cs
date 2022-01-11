using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgw
{
    class Coveyor
    {
        public List<Destination> destinationLanes { get; private set; }
        private Selection strategy;
        private int LoadsPassed;
        public Coveyor(int destinationsCount, int selection, int sequenceLenght, double PercentageOfFail)
        {
            LoadsPassed = 0;
            switch (selection)
            {
                case 1:
                    strategy = new RoundRobin(destinationsCount, sequenceLenght);
                    break;
                case 2:
                    strategy = new RandomSelect(destinationsCount, sequenceLenght);
                    break;
                default:
                    Console.WriteLine("Wrong lane selection parameters.");
                    return;
            }

            destinationLanes = new List<Destination>(destinationsCount + 1);
            destinationLanes.Add(new Destination(0.0)); // lane 0 - always succedss
            for (int i = 1; i <= destinationsCount; i++)
            {
                destinationLanes.Add(new Destination(PercentageOfFail));
            }
        }
        public void AddLoad()
        {
            LoadsPassed++;
            if (destinationLanes.Count == 1 || !destinationLanes[strategy.GetLaneId()].AddLoad())
            { //if adding to selected lane failed, ad to default 0
                destinationLanes[0].AddLoad();
            }
        }
        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();

            strBuild.Append("-------------------------------------------------\n");
            strBuild.Append("| Destination Number");
            for (int i = 0; i < destinationLanes.Count; i++)
            {
                strBuild.Append(String.Format("|{0,7}", i));
            }
            strBuild.Append("|\n");


            strBuild.Append("----\n|         Total in %");

            for (int i = 0; i < destinationLanes.Count; i++)
            {
                double percent = (double)(destinationLanes[i].LoadsDelivered) / (double)LoadsPassed;
                strBuild.Append(String.Format("|{0,7:P2}", percent));
            }
            strBuild.Append("|\n");

            strBuild.Append("----\n|       Success in %");

            for (int i = 0; i < destinationLanes.Count; i++)
            {
                strBuild.Append(String.Format("|{0,7:P2}", destinationLanes[i].GetSuccessRate()));
            }
            strBuild.Append("|\n");

            strBuild.Append("-------------------------------------------------\n");
            return strBuild.ToString();
        }
    }
}
