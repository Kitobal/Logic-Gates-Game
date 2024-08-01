using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Linq;
using System.Threading;

public class Npc : MonoBehaviour
{
    [SerializeField] Sprite happySprite;
    [SerializeField] GameObject startingPanel;
    [SerializeField] GameObject npcPanel;
    public GameObject[] gateSections;

    SpriteRenderer mySpriteRenderer;

    LevelManager myLevelManager;
    Player playerObject;

    public int currentLevel;
    
    // Start is called before the first frame update
    void Start()
    {   

        startingPanel.SetActive(true);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myLevelManager = FindObjectOfType<LevelManager>();
        playerObject = FindObjectOfType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(){
        mySpriteRenderer.sprite = happySprite;
    }

    public void LoadPanel(){
        StartCoroutine(ActivatePanelWithDelay());
               
    }

     private IEnumerator ActivatePanelWithDelay()
    {
        yield return new WaitForSeconds(0.2f);
        npcPanel.SetActive(true);
        currentLevel = myLevelManager.currentLevel;
        for (int i = 0; i <= gateSections.Length - 1; i++){
            if (i <= currentLevel -1){
                gateSections[i].SetActive(true);
            } else {
                gateSections[i].SetActive(false);
            }
        }

    }

    
}
