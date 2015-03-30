using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actividad01.Data.Util
{
    public class GraphNode<T> where T : IComparable
    {
        public T Data { get; set; }
        public List<GraphArist<T>> Arists { get; set; }

        public GraphNode()
        {
            Arists = new List<GraphArist<T>>();
        }
        public void AddArist(GraphNode<T> to, double dist)
        {
            if (!Arists.Any(a => a.To.Data.CompareTo(to.Data) == 0))
            {
                Arists.Add(new GraphArist<T>(this, to, dist));
                to.AddArist(this, dist);
            }
        }
    }
}
