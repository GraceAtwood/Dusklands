using System.Collections.Generic;
using System.Linq;
using Duskland.CharacterCreation;
using Duskland.Enums;
using UnityEngine;

namespace Duskland.Character
{
    public static class Items
    {
        public static readonly HashSet<Item> AllItems;
        
        static Items()
        {
            var items = new HashSet<Item>();
            
            foreach (var parentItemDescriptor in Object.FindObjectsOfType<ParentItemDescriptor>())
            {
                var children = parentItemDescriptor.gameObject.transform
                    .Cast<Transform>()
                    .Select(x => x.gameObject)
                    .ToList();

                foreach (var child in children)
                {
                    if (child.TryGetComponent(typeof(Item), out var component))
                    {
                        var item = (Item) component;

                        if (item.equipmentSlot == EquipmentSlot.NONE)
                            item.equipmentSlot = parentItemDescriptor.equipmentSlot;

                        items.Add(item);
                    }
                    else
                    {
                        var item = child.AddComponent<Item>();

                        item.equipmentSlot = parentItemDescriptor.equipmentSlot;
                        
                        items.Add(item);
                    }
                }
            }

            AllItems = items;
        }
    }
}