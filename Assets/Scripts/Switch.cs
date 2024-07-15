using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Sprite falseSprite;
    [SerializeField] Sprite trueSprite;
    [SerializeField] AudioClip switchSFX;
    [SerializeField] float sfxVolume = 1;
    Output myOutput;
    SpriteRenderer mySpriterenderer;


    void Start() {
        myOutput = GetComponent<Output>();
        mySpriterenderer = GetComponent<SpriteRenderer>();
        myOutput.output = false;
    }
    void Update()
    {
        UpdateSprite();
    }

    void UpdateSprite(){
        if (myOutput.output == true){
            mySpriterenderer.sprite = trueSprite;
        } else {
            mySpriterenderer.sprite = falseSprite;
        }
    }
    public void ChangeOutput(){
        AudioSource.PlayClipAtPoint(switchSFX, Camera.main.transform.position,sfxVolume);
        if (myOutput.output == true){
            myOutput.output = false;
        } else {
            myOutput.output = true;
        }
    }


}
