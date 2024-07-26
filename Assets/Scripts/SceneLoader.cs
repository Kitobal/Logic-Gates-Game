using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentScene;
    int nextScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currentScene + 1;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 6 ){
            SceneManager.LoadScene(nextScene);
        }
    }

    public void LoadNextScene(){ //to be used later on main menu
        SceneManager.LoadScene(nextScene);
    }
}
