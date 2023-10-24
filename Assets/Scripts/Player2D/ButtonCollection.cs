using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//Autor: Jesús Bastante López
//Script que administra la colección de monedas
//y activa la animación final
public class ButtonCollection : MonoBehaviour
{
    public int numMonedas = 0;
    //array de monedas en la escena, 
    //soluciona errores con sumar numMonedas con OnTriggerEnter2D
    private GameObject[] monedas;
    //Booleano que permite sumar monedas
    //(arregla error de colliders que hace que sume +1 dos veces)
    private bool canIncrement = true;
    //animator del player
    private Animator playerAnimator;
    //gameobject knife y su animador
    public GameObject knife;
    private Animator knifeAnimator;

    //obtiene el codigo PlayerMovement
    [SerializeField] private PlayerMovement controller;
    //obtiene el codigo PltColorAdmin para cambiar colores del mapa
    [SerializeField] private GroundColorAdmin colorAdm;

    private void Start()
    {
        //consigue animator del player
        playerAnimator = GetComponent<Animator>();
        //consigue knife y su animator.
        knifeAnimator = knife.GetComponent<Animator>();
    }

    private void Update()
    {
        monedas = GameObject.FindGameObjectsWithTag("Coin");
        numMonedas = 3 - monedas.Length;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            // Evita colisiones duplicadas.
            if (!canIncrement)
            {
                return; 
            }
            Invoke("AddCoin",0.5f);
            Destroy(other.gameObject);
        }
    }
    //añade moneda, y si son 3 llama a la animacion final
    public void AddCoin()
    {
        Debug.Log("coins" + numMonedas);
        //actualiza el animator
        playerAnimator.SetInteger("State", numMonedas);
        Debug.Log("coins" + numMonedas);
        //actualiza la situacion de la escena(colores)
        if (numMonedas == 1)
        {
            Debug.Log("1");
            colorAdm.orangeColor();
        }
        else if (numMonedas == 2)
        {
            Debug.Log("2");
            colorAdm.redColor();
        }
        else if(numMonedas == 3)
        {
            Debug.Log("Final");
            endAnimation();
        }
        else 
        {
            Debug.Log("Error en numero de monedas");
        }
    }

    //activa animacionFinal
    public void endAnimation()
    {
        //impide movimiento de jugador
        controller.active = 0;
        //activa cuchillo y regula tiempos de animacion
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
