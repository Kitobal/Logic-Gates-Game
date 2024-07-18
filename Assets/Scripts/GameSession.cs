using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    // to save the completed levels and recrods
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
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
