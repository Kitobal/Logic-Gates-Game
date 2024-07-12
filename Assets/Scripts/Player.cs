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
    bool isMoving;
    GameObject collidingObject;

    public String selectedGate = "Buffer";
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
        Animate();
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
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
        collidingObject = other.gameObject;
    }

    private void OnCollisionExit2D(Collision2D other) {
        collidingObject = null;
    }

    void OnInteract(){
        if (collidingObject != null){
            if (collidingObject.layer == 8){ //Layer of Switch
                playerAnimator.SetTrigger("Interact");
                collidingObject.GetComponent<Switch>().ChangeOutput();
            }
            if (collidingObject.layer == 7){ //Layer of Gate Type 1 (1 input)
                playerAnimator.SetTrigger("Interact");
                if (collidingObject.GetComponent<GateType1>().activeGate == "Empty"){
                    collidingObject.GetComponent<GateType1>().SetActiveGate(selectedGate);
                } else {
                    collidingObject.GetComponent<GateType1>().RemoveActiveGate();
                }
                
            }
        }
    }
}
