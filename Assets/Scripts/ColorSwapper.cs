using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapper : MonoBehaviour
{
    public ColorPicker picker;
    Color haircolor;
    public string bodypart;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<MeshRenderer>().sharedMaterial.SetColor(bodypart, picker.CurrentColor);
    }
}
