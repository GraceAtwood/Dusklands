using System;
using Duskland.Enums;
using Humanizer;
using UnityEngine;
using TMPro;

namespace Duskland.CharacterCreation
{
    public class ChangeGenderButton : MonoBehaviour
    {
        private CustomizeModel characterCreator;
        private TextMeshProUGUI childText;

        public GameObject creationUI;

        private void Start()
        {
            characterCreator = creationUI.GetComponent<CustomizeModel>();

            childText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void OnClick()
        {
            characterCreator.ChangeGender();
            childText.text = characterCreator.currentGender.Humanize().Pascalize();
        }
    }
}
