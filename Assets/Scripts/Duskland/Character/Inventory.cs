using System.Collections;
using System.Collections.Generic;

namespace Duskland.Character
{
    public class Inventory : ICollection<Item>
    {
        public float Weight { get; private set; }

        private readonly List<Item> _items = new List<Item>();

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Item item)
        {
            if (item == null)
                return;

            _items.Add(item);
            Weight += item.weight;
        }

        public void Clear()
        {
            _items.Clear();
            Weight = 0;
        }

        public bool Contains(Item item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(Item item)
        {
            if (item == null)
            {
                return false;
            }

            if (_items.Remove(item))
            {
                Weight -= item.weight;
                return true;
            }

            return false;
        }

        public int Count => _items.Count;
        public bool IsReadOnly => false;
    }
}