using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            StartCoroutine(WaitAndLoadNextScene());
        }
    }

    public void LoadNextScene(){ //to be used later on main menu
        StartCoroutine(WaitAndLoadNextScene());
    }

    private IEnumerator WaitAndLoadNextScene(){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nextScene);
    }

    public void LoadMainMenu(){
        GameSession myGameSession = FindObjectOfType<GameSession>();
        Destroy(myGameSession.GameObject());
        SceneManager.LoadScene(0);
    }
}
