using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace Train
{
    class Startup
    {
        static void Main()
        {
            var firstInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var potentialPassangers = firstInput[0];
            var trainCapacity = firstInput[1];
            var totalStops = firstInput[2];

            var allRequests = new Request[potentialPassangers];

            for (int i = 0; i < potentialPassangers; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                allRequests[i] = new Request(input[0], input[1]);
            }

            Array.Sort(allRequests);

            var tickets = new OrderedBag<int>();
            var result = 0;

            foreach (var request in allRequests)
            {
                while (tickets.Count != 0 && tickets.GetFirst() <= request.From)
                {
                    ++result;
                    tickets.RemoveFirst();
                }

                tickets.Add(request.To);

                if (tickets.Count > trainCapacity)
                {
                    tickets.RemoveLast();
                }
            }

            result += tickets.Count;
            Console.WriteLine(result);            
        }

    }
    class Request : IComparable
    {
        public Request(int from, int to)
        {
            this.From = from;
            this.To = to;
        }

        public int From { get; set; }
        public int To { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Request;

            return this.From.CompareTo(other.From) == 0 ? this.To.CompareTo(other.To) : this.From.CompareTo(other.From);
        }
    }

}
