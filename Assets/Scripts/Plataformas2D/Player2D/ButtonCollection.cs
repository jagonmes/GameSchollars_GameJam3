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

    [SerializeField] private PlayerAnimations playerAnimations;

    [SerializeField] private AudioController soundController;

    [SerializeField] private Resultado resultado;

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
        //soundController.coinSound();
        //actualiza el animator del player
        //actualiza la situacion de la escena(colores)
        if (numMonedas == 1)
        {
            soundController.scream1Sound();
            playerAnimations.controlAnimations(4);
            colorAdm.orangeColor();
        }
        else if (numMonedas == 2)
        {
            soundController.scream2Sound();
            playerAnimations.controlAnimations(5);
            colorAdm.redColor();
        }
        else if(numMonedas == 3)
        {
            playerAnimations.controlAnimations(6);
            resultado.Victoria();
        }
        else 
        {
            Debug.Log("Error en numero de monedas");
        }
    }
}
