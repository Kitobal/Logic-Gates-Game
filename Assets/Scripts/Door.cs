using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject input;
    [SerializeField] GameObject doorLight;
    [SerializeField] Sprite lightOn;
    [SerializeField] Sprite lightOff;
    [SerializeField] AudioClip doorSFX;
    [SerializeField] float sfxVolume = 1;
    public bool finalOutput;
    Animator myAnimator;
    Collider2D myCollider;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    void Update(){
        CheckOutput();
    }

    public void CheckOutput(){
        if (input != null){
            finalOutput = input.GetComponent<Output>().output;
            myAnimator.SetBool("isOpen",finalOutput);
            if (finalOutput == true){
                myCollider.enabled = false;
                doorLight.GetComponent<SpriteRenderer>().sprite = lightOn;   
            } else {
                myCollider.enabled = true;
                doorLight.GetComponent<SpriteRenderer>().sprite = lightOff;
            }
        }
    }

    //public void IfOpenPlaySFX(){
    //    if(finalOutput == true){
    //        AudioSource.PlayClipAtPoint(doorSFX, Camera.main.transform.position,sfxVolume);
    //    }
    //}

}
