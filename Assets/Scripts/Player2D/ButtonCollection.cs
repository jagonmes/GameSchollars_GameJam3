using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//Autor: Jesús Bastante López
//Script que administra la colección de monedas
//y activa la an9imación final
public class ButtonCollection : MonoBehaviour
{
    public int numMonedas = 0;
    //Booleano que permite sumar monedas
    //(arregla error de colliders que hace que sume +1 dos veces)
    private bool canIncrement = true;
    //animator del player
    private Animator playerAnimator;
    //gameobject knife y su animador
    public GameObject knife;
    private Animator knifeAnimator;

    [SerializeField] private PlayerMovement controller;

    private void Start()
    {
        //consigue animator del player
        playerAnimator = GetComponent<Animator>();
        //consigue knife y su animator.
        knifeAnimator = knife.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin") && other.isTrigger)
        {
            Destroy(other.gameObject);
            if (canIncrement)
            {
                addCoin();
                //bloquea sumar de más monedas
                canIncrement = false;
                //resetea el booleano de poder incrementar al cabo de un segundo.
                Invoke("ResetCanIncrement", 1f);
            }
        }
    }
    //añade moneda, y si son 3 llama a la animacion final
    private void addCoin()
    {
        numMonedas++;
        playerAnimator.SetInteger("State", numMonedas);
        if (numMonedas == 3)
        {
            Debug.Log("Final");
            endAnimation();
        }
    }
    //resetea el booleano de incremento
    private void ResetCanIncrement()
    {
        canIncrement = true;
    }
    //activa animacionFinal
    public void endAnimation()
    {
        //impide movimiento de jugador
        controller.active = 0;
        knife.gameObject.SetActive(true);
        Debug.Log("1");
        Invoke("Kill", 1f);
        Invoke("Transform", 8f);

    }
    private void Kill()
    {
        knifeAnimator.SetBool("iskilling", true);
    }
    private void Transform()
    {
        knifeAnimator.SetBool("isTransforming", true);
    }
}
