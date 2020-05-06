using UnityEngine;
using TMPro;

namespace Duskland.CharacterCreation
{
    public class ChangeGenderButton : MonoBehaviour
    {
        private CustomizeModel characterCreator;

        public GameObject creationUI;

        private void Start()
        {
            characterCreator = creationUI.GetComponent<CustomizeModel>();
        }

        public void OnClick()
        {
            if(characterCreator.currentGender == Gender.Male)
            {
                characterCreator.ChangeGender(Gender.Female);
                GetComponentInChildren<TextMeshProUGUI>().text = "Female";
            }
            else
            {
                characterCreator.ChangeGender(Gender.Male);
                GetComponentInChildren<TextMeshProUGUI>().text = "Male";
            }
        }
    }
}
