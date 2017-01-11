using StudentsAndWorkers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndWorkers
{
    class Worker : Human, IHuman, IWorker
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set { weekSalary = value; }
        }
        public int WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set { workHoursPerDay = value; }
        }

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal MoneyPerHour()
        {
            decimal hourlySalary = (this.WeekSalary / 5M) / workHoursPerDay;
            return hourlySalary;
        }
    }
}
