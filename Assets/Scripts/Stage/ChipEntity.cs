using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChipEntity : MonoBehaviour
{

    string chipTag = "";
    public string ChipTag { 
        get { return chipTag; } 
        set { chipTag = value; }
    }

    public virtual void Initialize(Sprite sprite)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        renderer.sprite = sprite;
    }


}
