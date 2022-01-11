using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgw
{
    abstract class Selection
    {
        public int DestinationsCount { get; set; }  // abstract property for storing quantity of lanes
        public int SeriesLength { get; set; }  // abstract property for storing lengths of series for each destination
        public int CurrentLane { get; set; }
        public int SeriesCounter { get; set; }
        public Selection(int destinationsCount, int seriesLength)
        {
            DestinationsCount = destinationsCount;
            SeriesLength = seriesLength;
            CurrentLane = 0;
            SeriesCounter = 0;
        }
        public abstract int GetLaneId();
    }

    class RoundRobin : Selection
    {
        public RoundRobin(int destinationsCount, int seriesLength) : base(destinationsCount, seriesLength)
        {
            //
        }
        public override int GetLaneId()
        {
            if (SeriesCounter <= 0)
            {
                SeriesCounter = SeriesLength - 1;
                CurrentLane = CurrentLane % DestinationsCount + 1;
            }
            else
            {
                SeriesCounter -= 1;
            }
            return CurrentLane;
        }
    }

    class RandomSelect : Selection
    {
        private Random rndNumber;
        public RandomSelect(int destinationsCount, int seriesLength) : base(destinationsCount, seriesLength)
        {
            rndNumber = new Random();
        }
        public override int GetLaneId()
        {
            if (SeriesCounter <= 0)
            {
                SeriesCounter = SeriesLength - 1;
                CurrentLane = rndNumber.Next(1, DestinationsCount + 1);
            }
            else
            {
                SeriesCounter -= 1;
            }
            return CurrentLane;
        }
    }
}
