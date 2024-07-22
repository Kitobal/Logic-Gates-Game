using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;

    [SerializeField] AudioClip gateSet;
    [SerializeField] AudioClip gateRemove;
    [SerializeField] AudioClip wrongSound; //to be used later
    [SerializeField] float sfxVolume = 1;
    Animator playerAnimator;
    Vector2 moveInput;
    Rigidbody2D playerRigidbody;

    PlayerInput myPlayerInput;
    bool isMoving;
    GameObject collidingObject = null;
    Door doorObject;

    public String selectedGate = "Buffer";
    LevelManager myLevelManager;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        myPlayerInput = GetComponent<PlayerInput>();
        myLevelManager = FindObjectOfType<LevelManager>();
        doorObject = FindObjectOfType<Door>();
        UpdatePrompts();
    }

    void Update()
    {
        Walk();
        Animate();
        
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
        UpdatePrompts();
    }

    void Walk(){
        
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        playerRigidbody.velocity = playerVelocity;

    }

    void Animate(){
        if (Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon|| Mathf.Abs(playerRigidbody.velocity.y) > Mathf.Epsilon){
            isMoving = true;
        } else{
            isMoving = false;
        }
        playerAnimator.SetBool("IsMoving",isMoving);
        if (isMoving){
            playerAnimator.SetFloat("X",moveInput.x);
            playerAnimator.SetFloat("Y",moveInput.y);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.layer != 11){
            collidingObject = other.gameObject;
            UpdatePrompts();
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        collidingObject = null;
        UpdatePrompts();
    }

    void OnInteract(){
        if (collidingObject != null){
            if (collidingObject.layer == 8){ //Layer of Switch
                playerAnimator.SetTrigger("Interact");
                collidingObject.GetComponent<Switch>().ChangeOutput();
            } else if (collidingObject.layer == 7){ //Layer of Gate Type 1 (1 input)
                playerAnimator.SetTrigger("Interact");
                if (collidingObject.GetComponent<GateType1>().activeGate == "Empty"){
                    collidingObject.GetComponent<GateType1>().SetActiveGate(selectedGate);
                    AudioSource.PlayClipAtPoint(gateSet, Camera.main.transform.position,sfxVolume);
                } else {
                    collidingObject.GetComponent<GateType1>().RemoveActiveGate();
                    AudioSource.PlayClipAtPoint(gateRemove, Camera.main.transform.position,sfxVolume); 
                }
                
            }
            doorObject.CheckOutput();
        } 
            
        
    }

    void OnChangeSelectionRight(){
        myLevelManager.MoveSelectionRight();
        UpdatePrompts();
    }

    void OnChangeSelectionLeft(){
        myLevelManager.MoveSelectionLeft();
        UpdatePrompts();
    }

    
    void UpdatePrompts(){
        if (collidingObject != null){
            myLevelManager.UpdateScreenPrompt(true,myPlayerInput.currentControlScheme);
        } else {
            myLevelManager.UpdateScreenPrompt(false,myPlayerInput.currentControlScheme);
        }
    }
}
