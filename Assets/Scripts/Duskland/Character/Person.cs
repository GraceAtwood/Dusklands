using UnityEngine;

namespace Duskland.Character
{
    public abstract class Person : MonoBehaviour
    {
        public EquippedItemsCollection EquippedItems { get; } = new EquippedItemsCollection();

        public Inventory Inventory { get; } = new Inventory();

        public Body Body { get; } = new Body();
    }
}