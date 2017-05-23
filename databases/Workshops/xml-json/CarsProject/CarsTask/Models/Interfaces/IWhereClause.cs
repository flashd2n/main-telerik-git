namespace CarsTask.Models.Interfaces
{
    public interface IWhereClause
    {
        string Property { get; set; }
        Operation Type { get; set; }
        string Value { get; set; }
    }
}
