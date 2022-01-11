using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tgw
{
    class Program
    {
        static void Main(string[] args)
        {
            int destinationsCount, strategy, sequenceLenght, loadsCount;
            double percentageOfFail;

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("2nd Task - Exchangeable strategies for lane selection");
            Console.WriteLine("-----------------------------------------------------");

            destinationsCount = GetDestinationsCount();
            strategy = GetStrategy();
            sequenceLenght = GetSequenceLenght();
            percentageOfFail = GetPercentageOfFail();
            loadsCount = GetLoadsCount();

            Coveyor conveyor = new Coveyor(destinationsCount, strategy, sequenceLenght, percentageOfFail);
            //simulating loads
            for (int i = 0; i < loadsCount; i++)
            {
                conveyor.AddLoad();
            }
            //results output
            Console.WriteLine(conveyor.ToString());
            Console.ReadKey();
        }
        static int GetDestinationsCount()
        {
            int destinationsCount;
            Console.WriteLine("Please, enter the number of available destinations: ");
            string input = Console.ReadLine();
            bool res = Int32.TryParse(input, out destinationsCount);
            while (res == false || destinationsCount < 0)
            {
                Console.WriteLine("You entered wrong data, please, try again...");
                input = Console.ReadLine();
            }
            return destinationsCount;
        }
        static int GetStrategy()
        {
            int strategy;
            Console.WriteLine("Please choose the destination selection strategy:\n 1) Round robin(1,2,3,...,N, 1,2,3...N) \n 2) Random ");
            string input = Console.ReadLine();
            bool res = Int32.TryParse(input, out strategy);
            while (res == false || !(strategy == 1 || strategy == 2))
            {
                Console.WriteLine("You entered wrong data, please, try again...");
                input = Console.ReadLine();
            }
            return strategy;
        }
        static int GetSequenceLenght()
        {
            int sequenceLength;
            Console.WriteLine("Input loads sequence length: ");
            string input = Console.ReadLine();
            bool res = Int32.TryParse(input, out sequenceLength);
            while (res == false || !(sequenceLength >= 1))
            {
                Console.WriteLine("You entered wrong data, please, try again...");
                input = Console.ReadLine();
            }
            return sequenceLength;
        }
        static int GetLoadsCount()
        {
            int loadsCount;
            Console.WriteLine("Input loads count: ");
            string input = Console.ReadLine();
            bool res = Int32.TryParse(input, out loadsCount);
            while (res == false || (loadsCount < 0))
            {
                Console.WriteLine("You entered wrong data, please, try again...");
                input = Console.ReadLine();
            }
            return loadsCount;
        }
        static double GetPercentageOfFail()
        {
            double percentageOfFail;
            Console.WriteLine("Input percentage of failure for load to be diverted: ");
            string input = Console.ReadLine();
            while (!Double.TryParse(input, out percentageOfFail) || (percentageOfFail < 0 || percentageOfFail > 100))
            {
                Console.WriteLine("You entered wrong data, please, try again...");
                input = Console.ReadLine();
            }
            return percentageOfFail;
        }
    }
}

