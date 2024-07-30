using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateType2 : MonoBehaviour
{
    [SerializeField] GameObject inputObjectA;
    [SerializeField] GameObject inputObjectB;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite andSprite;
    [SerializeField] AudioClip gateSet;
    [SerializeField] AudioClip gateRemove;
    [SerializeField] AudioClip wrongGateSFX;
    [SerializeField] float sfxVolume = 1f;
    
    public string activeGate = "Empty";
    SpriteRenderer mySpriteRenderer;
    Output myOutput;
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myOutput = GetComponent<Output>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeOutput();
    }

    public void SetActiveGate(string name){
        if (name == "And"){  //other gates to be added here
            activeGate = name;
            AudioSource.PlayClipAtPoint(gateSet, Camera.main.transform.position,sfxVolume);
        } else {
            AudioSource.PlayClipAtPoint(wrongGateSFX, Camera.main.transform.position,sfxVolume);
        }
    }
     public void RemoveActiveGate(){
        activeGate = "Empty";
        AudioSource.PlayClipAtPoint(gateRemove, Camera.main.transform.position,sfxVolume);
        mySpriteRenderer.sprite = defaultSprite;
        myOutput.output = null;
    }
    void ChangeOutput(){
        if (activeGate != "Empty"){
            if (activeGate == "And"){
                mySpriteRenderer.sprite = andSprite;
                //Rules for And gate

                if (inputObjectA.GetComponent<Output>().output == null || inputObjectB.GetComponent<Output>().output == null){ // if there is a game object but it´s output is null
                    myOutput.output = null;
                } else if (inputObjectA.GetComponent<Output>().output == true & inputObjectB.GetComponent<Output>().output == true){ // if both outputs are true
                    myOutput.output = true;
                } else {
                    myOutput.output = false;
                } 
            } 
        }
    }
}
