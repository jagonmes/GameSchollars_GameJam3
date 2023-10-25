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
    private GameObject[] monedas;

    //obtiene el codigo PlayerMovement
    [SerializeField] private PlayerMovement controller;
    //obtiene el codigo PltColorAdmin para cambiar colores del mapa
    [SerializeField] private GroundColorAdmin colorAdm;

    [SerializeField] private AnimationsController colorAnimations;

    [SerializeField] private PlayerAnimations playerAnimations;

    

    private void Update()
    {
        //actualiza el numero de monedas
        //hecho asi por el bug de collider2D que suma dos veces 1
        monedas = GameObject.FindGameObjectsWithTag("Coin");
        numMonedas = monedasTotales - monedas.Length;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Invoke("AddButton",0.5f);
            Destroy(other.gameObject);
        }
    }
    //añade moneda, y si son 3 llama a la animacion final
    public void AddButton()
    {
        Debug.Log("Btonoes" + numMonedas);
        //actualiza el animator del player
        //actualiza la situacion de la escena(colores)
        if (numMonedas == 1)
        {
            playerAnimations.controlAnimations(4);
            colorAnimations.SceneColors(1);
        }
        else if (numMonedas == 2)
        {
            playerAnimations.controlAnimations(5);
            colorAnimations.SceneColors(2);
        }
        else if(numMonedas == 3)
        {
            playerAnimations.controlAnimations(6);
            colorAnimations.SceneColors(3);
        }
        else 
        {
            Debug.Log("Error en numero de monedas");
        }
    }
    public void DevolverControlAlJugador()
    {
        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = true;
    }
}
