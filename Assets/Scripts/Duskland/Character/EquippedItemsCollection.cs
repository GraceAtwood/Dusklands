using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Duskland.Enums;

namespace Duskland.Character
{
    public class EquippedItemsCollection : IDictionary<EquipmentSlot, Item>
    {
        private readonly Dictionary<EquipmentSlot, Item> equippedItems = new Dictionary<EquipmentSlot, Item>();

        public Dictionary<Modifier, float> TotalModifiers { get; } = new Dictionary<Modifier, float>();

        public IEnumerator<KeyValuePair<EquipmentSlot, Item>> GetEnumerator()
        {
            return equippedItems.GetEnumerator();
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
            foreach (var item in equippedItems.Select(x => x.Value))
            {
                item.Hide();
            }
        }

        public bool Contains(KeyValuePair<EquipmentSlot, Item> item)
        {
            return equippedItems.TryGetValue(item.Key, out var equippedItem) && equippedItem.Equals(item.Value);
        }

        public void CopyTo(KeyValuePair<EquipmentSlot, Item>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<EquipmentSlot, Item> item)
        {
            if (!Contains(item))
                return false;

            equippedItems.Remove(item.Key);

            return true;
        }

        public int Count => equippedItems.Count;
        public bool IsReadOnly => false;

        public void Add(EquipmentSlot key, Item value)
        {
            equippedItems.Add(key, value);
        }

        public bool ContainsKey(EquipmentSlot key)
        {
            return equippedItems.ContainsKey(key);
        }

        public bool Remove(EquipmentSlot key)
        {
            return equippedItems.Remove(key);
        }

        public bool TryGetValue(EquipmentSlot key, out Item value)
        {
            return equippedItems.TryGetValue(key, out value);
        }

        public Item this[EquipmentSlot key]
        {
            get => equippedItems[key];
            set => equippedItems[key] = value;
        }

        public ICollection<EquipmentSlot> Keys => equippedItems.Keys;
        public ICollection<Item> Values => equippedItems.Values;
    }
}