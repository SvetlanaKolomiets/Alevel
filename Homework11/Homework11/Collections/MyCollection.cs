using System.Collections.ObjectModel;
using Homework11.Collections.Enumerators;

namespace Homework11.Collections
{
	public class MyCollection<T> : Collection<T>
	{
        private List<T> _items;

        public MyCollection()
		{
            _items = new List<T>();
		}

        public T this[int index] => _items[index];

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public void Sort(Comparison<T> comparison)
        {
            if (_items is List<T> list)
            {
                list.Sort(comparison);
            }
            else
            {
                throw new Exception("Can't sort a collection");
            }
        }

        public new void Add(T item)
        {
            _items.Add(item);
        }

        public void SetDefaulAt(int index, T defaultItem)
        {
            if (index >= 0 && index < this.Count)
            {
                _items[index] = defaultItem;
            }
            else
            {
                throw new Exception("Can't set a default item");
            }
            
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return new MyCollectionEnumerator<T>(this);
        }

    }
}

