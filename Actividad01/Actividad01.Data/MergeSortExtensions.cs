using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Actividad01.Data
{
    public static class MergeSortExtensions
    {
        public static IEnumerable<T> Merge<T,TKey>(this IEnumerable<T> firstPart, IEnumerable<T> secondPart, Func<T,TKey> compareFunc = null) {
            List<T> result = new List<T>(), l1 = new List<T>(firstPart), l2 = new List<T>(secondPart);
            while (l1.Count > 0 && l2.Count > 0)
            {
                var f1 = l1.First();
                var f2 = l2.First();
                var v1 = compareFunc(f1);
                var v2 = compareFunc(f2);
                if (v1 is IComparable)
                {
                    var c1 = v1 as IComparable;
                    var c2 = v2 as IComparable;
                    if (c1.CompareTo(c2) > 0)
                    {
                        result.Add(f2);
                        l2.Remove(f2);
                    }
                    else
                    {
                        result.Add(f1);
                        l1.Remove(f1);
                    }
                }             
               
               
            }
            while (l1.Count > 0)
            {
                result.Add(l1.First());
                l1.RemoveAt(0);
            }
            while (l2.Count > 0)
            {
                result.Add(l2.First());
                l2.RemoveAt(0);

            }
            return result;
        }

        public static IEnumerable<T> MergeSort<T,TKey>(this IEnumerable<T> sequence, Func<T,TKey> compareFunc = null){
            if (!(compareFunc.Method.ReturnType.GetInterfaces().Contains(typeof(IComparable))))
                throw new InvalidOperationException("El tipo " + compareFunc.Method.ReturnType.Name + " no es comparable");
            if (sequence.Count() <= 1)
                return sequence;
            int midle = sequence.Count()/2;
            var left = sequence.Take(midle);
            var right = sequence.Skip(midle);
            right=right.MergeSort(compareFunc);
            left=left.MergeSort(compareFunc);
            var result = right.Merge(left,compareFunc);
            return result;
        }
        

    }
}
