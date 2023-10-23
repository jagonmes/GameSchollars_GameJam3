using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public int active = 1;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update(){
        if (active != 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if (horizontalMove == 0f)
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
                animator.SetBool("IsJumping", true);
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate(){
        controller.Move(horizontalMove* Time.fixedDeltaTime*active, false,jump);
        jump = false;

    }


}
