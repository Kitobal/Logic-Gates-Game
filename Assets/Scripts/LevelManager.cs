using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] AudioClip selectionRightSFX;
    [SerializeField] AudioClip selectionLeftSFX;
    [SerializeField] float sfxVolume = 1f;
    int currentLevel;
    int maxGateIndex = 7;
    List<string> allGates = new List<string> { "Buffer", "Not", "And","Nand", "Or", "Nor", "Xor", "Xnor" };
    public Image[] gateIcons;
    public Image[] selectedFrames;
    public int selectionIndex = 0;
    void Awake()
    {
        int numLevelManagers = FindObjectsOfType<LevelManager>().Length;
        if (numLevelManagers  > 1){
            Destroy(gameObject);
            return;
        } else {
            DontDestroyOnLoad(gameObject);
        }
        //add here destory game object if on game over screen
    }   
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
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
            } else {
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
                selectedFrames[i].enabled = false;
            }
        }
    }
}
