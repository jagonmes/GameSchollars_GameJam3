using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor del codigo: Brackeys https://www.youtube.com/@Brackeys
//Editor : Jesús Bastante López
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 60f;
    float horizontalMove = 0f;
    bool jump = false;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("State", 2);
    }
    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(horizontalMove == 0f)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate(){
        //Mover personaje
        controller.Move(horizontalMove* Time.fixedDeltaTime, false,jump);
        jump = false;

    }


}
