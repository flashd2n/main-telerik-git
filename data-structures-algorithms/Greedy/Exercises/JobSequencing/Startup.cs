using System;
using System.Linq;

namespace JobSequencing
{
    class Startup
    {
        static void Main()
        {
            var jobsCount = int.Parse(Console.ReadLine());
            var jobs = new Job[jobsCount];

            for (int i = 0; i < jobsCount; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                jobs[i] = new Job(input[0], input[1], input[2]);
            }

            Array.Sort(jobs, (a, b) => b.Profit.CompareTo(a.Profit));
            
            var currentJob = jobs[0];
            var profit = currentJob.Profit;

            var takenDeadlines = new int[101];
            ++takenDeadlines[currentJob.Deadline];

            for (int i = 1; i < jobsCount; i++)
            {
                var nextJobDeadline = jobs[i].Deadline;

                if (IsDeadlinePossible(nextJobDeadline, takenDeadlines))
                {
                    ++takenDeadlines[nextJobDeadline];
                    profit += jobs[i].Profit;
                }
            }

            Console.WriteLine(profit);

        }

        private static bool IsDeadlinePossible(int nextJobDeadline, int[] takenDeadlines)
        {
            // can improve by introducing start and end markers -> the earliest taken job and the latest taken job, this will limit the loops a lot
            var isPossible = true;

            var preTakenJobs = 0;

            for (int i = 1; i <= nextJobDeadline; i++)
            {
                preTakenJobs += takenDeadlines[i];
            }

            if (preTakenJobs >= nextJobDeadline)
            {
                return false;
            }

            for (int i = nextJobDeadline + 1; i < takenDeadlines.Length; i++)
            {
                if (preTakenJobs + takenDeadlines[i] >= i)
                {
                    return false;
                }
            }

            return isPossible;
        }
    }

    class Job
    {
        public Job(int id, int deadline, int profit)
        {
            this.Id = id;
            this.Deadline = deadline;
            this.Profit = profit;
        }

        public int Id { get; set; }
        public int Deadline { get; set; }
        public int Profit { get; set; }
    }
}
