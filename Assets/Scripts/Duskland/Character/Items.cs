using System.Collections.Generic;

namespace Duskland.Character
{
    public static class Items
    {
        public static HashSet<Item> AllItems { get; }

        static Items()
        {
            AllItems = new HashSet<Item>();
        }
    }
}