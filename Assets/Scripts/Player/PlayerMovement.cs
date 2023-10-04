using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor del codigo: Brackeys https://www.youtube.com/@Brackeys
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 60f;
    float horizontalMove = 0f;
    bool jump = false;


    // Update is called once per frame
    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate(){
        //Move character
        controller.Move(horizontalMove* Time.fixedDeltaTime, false,jump);
        jump = false;

    }


}
