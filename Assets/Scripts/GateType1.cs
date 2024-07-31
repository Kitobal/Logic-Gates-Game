using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GateType1 : MonoBehaviour
{
    [SerializeField] GameObject inputObject;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite bufferSprite;
    [SerializeField] Sprite notSprite;
    [SerializeField] AudioClip gateSet;
    [SerializeField] AudioClip gateRemove;
    [SerializeField] AudioClip wrongGateSFX;
    [SerializeField] float sfxVolume = 1f;
    
    public string activeGate = "Empty";
    SpriteRenderer mySpriteRenderer;
    Output myOutput;

    private void Start() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myOutput = GetComponent<Output>();
    }

    void Update()
    {
        ChangeOutput();
    }

    public void SetActiveGate(string name){
        if (name == "Buffer" ||name == "Not" ){
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
            if (activeGate == "Buffer"){
                mySpriteRenderer.sprite = bufferSprite;
                //Rules for Buffer gate
                myOutput.output = inputObject.GetComponent<Output>().output; 
            } else if (activeGate == "Not"){
                mySpriteRenderer.sprite = notSprite;
                //Rules for Not gate
                if (inputObject.GetComponent<Output>().output == null){
                    myOutput.output = null;
                } else {
                    myOutput.output = !inputObject.GetComponent<Output>().output;
                }
                
            }
        }
    }

}
