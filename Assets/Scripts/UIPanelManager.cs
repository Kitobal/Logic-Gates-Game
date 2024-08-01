using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;


public class UIPanelManager : MonoBehaviour
{
    
    [SerializeField] GameObject startingButton;
    [SerializeField] GameObject nextPanel;

    [SerializeField] AudioClip panelAudioClip;
    [SerializeField] GameObject dialoguePlayer;

    AudioSource dialogueAudioSource;

    Player playerObject;

    TextMeshProUGUI buttonText;
    string buttonTextXbox = "<sprite name=\"Xbox_A\">Continuar";
    string buttonTextKey = "<sprite name=\"Key_Space\">Continuar";
    
    void Start()
    {
        playerObject = FindObjectOfType<Player>();
        playerObject.PlayerNotUsingUI(false);
        EventSystem.current.SetSelectedGameObject(startingButton);
        buttonText = startingButton.GetComponentInChildren<TextMeshProUGUI>();
        dialogueAudioSource = dialoguePlayer.GetComponent<AudioSource>();
        if (panelAudioClip != null){
            dialogueAudioSource.clip = panelAudioClip;
            dialogueAudioSource.PlayDelayed(0.1f);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateButtonText();
    }

    public void DeactivatePanel(){
        
        StartCoroutine(DeactivatePanelWithDelay());
    }

    public void LoadNextPanel(){
        StartCoroutine(LoadNextPanelWithDelay());
    }

    void UpdateButtonText(){
        if (playerObject.GetComponent<PlayerInput>().currentControlScheme =="Gamepad"){
            buttonText.text = buttonTextXbox;
        } else{
            buttonText.text = buttonTextKey;
        }
    }

    private IEnumerator DeactivatePanelWithDelay()
    {   
        yield return new WaitForSeconds(0.2f);
        dialogueAudioSource.Stop();
        playerObject.PlayerNotUsingUI(true);
        gameObject.SetActive(false); // This game object
        
    }

    private IEnumerator LoadNextPanelWithDelay()
    {
        yield return new WaitForSeconds(0.2f);
        dialogueAudioSource.Stop();
        nextPanel.SetActive(true);
        gameObject.SetActive(false); //this game object
    }
}
