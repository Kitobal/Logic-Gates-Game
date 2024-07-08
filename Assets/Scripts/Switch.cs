using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Sprite falseSprite;
    [SerializeField] Sprite trueSprite;
    Output myOutput;
    SpriteRenderer mySpriterenderer;


    void Start() {
        myOutput = GetComponent<Output>();
        mySpriterenderer = GetComponent<SpriteRenderer>();
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
        if (myOutput.output == true){
            myOutput.output = false;
        } else {
            myOutput.output = true;
        }
    }

    //private void OnCollisionEnter2D(Collision2D other) {
    //    if (other.gameObject.layer == 6){ // La capa 6 es la capa del Jugador
    //        ChangeOutput();
    //    }
    //}
}
