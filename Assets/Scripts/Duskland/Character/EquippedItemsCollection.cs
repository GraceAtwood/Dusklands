using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Duskland.Enums;

namespace Duskland.Character
{
    public class EquippedItemsCollection : IDictionary<EquipmentSlot, Item>
    {
        private Dictionary<EquipmentSlot, Item> _equippedItems = new Dictionary<EquipmentSlot, Item>();

        public Dictionary<Modifier, float> TotalModifiers { get; } = new Dictionary<Modifier, float>();
        
        public IEnumerator<KeyValuePair<EquipmentSlot, Item>> GetEnumerator()
        {
            return _equippedItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<EquipmentSlot, Item> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            foreach (var item in _equippedItems.Select(x => x.Value))
            {
                item.Hide();
            }
        }

        public bool Contains(KeyValuePair<EquipmentSlot, Item> item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(KeyValuePair<EquipmentSlot, Item>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<EquipmentSlot, Item> item)
        {
            throw new System.NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
        public void Add(EquipmentSlot key, Item value)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsKey(EquipmentSlot key)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(EquipmentSlot key)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetValue(EquipmentSlot key, out Item value)
        {
            throw new System.NotImplementedException();
        }

        public Item this[EquipmentSlot key]
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public ICollection<EquipmentSlot> Keys { get; }
        public ICollection<Item> Values { get; }
    }
}