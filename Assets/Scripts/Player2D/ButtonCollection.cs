using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//Autor: Jesús Bastante López
//Script que administra la colección de monedas
//y activa la animación final
public class ButtonCollection : MonoBehaviour
{
    private int numMonedas;
    private int monedasTotales = 3;
    
    //array de monedas en la escena, 
    //soluciona errores con sumar numMonedas con OnTriggerEnter2D
    private GameObject[] monedas;
    //array de sprites de vida, cambia los sprites dependiendo del estado
    public GameObject[] lifeSprites;
    //animator del player
    private Animator playerAnimator;
    //gameobject knife y su animador
    public GameObject knife;
    private Animator knifeAnimator;
    //gameObject texto "Felicidades"
    public GameObject feliz;

    //obtiene el codigo PlayerMovement
    [SerializeField] private PlayerMovement controller;
    //obtiene el codigo PltColorAdmin para cambiar colores del mapa
    [SerializeField] private GroundColorAdmin colorAdm;

    private void Start()
    {
        //consigue animator del player
        playerAnimator = GetComponent<Animator>();
        //consigue el animator de knife
        knifeAnimator = knife.GetComponent<Animator>();
        //consigue el animator de felicidades
    }

    private void Update()
    {
        //actualiza el numero de monedas
        //hecho asi por el bug de collider2D
        monedas = GameObject.FindGameObjectsWithTag("Coin");
        numMonedas = monedasTotales - monedas.Length;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Invoke("AddCoin",0.5f);
            Destroy(other.gameObject);
        }
    }
    //añade moneda, y si son 3 llama a la animacion final
    public void AddCoin()
    {
        Debug.Log("coins" + numMonedas);
        //actualiza el animator del player
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
        Invoke("Kill", 2f);
        Invoke("Death", 2.5f);
        Invoke("Transform", 8f);

    }

    //activa la animacion Knife killing
    private void Kill()
    {
        knifeAnimator.SetBool("iskilling", true);
    }
    //activa la animacion Knife transforming
    // y el mensaje felicidades
    private void Transform()
    {
        knifeAnimator.SetBool("isTransforming", true);
        feliz.gameObject.SetActive(true);
        Invoke("devolverControlAlJugador", 7f);
    }
    //actuva la aniamcion de player death
    private void Death()
    {
        playerAnimator.SetInteger("State", numMonedas +1);

    }

    void devolverControlAlJugador()
    {
        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = true;
    }
}
