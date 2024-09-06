using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    [SerializeField] GameObject inputObject;
    SpriteRenderer myRenderer;
    void Start() {
        myRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (inputObject.GetComponent<Output>().output == true){
            myRenderer.color = Color.green;
        } else if (inputObject.GetComponent<Output>().output == false){
            myRenderer.color = Color.red;
        } else {
            myRenderer.color = Color.white;
        }
    }
}
