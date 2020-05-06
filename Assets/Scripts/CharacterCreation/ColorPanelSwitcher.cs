using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPanelSwitcher : MonoBehaviour
{
    public GameObject primaryPanel;
    public GameObject[] secondaryPanels;

    public void OnClick()
    {
        primaryPanel.SetActive(!primaryPanel.activeSelf);
        foreach (GameObject gameObject in secondaryPanels)
        {
            gameObject.SetActive(false);
        }
    }
}
