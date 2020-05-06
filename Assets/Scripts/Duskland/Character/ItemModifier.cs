using System;
using Duskland.Enums;

namespace Duskland.Character
{
    [Serializable]
    public struct ItemModifier
    {
        public Modifier modifier;
        public float value;
    }
}