using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Collections
{
    public class MyDictionary<T> : ICloneable, IEnumerable<T> where T : ICloneable
    {
        protected T[] _items = new T[50];
        public T[] Values
        {
            get
            {
                var t = new List<T>(0);
                foreach (T item in _items)
                    if (item.Equals(default(T)) || item.Equals(null))
                        t.Add(item);

                return t.ToArray();
            }
        }
        protected float FillRatio = 0.72f;

        protected int Capacity
        {
            get { return _items.Length; }
            set
            {
                if (Count < value)
                    itemCount = value;

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
        protected int itemCount;

        public int Count
        {
            get { return itemCount; }
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
            foreach (T b in obj)
                Add(b);
        }
        public MyDictionary(IEnumerable<T> obj, float FillRatio)
        {
            this.FillRatio = FillRatio;
            Capacity = obj.Count();
            foreach (T b in obj)
                Add(b);
        }

        #endregion

        public void Clear()
        {
            Capacity = 0;
            itemCount = 0;
        }
        public object Clone()
        {
            return new MyDictionary<T>((T[])_items.Clone());
        }
        
        public void Add(T o)
        {
            while (Math.Abs(Count - Capacity*FillRatio) < 0.03f ||
               Exists(Array.IndexOf(_items, o)))
                Capacity *= 2;

            _items[o.GetHashCode()%Capacity] = o;
            itemCount++;
        }
        public void AddRange(IEnumerable<T> o)
        {
            foreach (T item in o)
                Add(item);
        }
        public void Remove(T o)
        {
            int index = Array.IndexOf(_items, o);

            if (index >= 0 && index <= Capacity)
                _items[index] = default(T);
            else
                throw new IndexOutOfRangeException();
        }

        public bool ContainsValue(T o)
        {
            return _items.Contains(o);
        }
        protected bool Exists(int index)
        {
            return _items[index].Equals(default(T)) || _items[index].Equals(null);
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