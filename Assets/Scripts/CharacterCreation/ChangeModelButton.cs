using System.Collections.Generic;
using Duskland.Character;
using Duskland.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Duskland.CharacterCreation
{
    public class ChangeModelButton : MonoBehaviour
    {
        private CustomizeModel _characterCreator;

        public bool isLeft;

        public AppearanceDetail detail;

        void Start()
        {
            var btn = gameObject.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);

            _characterCreator = GameObject.Find("CharacterCreationUI").GetComponent<CustomizeModel>();
        }

        void TaskOnClick()
        {
            _characterCreator.ChangeModel(isLeft, detail);
        }
    }
}
