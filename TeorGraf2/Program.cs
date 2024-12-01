namespace TeorGraf2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            // Пример добавления рёбер в граф
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);

            // Поиск кратчайшего пути от вершины 1 до вершины 5
            List<int> path = graph.BFS(1, 5);

            if (path.Count > 0)
            {
                Console.WriteLine("Кратчайший путь:");
                foreach (var vertex in path)
                {
                    Console.Write(vertex + " ");
                }
            }
            else
            {
                Console.WriteLine("Путь не найден.");
            }
        }
    }
}