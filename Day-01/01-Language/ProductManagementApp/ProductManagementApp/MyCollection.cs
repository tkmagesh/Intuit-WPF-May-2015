using System.Collections;
using System.Collections.Generic;

namespace ProductManagementApp
{
    public class MyCollection<T> : IEnumerable, IEnumerator, IEnumerator<T>, IEnumerable<T>
    {
        private ArrayList _list = new ArrayList();

        public void Add(T item )
        {
            _list.Add(item);
        }

        public T this[int index]
        {
            get { return (T) _list[index]; }
            set { _list[index] = value; }
        }
        public T Get(int index)
        {
            return (T) _list[index];
        }

        public int Count
        {
            get { return _list.Count; }
        }
        //Add
        //Removing
        //Get a product by index
        //Count
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        private int _index = -1;
        public bool MoveNext()
        {
            ++_index;
            if (_index < _list.Count)
            {
                return true;
            } else 
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            _index = -1;
        }

        T IEnumerator<T>.Current
        {
            get { return (T) _list[_index]; }
        }

        public object Current {
            get { return _list[_index]; }
        }

       


        public void Dispose()
        {
            
        }
    }
}