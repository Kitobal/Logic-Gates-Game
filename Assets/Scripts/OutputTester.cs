using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputTester : MonoBehaviour
{
    // para testear el output de los componentes
    [SerializeField] GameObject inputObject;
    [SerializeField] Sprite nullSprite;
    [SerializeField] Sprite trueSprite;
    [SerializeField] Sprite falseSprite;
    
    SpriteRenderer mySpriteRenderer;
    
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputObject.GetComponent<Output>().output == null){
            mySpriteRenderer.sprite = nullSprite;
        } else if (inputObject.GetComponent<Output>().output == true){
            mySpriteRenderer.sprite = trueSprite;
        } else {
            mySpriteRenderer.sprite = falseSprite;
        }
    }
}
