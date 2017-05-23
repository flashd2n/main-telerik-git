using CarsTask.Models.Interfaces;

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
