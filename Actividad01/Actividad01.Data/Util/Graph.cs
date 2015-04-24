using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Actividad01.Data.Util
{
    public class Graph<T> where T: IComparable
    {
        public List<GraphNode<T>> Nodes { get; set; }

        public GraphNode<T> Root { get { return Nodes.FirstOrDefault(); } }

        public Graph()
        {
            Nodes = new List<GraphNode<T>>();
        }

        public GraphNode<T> AddNode(T value)
        {
            GraphNode<T> node = Nodes.Where(n => n.Data.CompareTo(value) == 0).FirstOrDefault();
            if (node == null)
            {
                var n = new GraphNode<T>() { Data = value };
                Nodes.Add(n);
                return n;
            }
            return node;
        }

        public void AddArist(T from, T to, double dist)
        {
            var fromNode = AddNode(from);
            var toNode = AddNode(to);
            fromNode.AddArist(toNode, dist);   
        }

        public T FindFromRoot(T value)
        {
            if (Root == null)
                return default(T);
            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>>();
            List<T> visited = new List<T>();
            visited.Add(Root.Data);
            queue.Enqueue(Root);           
            do
            {
                var n = queue.Dequeue();                
                Debug.WriteLine(n.Data);
                if (n.Data.CompareTo(value) == 0) return n.Data;
                foreach (var arist in n.Arists)
                {
                    if (!visited.Contains(arist.To.Data))
                    {
                        queue.Enqueue(arist.To);
                        visited.Add(arist.To.Data);
                    }
                }

            } while (queue.Count > 0);

            return default(T);
        }

        public Graph<T> GetMSTByPrim() {
            var mst = new Graph<T>();
            int nodeCount =  this.Nodes.Count;
            mst.AddNode(Root.Data);
            HashSet<GraphNode<T>> visited = new HashSet<GraphNode<T>>();
            visited.Add(Root);
            while (visited.Count < nodeCount)
            {
                SortedList<double, GraphArist<T>> edges = new SortedList<double, GraphArist<T>>();
                foreach (var item in visited)
                {
                    item.Arists.ForEach(e =>
                    {
                        if (!visited.Contains(e.To) && !edges.ContainsKey(e.Distance)) {
                            edges.Add(e.Distance, e);
                        }
                    });
                }

                var first = edges.First();
                visited.Add(first.Value.To);
                mst.AddNode(first.Value.To.Data);
                mst.AddArist(first.Value.From.Data, first.Value.To.Data, first.Value.Distance);                
            }
            return mst;
        }

        public void PrintEdges() {
            var vistes = new HashSet<T>();
            Nodes.ForEach(n => n.Arists.ForEach(a => {
                //Console.WriteLine(string.Format("{0} -> {1}: {2}", a.From.Data, a.To.Data, a.Distance));
                vistes.Add(n.Data);
                if (!vistes.Contains(a.To.Data))
                {
                    Debug.WriteLine(string.Format("{0} -> {1}: {2}", a.From.Data, a.To.Data, a.Distance));
                    Trace.WriteLine(string.Format("{0} -> {1}: {2}", a.From.Data, a.To.Data, a.Distance));
                }
            }));
        }





    }
}
