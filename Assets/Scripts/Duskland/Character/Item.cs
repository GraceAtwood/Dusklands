using System.Collections.Concurrent;
using System.Collections.Generic;
using Duskland.Enums;
using UnityEngine;

namespace Duskland.Character
{
    public class Item : MonoBehaviour
    {
        public static HashSet<Item> AllItems { get; }

        static Item()
        {
            AllItems = new HashSet<Item>();
        }

        public Person Owner { get; set; }

        public EquipmentSlot equipmentSlot = EquipmentSlot.NONE;
        public List<ItemModifier> modifiers = new List<ItemModifier>();
        public string itemName;
        public float weight = -1;
        public List<AppearanceDetail> occludesBodyParts = new List<AppearanceDetail>();

        public ConcurrentDictionary<Modifier, float> Modifiers { get; } = new ConcurrentDictionary<Modifier, float>();

        private void Start()
        {
            foreach (var itemModifier in modifiers)
            {
                Modifiers.AddOrUpdate(itemModifier.modifier, itemModifier.value, (modifier, f) => f + itemModifier.value);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}