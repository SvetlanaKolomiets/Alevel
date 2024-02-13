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

        public new T this[int index] => _items[index];

        public new int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public void BubbleSort(Comparison<T> comparison)
        {
            var count = _items.Count;
            for (var i = 1; i < count; i++)
            {
                for (var j = 0; j < count - i; j++)
                {
                    if (comparison(_items[j], _items[j + 1]) > 0)
                    {
                        var temp = _items[j];
                        _items[j] = _items[j + 1];
                        _items[j + 1] = temp;
                    }
                }
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

