namespace Algorithms.Graph
{
    public static class FloydWarshall
    {
        public static int[,] RunFloydWarshall(int[,] graph)
        {
            var infinity = 99999;
            var distances = new int[graph.GetLength(0), graph.GetLength(1)];

            for (int i = 1; i < graph.GetLength(0); i++)
            {
                for (int j = 1; j < graph.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        distances[i, j] = 0;
                        continue;
                    }

                    if (graph[i, j] == 0)
                    {
                        distances[i, j] = infinity;
                        continue;
                    }

                    distances[i, j] = graph[i, j];
                }
            }

            for (int k = 1; k < graph.GetLength(0); k++)
            {
                for (int i = 1; i < graph.GetLength(0); i++)
                {
                    for (int j = 1; j < graph.GetLength(0); j++)
                    {
                        if (distances[i, j] > distances[i, k] + distances[k, j])
                        {
                            distances[i, j] = distances[i, k] + distances[k, j];
                        }
                    }
                }
            }

            return distances;
        }
    }
}
