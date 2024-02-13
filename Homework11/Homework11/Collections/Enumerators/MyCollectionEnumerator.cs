using System.Collections;

namespace Homework11.Collections.Enumerators
{
	public class MyCollectionEnumerator<T> : IEnumerator<T>
	{
        private MyCollection<T> _items;
        private int _counter = -1;

        public MyCollectionEnumerator(MyCollection<T> items)
		{
            _items = items;
        }

        public T Current => _items[_counter];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _counter = -1;
        }

        public bool MoveNext()
        {
            ++_counter;
            if (_items.Count > _counter)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _counter = -1;
        }
    }
}

