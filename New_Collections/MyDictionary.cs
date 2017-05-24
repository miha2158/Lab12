using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Collections
{
    public class MyDictionary<T> : ICloneable, IEnumerable<T> where T : ICloneable, IEnumerator<T>
    {
        protected T[] _items = new T[50];
        protected float FillRatio = 0.72f;

        protected int Capacity
        {
            get { return _items.Length; }
            set
            {
                if (Capacity < value)
                    current = value;

                var temp = new T[value];
                try
                {
                    foreach (T item in _items)
                    {
                        temp[item.GetHashCode() % value] = item;
                    }
                }
                catch (Exception)
                {
                }

                _items = temp;
            }
        }
        protected int current;

        public int Count
        {
            get { return current; }
        }
        public object this[int i]
        {
            get { return _items[i]; }
        }

        #region Initialise

        public MyDictionary()
        {

        }
        public MyDictionary(float FillRatio)
        {
            this.FillRatio = FillRatio;
        }

        public MyDictionary(int capacity)
        {
            Capacity = capacity;
        }
        public MyDictionary(int capacity, float FillRatio)
        {
            this.FillRatio = FillRatio;
            Capacity = capacity;
        }

        public MyDictionary(IEnumerable<T> obj)
        {
            Capacity = obj.Count();
            _items = obj.ToArray();
        }
        public MyDictionary(IEnumerable<T> obj, float FillRatio)
        {
            this.FillRatio = FillRatio;
            Capacity = obj.Count();
            _items = obj.ToArray();
        }

        #endregion

        public void Clear()
        {
            Capacity = 0;
            current = 0;
        }
        public object Clone()
        {
            return new MyDictionary<T>(_items);
        }
        

        public void Add(T o)
        {
            if (Math.Abs(Count - Capacity*FillRatio) < 0.01f)
                Capacity *= 2;

            _items[current++] = o;
        }
        public void Remove(T o)
        {
            int index = Array.IndexOf(_items, o);

            if (index >= 0 && index <= Capacity)
            {
                for (int i = index; i < Count; i++)
                    _items[i] = _items[i + 1];

                current--;
            }
            else
                throw new IndexOutOfRangeException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)_items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}