using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject controlsButton;
    [SerializeField] GameObject panelControls;
    [SerializeField] GameObject panelButton;

    [SerializeField] TextMeshProUGUI button1Text;
    [SerializeField] TextMeshProUGUI button2Text;
    [SerializeField] TextMeshProUGUI button3Text;

    PlayerInput myPlayerInput;

    string startButtonText = "Iniciar";
    string controlButtonText = "Controles";
    string xboxIconText = "<sprite name=\"Xbox_A\">";
    string KeyboardIconText = "<sprite name=\"Key_Space\">";

    bool isPanelActive = false;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(startButton);
        myPlayerInput =  GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(EventSystem.current.currentSelectedGameObject == null){
            EventSystem.current.SetSelectedGameObject(startButton);
        }
        UpdateButtonText();
    }

    void UpdateButtonText(){
        if (!isPanelActive){
            if (myPlayerInput.currentControlScheme == "Gamepad"){
                if (EventSystem.current.currentSelectedGameObject == startButton){
                    button1Text.text = xboxIconText+startButtonText;
                    button2Text.text = controlButtonText;
                } else if (EventSystem.current.currentSelectedGameObject == controlsButton){
                    button1Text.text = startButtonText;
                    button2Text.text = xboxIconText+controlButtonText;
                }
            } else {
                if (EventSystem.current.currentSelectedGameObject == startButton){
                    button1Text.text = KeyboardIconText+startButtonText;
                    button2Text.text = controlButtonText;
                } else if (EventSystem.current.currentSelectedGameObject == controlsButton){
                    button1Text.text = startButtonText;
                    button2Text.text = KeyboardIconText+controlButtonText;
                }

            }
        } else {
            if (myPlayerInput.currentControlScheme == "Gamepad"){
                button3Text.text = xboxIconText+"Continuar";
            } else {
                button3Text.text = KeyboardIconText+"Continuar";
            }
        }
        
    }
    public void OpenControlsPanel(){
        isPanelActive =  true;
        panelControls.SetActive(true);
        EventSystem.current.SetSelectedGameObject(panelButton);
    }
    public void CloseControlsPanel(){
        isPanelActive = false;
        panelControls.SetActive(false);
        EventSystem.current.SetSelectedGameObject(startButton);
    }
}
