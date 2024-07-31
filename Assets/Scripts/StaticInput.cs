using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInput : MonoBehaviour
{
    [SerializeField] bool isTrue = false;
    [SerializeField] Sprite trueSprite;
    [SerializeField] Sprite falseSprite;
    SpriteRenderer mySpriteRenderer;
    Output myOutput;
    void Start()
    {
        SetOutput();
    }

    void SetOutput(){
        myOutput = GetComponent<Output>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        if (isTrue){
            mySpriteRenderer.sprite = trueSprite;
            myOutput.output = true;
        } else{
            mySpriteRenderer.sprite = falseSprite;
            myOutput.output = false;
        }
    }
}
