namespace Structures
{
    public class HeuristicNode
    {
        public HeuristicNode(int vertex, int weight, int heuristicValue)
        {
            this.Vertex = vertex;
            this.Weight = weight;
            this.HeuristicValue = heuristicValue;
        }

        public int Vertex { get; set; }
        public int HeuristicValue { get; set; }
        public int Weight { get; set; }
    }
}
