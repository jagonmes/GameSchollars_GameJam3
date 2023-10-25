using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Autor del codigo: Brackeys https://www.youtube.com/@Brackeys
//Editor : Jesús Bastante López
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public int lifes;
    public GameObject[] lifeSprites;
    public GameObject derrota;
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
        if(lifes <= 0)
        {
            active = 0;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            derrota.SetActive(true);
            Invoke("devolverControlAlJugador",1f);
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

    public void LessLifes()
    {
        lifes--;
        lifeSprites[lifes].SetActive(false);
    }

    void devolverControlAlJugador()
    {
        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = true;
    }
}
