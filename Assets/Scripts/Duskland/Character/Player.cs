using Duskland.Enums;
using UnityEngine;

namespace Duskland.Character
{
    public class Player : MonoBehaviour
    {
        public EquippedItemsCollection EquippedItems { get; } = new EquippedItemsCollection();

        public Inventory Inventory { get; } = new Inventory();

        public Body Body { get; } = new Body();
    }
}