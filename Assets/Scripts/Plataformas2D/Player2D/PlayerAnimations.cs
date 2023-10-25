using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    //animator del player
    public Animator playerAnimator;
    //gameobject knife y su animador
    public GameObject knife;
    private Animator knifeAnimator;
    private int actualButtons = 0;

    //gameObject texto "Felicidades"
    //lo lleva el jugador para que el orden de
    //botones de igual
    public GameObject feliz;

    //obtiene el codigo PlayerMovement
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private LifesAdministrator lifesScript;
    void Start()
    {
        knifeAnimator = knife.GetComponent<Animator>();
    }
    //script que controla el estado de animacion
    // y aplica la animacion necesaria
    public void controlAnimations(int animationState)
    {
        switch (animationState)
        {
            //isMoving == true animaciones de movimiento
            //isMoving == false animacion de idle
            //isJumping == true animacion de salto
            //isJumping == otras animaciones


            //boolean de movimiento del animator a false
            case 0:
                playerAnimator.SetBool("IsMoving", false);
                break;

            //boolean de movimiento del animator a true
            case 1:
                playerAnimator.SetBool("IsMoving", true);
                break;

            //boolean de salto del animator a true
            case 2:
                playerAnimator.SetBool("IsJumping", true);
                break;

            //el jugador está saltando:
            //boolean de salto del animator a true
            case 3:
                playerAnimator.SetBool("IsJumping", false);
                break;

            //el jugador tiene 1 button:
            //suma uno a actualButtons 
            //y aplica la animacion "idle2"
            case 4:
                actualButtons = 1;
                playerAnimator.SetInteger("State", actualButtons);
                break;

            //el jugador tiene 2 button:
            //suma uno a actualButtons 
            //y aplica la animacion "idle3"
            case 5:
                actualButtons = 2;
                playerAnimator.SetInteger("State", actualButtons);
                break;

            //el jugador tiene los 3 button:
            //suma uno a actualButtons 
            //y aplica la animacion "death"
            case 6:
                actualButtons = 3;
                endAnimation();
                break;

        }
    }
    //script que controla la aniamcion final
    public void endAnimation()
    {
        //impide movimiento de jugador
        playerMovement.active = 0;
        //activa cuchillo y regula tiempos de animacion
        knife.gameObject.SetActive(true);
        Invoke("Kill", 2f);
        Invoke("Death", 3f);
        Invoke("Transform", 8f);

    }
    //activa la animacion "killing"
    private void Kill()
    {
        knifeAnimator.SetBool("iskilling", true);
    }
    //activa la animacion Knife "transforming"
    // y el mensaje "felicidades"
    private void Transform()
    {
        knifeAnimator.SetBool("isTransforming", true);
        feliz.gameObject.SetActive(true);
        Invoke("devolverControlAlJugador", 7f);
    }
    //activa la aniamcion de player "death"
    private void Death()
    {
        Debug.Log("Death");
        lifesScript.dissolveLifes();
        playerAnimator.SetInteger("State", actualButtons + 1);
    }
}
