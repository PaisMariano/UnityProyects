using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;
    private CharacterAnimations playerAnimations;

    public float movementSpeed          = 3f;
    public float gravity                = 9.8f;
    public float rotationSpeed          = 0.15f;
    public float rotateDegreesPerSecond = 180f;
    
    // primera funcion que se llama
    void Awake(){
        charController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    }

    void Move() {
        
        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0) {
            Vector3 moveDirection = transform.forward; // mueve hacia adelante el player
            moveDirection.y -= gravity * Time.deltaTime; // se mueve un frame
            charController.Move(moveDirection * movementSpeed * Time.deltaTime);

        }
        else if(Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {
            Vector3 moveDirection = -transform.forward; // mueve hacia atras el player
            moveDirection.y -= gravity * Time.deltaTime; // se mueve un frame
            charController.Move(moveDirection * movementSpeed * Time.deltaTime);
        }
        else
        {   
            //if we dont have any input to move character it stops 
            charController.Move(Vector3.zero);
        }
  
    }

    void Rotate()
    {
        Vector3 rotationDirection = Vector3.zero;

        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            rotationDirection = transform.TransformDirection(Vector3.left);
        }
        // No es anidado por que si aprieto para el otro lado cancela el movimiento.
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            rotationDirection = transform.TransformDirection(Vector3.right);
        }

        if(rotationDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotationDirection),
                rotateDegreesPerSecond * Time.deltaTime);
        }

    }
    void AnimateWalk()
    {
        if(charController.velocity.sqrMagnitude != 0f)
        {
            playerAnimations.Walk(true);
        }
        else
        {
            playerAnimations.Walk(false);
        }
    }


}




























