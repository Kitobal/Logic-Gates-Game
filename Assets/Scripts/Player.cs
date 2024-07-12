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
    bool isMoving;
    GameObject collidingObject;
    //Door doorObject;

    public String selectedGate = "Buffer";
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        //doorObject = FindObjectOfType<Door>();
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
        } 
            
        
    }
}
