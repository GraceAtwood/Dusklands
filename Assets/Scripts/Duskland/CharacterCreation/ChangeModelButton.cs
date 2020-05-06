using Duskland.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Duskland.CharacterCreation
{
    public class ChangeModelButton : MonoBehaviour
    {
        private CustomizeModel characterCreator;

        public bool isLeft;

        public AppearanceDetail detail;

        private void Start()
        {
            var btn = gameObject.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);

            characterCreator = GameObject.Find("CharacterCreationUI").GetComponent<CustomizeModel>();
        }

        private void TaskOnClick()
        {
            characterCreator.ChangeModel(isLeft, detail);
        }
    }
}
