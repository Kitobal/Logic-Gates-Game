using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;


    Animator playerAnimator;
    Vector2 moveInput;
    Rigidbody2D playerRigidbody;

    PlayerInput myPlayerInput;
    bool isMoving;
    GameObject collidingObject = null;
    Door doorObject;

    public String selectedGate;
    LevelManager myLevelManager;

    public bool canMove = true;
    public bool canInteract = true;
    
    public bool canSelect = true;
    Npc myNpc;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        myPlayerInput = GetComponent<PlayerInput>();
        myLevelManager = FindObjectOfType<LevelManager>();
        myNpc = FindObjectOfType<Npc>();
        doorObject = FindObjectOfType<Door>();
        UpdatePrompts();
    }

    void Update()
    {
        Walk();
        Animate();
        
    }

    void OnMove(InputValue value){
        if (canMove == true){
            moveInput = value.Get<Vector2>();
            UpdatePrompts();
        }
        
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
        if (other.gameObject.layer != 11 & canInteract){
            collidingObject = other.gameObject;
            UpdatePrompts();
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        collidingObject = null;
        UpdatePrompts();
    }

    void OnInteract(){
        if (collidingObject != null & canInteract){
            selectedGate = myLevelManager.GetSelectedGate();
            if (collidingObject.layer == 8){ //Layer of Switch
                playerAnimator.SetTrigger("Interact");
                collidingObject.GetComponent<Switch>().ChangeOutput();
            } else if (collidingObject.layer == 7){ //Layer of Gate Type 1 (1 input)
                playerAnimator.SetTrigger("Interact");
                if (collidingObject.GetComponent<GateType1>().activeGate == "Empty"){
                    collidingObject.GetComponent<GateType1>().SetActiveGate(selectedGate);
                } else {
                    collidingObject.GetComponent<GateType1>().RemoveActiveGate();
                }
                
            } else if (collidingObject.layer == 12){ //layer of Gate Type 2 (2 inputs)
                playerAnimator.SetTrigger("Interact");
                if (collidingObject.GetComponent<GateType2>().activeGate == "Empty"){
                    collidingObject.GetComponent<GateType2>().SetActiveGate(selectedGate);
                } else{
                    collidingObject.GetComponent<GateType2>().RemoveActiveGate();
                }
            } else if (collidingObject.layer == 10){ //layer of npc
                myNpc.LoadPanel();
            }
            doorObject.CheckOutput();
        } 
            
        
    }

    void OnChangeSelectionRight(){
        if (canSelect){
            myLevelManager.MoveSelectionRight();
            UpdatePrompts();
        }
        
    }

    void OnChangeSelectionLeft(){
        if(canSelect){
            myLevelManager.MoveSelectionLeft();
            UpdatePrompts();
        }
        
    }

    
    void UpdatePrompts(){
        if (collidingObject != null){
            myLevelManager.UpdateScreenPrompt(true,myPlayerInput.currentControlScheme);
        } else {
            myLevelManager.UpdateScreenPrompt(false,myPlayerInput.currentControlScheme);
        }
    }

    public void PlayerNotUsingUI(bool value){
        canInteract = value;
        canMove = value;
        canSelect = value;
    }

    public void SetCanInteract(bool value){
        canInteract = value;
    }
}
