using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float scrollSpeed = 0.1f;
    public Material skybox;

    void FixedUpdate()
    {
        float offset = Time.deltaTime * scrollSpeed;

        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(scrollSpeed, 0));
    }
}
