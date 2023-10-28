using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Autor del codigo original: Brackeys https://www.youtube.com/@Brackeys
//Editor : Jesús Bastante López
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public PlayerAnimations animationsScript;

    [SerializeField] private AudioController soundController;

    public float runSpeed = 60f;
    float horizontalMove = 0f;
    bool jump = false;

    //private Animator animator;
    public int active = 0;

    //boolean para regular la activacion de
    // la animacion de salto
    private bool jumpingTimer;
    private void Start()
    {
        //animator = GetComponent<Animator>();
    }
    void Update(){
        //si el jugador está activo:
        //cambia animaciones y consigue el movimiento
        if (active != 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            // si el jugador no está saltando, activa las otras animaciones
            if (!jump)
            {
                //si el jugador está quieto, animacion de idle
                if (horizontalMove == 0f)
                {
                    animationsScript.controlAnimations(0);
                }
                //si el jugador se mueve, animacion de movimiento
                else
                {
                    animationsScript.controlAnimations(1);
                }
            }
            
            //si el jugador salta activa el proceso de salto
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                jumpingTimer = false;
                Invoke("ResetJumping", 0.5f);
                animationsScript.controlAnimations(2);
            }
        }
        //si el jugador está inactivo:
        //cambia animacion de idle
        else
        {
            animationsScript.controlAnimations(0);
        }
    }

    //al caer desactiva animacion de salto
    //y cambia la variable de salto a false
    public void OnLanding()
    {
        jump = false;
        if (jumpingTimer)
        {
            animationsScript.controlAnimations(3);
            jumpingTimer = false;
        }
    }
    
    //aplica el movimiento al jugador
    void FixedUpdate(){
        controller.Move(horizontalMove* Time.fixedDeltaTime*active, false,jump);
    }

    //pone el bool de salto a true
    void ResetJumping()
    {
        jumpingTimer = true;
    }
}
