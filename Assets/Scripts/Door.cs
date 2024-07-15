using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject input;
    [SerializeField] GameObject doorLight;
    [SerializeField] Sprite lightOn;
    [SerializeField] Sprite lightOff;
    [SerializeField] Sprite lightNull;
    [SerializeField] AudioClip doorSFX;
    [SerializeField] float sfxVolume = 1;
    public bool? finalOutput;
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
            if (finalOutput != null){
                if (finalOutput == true){
                myAnimator.SetBool("isOpen",true);
                myCollider.enabled = false;
                doorLight.GetComponent<SpriteRenderer>().sprite = lightOn;
                //AudioSource.PlayClipAtPoint(doorSFX, Camera.main.transform.position,sfxVolume);   
                } else {
                myAnimator.SetBool("isOpen",false);
                myCollider.enabled = true;
                doorLight.GetComponent<SpriteRenderer>().sprite = lightOff;
                }
            } else{
                doorLight.GetComponent<SpriteRenderer>().sprite = lightNull;   
            }
        }
            
    }


}
