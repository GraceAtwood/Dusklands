using Duskland.Enums;
using UnityEngine;

namespace Duskland.Character
{
    public class BodyPart : MonoBehaviour
    {
        public BodyLocation bodyLocation = BodyLocation.NONE;
        public Gender gender = Gender.NONE;

        public void Hide() => gameObject.SetActive(false);

        public void Show() => gameObject.SetActive(true);
    }
}