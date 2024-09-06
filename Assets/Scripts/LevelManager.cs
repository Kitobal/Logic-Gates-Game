using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] AudioClip selectionRightSFX;
    [SerializeField] AudioClip selectionLeftSFX;
    [SerializeField] float sfxVolume = 1f;
    public int currentLevel;
    int maxGateIndex;
    List<string> allGates = new List<string> { "Buffer", "Not", "And","Nand", "Or", "Nor", "Xor", "Xnor" };
    public Image[] gateIcons;
    public Image[] selectedFrames;
    public int selectionIndex = 0;
    [SerializeField] TextMeshProUGUI screenPrompt;
    [SerializeField] TextMeshProUGUI levelTitle;
    string  noInteractKeyString= "Seleccionar<sprite name=\"Key_C\">o<sprite name=\"Key_V\">";
    string yesInteractKeyString = "Interactuar<sprite name=\"Key_Space\">\nSeleccionar<sprite name=\"Key_C\">o<sprite name=\"Key_V\">";
    string  noInteractXboxString= "Seleccionar<sprite name=\"Xbox_X\">o<sprite name=\"Xbox_Y\">";
    string yesInteractXboxString = "Interactuar<sprite name=\"Xbox_A\">\nSeleccionar<sprite name=\"Xbox_X\">o<sprite name=\"Xbox_Y\">";
    [SerializeField] TextMeshProUGUI stopwatchText;
    public int elapsedTime = 0;
    bool timeRunning = false;

    GameSession myGameSession;
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        maxGateIndex = currentLevel -1;
        levelTitle.text = "Nivel "+ currentLevel.ToString();
        UpdateUnlockedGates();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSelection();
    }

    public void MoveSelectionRight(){
        AudioSource.PlayClipAtPoint(selectionRightSFX, Camera.main.transform.position,sfxVolume);
        if (selectionIndex <= maxGateIndex){
            if (selectionIndex == maxGateIndex){
                selectionIndex = 0;
            } else {
                selectionIndex = selectionIndex + 1;
            }

        }
    }
    public void MoveSelectionLeft(){
        AudioSource.PlayClipAtPoint(selectionLeftSFX, Camera.main.transform.position,sfxVolume);
        if (selectionIndex <= maxGateIndex){
            if (selectionIndex == 0){
                selectionIndex = maxGateIndex;
            } else {
                selectionIndex = selectionIndex - 1;
            }

        }
    }

    public string GetSelectedGate(){
        string selectedString = allGates[selectionIndex];
        return selectedString;
    }

    void UpdateSelection(){
        for (int i = 0; i <= maxGateIndex; i++){
            if (i == selectionIndex){
                selectedFrames[i].enabled = true;
                selectedFrames[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            } else {
                selectedFrames[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
                selectedFrames[i].enabled = false;
            }
        }
    }
    void UpdateUnlockedGates(){
        for (int i = 0; i <= 7; i++){
            if (i <= maxGateIndex){
                gateIcons[i].enabled = true;
            } else {
                gateIcons[i].enabled = false;
                selectedFrames[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
                selectedFrames[i].enabled = false;
            }
        } 
    }
    public void UpdateScreenPrompt(bool interact, string device){
        if (device == "Gamepad"){
            if (interact){
                screenPrompt.text = yesInteractXboxString;
            } else {
                screenPrompt.text = noInteractXboxString;
            }
        } else {
            if (interact){
                screenPrompt.text = yesInteractKeyString;
            } else {
                screenPrompt.text = noInteractKeyString;
            }
        }
    }

    private IEnumerator UpdateStopwatch(){
        while(timeRunning){
            yield return new WaitForSeconds(1f);
            elapsedTime += 1;
            stopwatchText.text = elapsedTime.ToString();
        }
    }

    public void StartStopwatch(){
        if (!timeRunning){
            timeRunning = true;
            StartCoroutine(UpdateStopwatch());
        }
    }

    public void StopStopwatch(){
        if (timeRunning){
            timeRunning = false;
            StopCoroutine(UpdateStopwatch());
        }
    }

    public void AddRecord(){
        myGameSession = FindObjectOfType<GameSession>();
        string toBeAdded = "Nivel "+currentLevel.ToString()+":   "+(elapsedTime+1).ToString()+" segundos";
        myGameSession.AddToPlayerRecords(toBeAdded);
    }

}
