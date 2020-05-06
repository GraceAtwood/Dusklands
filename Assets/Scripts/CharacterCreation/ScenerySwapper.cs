using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySwapper : MonoBehaviour
{
    int noClick = 0;
    public GameObject[] objList;

    void onStart()
    {
        noClick = 1;
    }

    public void btnClick()
    {
        objList[noClick].SetActive(false);

        noClick++;

        if ((noClick) >= objList.Length)
        {
            noClick = 0;
        }
        objList[noClick].SetActive(true);
    }
}
