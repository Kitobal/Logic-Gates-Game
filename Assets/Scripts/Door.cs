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

    Player playerObject;
    Npc npcObject;
    LevelManager myLevelManager;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
        playerObject = FindObjectOfType<Player>();
        npcObject = FindObjectOfType<Npc>();
        myLevelManager = FindObjectOfType<LevelManager>();
        CheckOutput();
    }

    void Update(){
  
    }

    public void CheckOutput(){
        StartCoroutine(UpdateOutput());  
    }

    IEnumerator UpdateOutput(){
        yield return new WaitForSeconds(0.2f);
        if (input != null){
            finalOutput = input.GetComponent<Output>().output;
            if (finalOutput != null){
                if (finalOutput == true){
                myLevelManager.StopStopwatch(); //stop the clock
                myAnimator.SetBool("isOpen",true);
                myCollider.enabled = false;
                doorLight.GetComponent<SpriteRenderer>().sprite = lightOn;
                playerObject.SetCanInteract(false);
                AudioSource.PlayClipAtPoint(doorSFX, Camera.main.transform.position,sfxVolume);
                npcObject.Cheer();   
                myLevelManager.AddRecord();
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
