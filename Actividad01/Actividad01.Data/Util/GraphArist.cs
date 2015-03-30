using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actividad01.Data.Util
{
    public class GraphArist<T> where T : IComparable
    {
        public GraphNode<T> From { get; set; }
        public GraphNode<T> To { get; set; }

        public double Distance { get; set; }

        public GraphArist(GraphNode<T> from, GraphNode<T> to, double dist)
        {
            From = from;
            To = to;
            Distance = dist;
        }
    }
}
