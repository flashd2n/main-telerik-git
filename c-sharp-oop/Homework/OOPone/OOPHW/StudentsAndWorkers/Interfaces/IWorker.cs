using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndWorkers.Interfaces
{
    interface IWorker
    {
        decimal WeekSalary { get; set; }
        int WorkHoursPerDay { get; set; }
        decimal MoneyPerHour();

    }
}
