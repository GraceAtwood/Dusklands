using System.Collections.Generic;
using System.Linq;
using Duskland.Enums;
using Duskland.Utilities;
using UnityEngine;

namespace Duskland.Character
{
    public class BodyPart : MonoBehaviour
    {
        public BodyLocation bodyLocation;
        public string bodyPartName;
        public Gender gender = Gender.NONE;

        public void Hide() => gameObject.SetActive(false);

        public void Show() => gameObject.SetActive(true);
    }
}