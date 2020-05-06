using Duskland.Enums;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace Duskland.CharacterCreation
{
    public class ChangeGenderButton : MonoBehaviour
    {
        private CustomizeModel _characterCreator;

        public GameObject creationUI;

        public Gender gender;

        void Start()
        {
            //var btn = gameObject.GetComponent<Button>();
            //btn.onClick.AddListener(TaskOnClick);

            _characterCreator = creationUI.GetComponent<CustomizeModel>();
        }

        public void OnClick()
        {
            Debug.Log("This is getting pressed");

            if(_characterCreator.currentGender == Gender.Male)
            {
                _characterCreator.ChangeGender(Gender.Female);
                GetComponentInChildren<TextMeshProUGUI>().text = "Female";
            }
            else
            {
                _characterCreator.ChangeGender(Gender.Male);
                GetComponentInChildren<TextMeshProUGUI>().text = "Male";
            }
        }
    }
}
