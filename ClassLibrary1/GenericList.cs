using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Training.Dergai.Lesson6
{
    public class GenericList<T> : IEnumerable<T>
    {
        private T[] _list = Array.Empty<T>();

        public void Add(T x)
        {
            _list = _list.Append(x).ToArray();
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return item;
            }
        }

        public void Remove(T x)
        {
            var index = Array.IndexOf(_list, x);

            _list = _list.Where((x, i) => i != index).ToArray();
        }

        public void RemoveRange(int startIndex, int length)
        {
            if (_list == null)
            {
                throw new ArgumentNullException("NULL");
            }
                
            var newArray = _list.Take(startIndex).Concat(_list.Skip(startIndex + length)).ToArray();

            _list = newArray;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
