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
            List<T> resutl = new List<T>();
            while (firstPart.Count() > 0 && secondPart.Count() > 0)
            {
                
                //if (firstPart.First().GetHashCode() <= secondPart.First().GetHashCode()) { 
                //    resutl.Add(firstPart.First())
                //}
            }
            return firstPart;
        }

        public static IEnumerable<T> MergeSort<T,TKey>(this IEnumerable<T> sequence, Func<T,TKey> compareFunc = null){
            if (sequence.Count() <= 1)
                return sequence;
            int midle = sequence.Count()/2;
            var left = sequence.Take(midle);
            var right = sequence.Skip(midle);
            right.MergeSort(compareFunc);
            left.MergeSort(compareFunc);
            var result = right.Merge(left,compareFunc);
            return result;
        }
        

    }
}
