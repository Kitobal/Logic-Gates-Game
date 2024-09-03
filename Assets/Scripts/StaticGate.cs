using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticGate : MonoBehaviour
{
    [SerializeField] string gateName = "Buffer";
    [SerializeField] GameObject inputObjectA;
    [SerializeField] GameObject inputObjectB;
    [SerializeField] Sprite bufferSprite;
    [SerializeField] Sprite notSprite;
    [SerializeField] Sprite andSprite;
    [SerializeField] Sprite nandSprite;
    SpriteRenderer mySpriteRenderer;
    Output myOutput;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myOutput = GetComponent<Output>();
        SetSprite();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeOutput();
    }

    void SetSprite(){
        if (gateName == "Buffer"){
            mySpriteRenderer.sprite = bufferSprite;
        } else if (gateName == "Not"){
            mySpriteRenderer.sprite = notSprite;
        } else if (gateName == "And"){
            mySpriteRenderer.sprite = andSprite;
        } else if (gateName == "Nand"){
            mySpriteRenderer.sprite = nandSprite;
        }
    }

    void ChangeOutput(){
        if (gateName == "Buffer"){
            //buffer rules
            myOutput.output = inputObjectA.GetComponent<Output>().output;
        } else if (gateName == "Not"){
            //not rules
            if(inputObjectA.GetComponent<Output>().output == null){
                myOutput.output = null;
            } else {
            myOutput.output = !inputObjectA.GetComponent<Output>().output;
            }
        } else if (gateName == "And"){
            //and rules
            if (inputObjectA.GetComponent<Output>().output == null || inputObjectB.GetComponent<Output>().output == null){ // if there is a game object but it´s output is null
                    myOutput.output = null;
                } else if (inputObjectA.GetComponent<Output>().output == true & inputObjectB.GetComponent<Output>().output == true){ // if both outputs are true
                    myOutput.output = true;
                } else {
                    myOutput.output = false;
                } 
        } else if (gateName == "Nand"){
                //Rules for Nand gate
                if (inputObjectA.GetComponent<Output>().output == null || inputObjectB.GetComponent<Output>().output == null){ // if there is a game object but it´s output is null
                    myOutput.output = null;
                } else if (inputObjectA.GetComponent<Output>().output == true & inputObjectB.GetComponent<Output>().output == true){ // if both outputs are true
                    myOutput.output = false;
                } else {
                    myOutput.output = true; //else (at least one input is false)
                }
            }
    }
}
