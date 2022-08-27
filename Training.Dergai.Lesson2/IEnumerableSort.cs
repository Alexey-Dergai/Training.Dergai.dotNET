using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dergai.Lesson2
{
    public static class SortExtension
    {
        public enum SortDirection
        {
            Ascending,
            Descending
        }
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> collection, SortDirection sortDirection) where T : IComparable<T>
        {
            var sortedCollection = collection.ToList();

            for (var i = 0; i < sortedCollection.Count; i++)
            {
                for (var j = i + 1; j < sortedCollection.Count; j++)
                {
                    if ((sortDirection == SortDirection.Ascending && sortedCollection[i].CompareTo(sortedCollection[j]) > 0) || (sortDirection == SortDirection.Descending && sortedCollection[i].CompareTo(sortedCollection[j]) < 0))
                    {
                        (sortedCollection[i], sortedCollection[j]) = (sortedCollection[j], sortedCollection[i]);
                    }
                }
            }

            return sortedCollection;
        }
    }
}
