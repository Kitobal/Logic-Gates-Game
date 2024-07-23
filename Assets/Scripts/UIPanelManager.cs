using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIPanelManager : MonoBehaviour
{
    
    [SerializeField] GameObject startingButton;

    Player playerObject;
    
    void Start()
    {
        playerObject = FindObjectOfType<Player>();
        EventSystem.current.SetSelectedGameObject(startingButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivatePanel(){
        playerObject.PlayerNotUsingUI(true);
        gameObject.SetActive(false); //this game object
    }
}
