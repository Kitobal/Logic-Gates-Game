using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIPanelManager : MonoBehaviour
{
    
    [SerializeField] GameObject startingButton;
    [SerializeField] GameObject nextPanel;

    [SerializeField] AudioClip panelAudioClip;
    [SerializeField] GameObject dialoguePlayer;

    AudioSource dialogueAudioSource;

    Player playerObject;
    
    void Start()
    {
        playerObject = FindObjectOfType<Player>();
        EventSystem.current.SetSelectedGameObject(startingButton);
        dialogueAudioSource = dialoguePlayer.GetComponent<AudioSource>();
        dialogueAudioSource.clip = panelAudioClip;
        dialogueAudioSource.PlayDelayed(0.1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivatePanel(){
        dialogueAudioSource.Stop();
        playerObject.PlayerNotUsingUI(true);
        gameObject.SetActive(false); //this game object
    }

    public void LoadNextPanel(){
        dialogueAudioSource.Stop();
        nextPanel.SetActive(true);
        gameObject.SetActive(false); //this game object
    }
}
