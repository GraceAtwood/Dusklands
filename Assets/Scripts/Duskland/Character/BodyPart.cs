using System.Collections.Generic;
using System.Linq;
using Duskland.Enums;
using Duskland.Utilities;
using UnityEngine;

namespace Duskland.Character
{
    public class BodyPart : MonoBehaviour
    {
        public BodyLocation bodyLocation = BodyLocation.NONE;
        public string bodyPartName;
        public Gender gender = Gender.NONE;
    }
}