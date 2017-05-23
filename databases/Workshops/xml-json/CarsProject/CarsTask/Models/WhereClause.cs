using CarsTask.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsTask.Models
{
    public class WhereClause : IWhereClause
    {
        public WhereClause(string property, Operation type, string value)
        {
            this.Property = property;
            this.Type = type;
            this.Value = value;
        }

        public string Property { get; set; }
        public Operation Type { get; set; }
        public string Value { get; set; }
    }
}
