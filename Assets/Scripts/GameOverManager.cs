using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;
using System.Threading;
public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject mainButton;
    [SerializeField] TextMeshProUGUI buttonText;

    public TextMeshProUGUI[] recordFields;

    GameSession myGameSession;
    PlayerInput myPlayerInput;

    List<string> playerRecords;
    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myPlayerInput = GetComponent<PlayerInput>();
        playerRecords = myGameSession.playerRecords;
        StartCoroutine(WaitAndSelectButton());
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerRecords();
        UpdateButtonText();
    }

    void UpdateButtonText(){
        if(EventSystem.current.currentSelectedGameObject == mainButton){
            if (myPlayerInput.currentControlScheme =="Gamepad"){
            buttonText.text = "<sprite name=\"Xbox_A\">"+"Menu Principal";
        } else{
            buttonText.text = "<sprite name=\"Key_Space\">"+"Menu Principal";
        }
        }
    }

    private IEnumerator WaitAndSelectButton(){
        yield return new WaitForSeconds(2f);
        EventSystem.current.SetSelectedGameObject(mainButton); 
    }

    void UpdatePlayerRecords(){
         for (int i = 0; i <= playerRecords.Count -1; i++){
            recordFields[i].text = playerRecords[i];
        }
    }
}
