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
        } else {
            //add wrong gate sfx here
        }
    }

    public void RemoveActiveGate(){
        activeGate = "Empty";
        mySpriteRenderer.sprite = defaultSprite;
        myOutput.output = false;
    }

    void ChangeOutput(){
        if (activeGate != "Empty"){
            if (activeGate == "Buffer"){
                mySpriteRenderer.sprite = bufferSprite;
                //Rules for Buffer gate
                myOutput.output = inputObject.GetComponent<Output>().output; 
            }
        }
    }

}
