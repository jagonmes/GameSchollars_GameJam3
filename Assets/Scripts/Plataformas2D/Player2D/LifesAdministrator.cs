using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesAdministrator : MonoBehaviour
{
    private int lifes = 3;

    public GameObject[] lifeSprites;
    public GameObject cartelDerrota;

    [SerializeField] private PlayerMovement playerMovement;

    //Resta vidas y aplica los cambios necesarios
    public void LessLifes()
    {
        lifes--;
        lifeSprites[lifes].SetActive(false);

        //si el jugador no tiene vidas:
        //oculta al personaje, activa el cartel de derrota y devuelve el
        //control al jugador 3D
        if (lifes <= 0)
        {
            playerMovement.active = 0;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            cartelDerrota.SetActive(true);
            Invoke("devolverControlAlJugador", 2f);
        }
    }
    //devuelve el control al jugador 3D
    private void  devolverControlAlJugador()
    {
        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = true;
    }

    public void dissolveLifes()
    {
        for(int i = 0; i < lifes; i++)
        {
            lifeSprites[i].SetActive(false);

        }
    }
}
