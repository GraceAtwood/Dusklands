using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationAnims : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnClick()
    {
        anim.SetTrigger("trigger");
    }
}
