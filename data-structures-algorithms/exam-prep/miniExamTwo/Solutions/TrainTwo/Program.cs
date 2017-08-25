using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace TrainTwo
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var totalRequests = input[0];
            var trainCapacity = input[1];
            var totalStops = input[2];

            var allRequests = new Request[totalRequests];

            for (int i = 0; i < totalRequests; i++)
            {
                var inpt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                allRequests[i] = new Request(inpt[0], inpt[1]);
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

        public override int GetHashCode()
        {
            return this.From.GetHashCode() + this.To.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Request;
            return this.From == other.From && this.To == other.To;
        }

        public int CompareTo(object obj)
        {
            var other = obj as Request;
            return this.From.CompareTo(other.From) == 0 ? this.To.CompareTo(other.To) : this.From.CompareTo(other.From);
        }
    }
}
