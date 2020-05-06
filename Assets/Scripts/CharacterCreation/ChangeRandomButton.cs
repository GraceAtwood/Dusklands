using Duskland.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Duskland.CharacterCreation
{
    public class ChangeRandomButton : MonoBehaviour
    {
        private CustomizeModel _characterCreator;

        void Start()
        {
            var btn = gameObject.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);

            _characterCreator = GameObject.Find("CharacterCreationUI").GetComponent<CustomizeModel>();
        }

        void TaskOnClick()
        {
            _characterCreator.ChangeRandom();
        }
    }
}
