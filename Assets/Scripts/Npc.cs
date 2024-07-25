using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    [SerializeField] Sprite happySprite;
    [SerializeField] GameObject startingPanel;

     SpriteRenderer mySpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {   

        startingPanel.SetActive(true);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(){
        mySpriteRenderer.sprite = happySprite;
    }
}
