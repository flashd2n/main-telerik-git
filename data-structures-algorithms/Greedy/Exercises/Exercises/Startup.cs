using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    class Startup
    {
        static void Main()
        {
            var activitiesCount = int.Parse(Console.ReadLine());

            var activities = new Activity[activitiesCount];

            for (int i = 0; i < activitiesCount; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                activities[i] = new Activity(input[0], input[1]);
            }

            Array.Sort(activities, (a, b) => a.Start.CompareTo(b.Start));

            var result = 0;
            var currentActivity = activities[0];

            for (int i = 1; i < activities.Length; i++)
            {
                if (currentActivity.End <= activities[i].Start)
                {
                    Console.WriteLine($"Finished Activity: ({currentActivity.Start}, {currentActivity.End})");
                    ++result;
                    currentActivity = activities[i];
                    continue;
                }

                if (currentActivity.End <= activities[i].End)
                {
                    continue;
                }
                else
                {
                    currentActivity = activities[i];
                }

            }
            Console.WriteLine($"Finished Activity: ({currentActivity.Start}, {currentActivity.End})");
            ++result;

            Console.WriteLine(result);
        }
    }

    class Activity
    {
        public Activity(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public int Start { get; set; }
        public int End { get; set; }
    }
}
