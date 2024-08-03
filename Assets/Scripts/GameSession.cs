using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public List<string> playerRecords = new List<string>();
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions  > 1){
            Destroy(gameObject);
            return;
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }    
    
    public void AddToPlayerRecords(string stringToAdd){
        playerRecords.Add(stringToAdd);
    }
}
