using UnityEngine;

namespace Duskland.CharacterCreation
{
    public class ColorPanelSwitcher : MonoBehaviour
    {
        public GameObject primaryPanel;
        public GameObject[] secondaryPanels;

        public void OnClick()
        {
            primaryPanel.SetActive(!primaryPanel.activeSelf);
            foreach (var secondaryPanel in secondaryPanels)
            {
                secondaryPanel.SetActive(false);
            }
        }
    }
}
