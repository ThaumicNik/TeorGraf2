using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeorGraf2
{
    class Graph
    {
        // Представление графа в виде списка смежности
        private Dictionary<int, List<int>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<int, List<int>>();
        }

        // Добавление рёбер в граф
        public void AddEdge(int from, int to)
        {
            if (!adjacencyList.ContainsKey(from))
                adjacencyList[from] = new List<int>();
            adjacencyList[from].Add(to);
        }

        // Метод для поиска кратчайшего пути от start до end с помощью BFS
        public List<int> BFS(int start, int end)
        {
            // Если start и end совпадают, возвращаем путь, состоящий только из start
            if (start == end) return new List<int> { start };

            // Очередь для BFS
            Queue<int> queue = new Queue<int>();
            // Словарь для отслеживания посещённых вершин
            HashSet<int> visited = new HashSet<int>();
            // Словарь для восстановления пути
            Dictionary<int, int> parent = new Dictionary<int, int>();

            // Начинаем с вершины start
            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                // Если мы достигли целевой вершины, восстанавливаем путь
                if (current == end)
                {
                    List<int> path = new List<int>();
                    for (int vertex = end; vertex != start; vertex = parent[vertex])
                    {
                        path.Add(vertex);
                    }
                    path.Add(start);
                    path.Reverse();  // Путь строился от конца к началу
                    return path;
                }

                // Проходим по соседям текущей вершины
                foreach (var neighbor in adjacencyList.GetValueOrDefault(current, new List<int>()))
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        parent[neighbor] = current;  // Сохраняем текущую вершину как родителя для восстановления пути
                        queue.Enqueue(neighbor);
                    }
                }
            }

            // Если путь не найден, возвращаем пустой список
            return new List<int>();
        }
    }
}
