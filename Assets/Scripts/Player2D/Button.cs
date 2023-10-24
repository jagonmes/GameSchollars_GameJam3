using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador : Jesús Bastante Lopez
//No utilizado en la version final.
public class Button : MonoBehaviour
{
    private ButtonCollection buttonCollection;
    GameObject player;
    public int valor = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        buttonCollection = player.GetComponent<ButtonCollection>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RecogerMoneda();
        }
    }

    void RecogerMoneda()
    {
        // Destruye el objeto de la moneda al recogerlo.
        Destroy(gameObject);

        // Suma el valor de la moneda al contador del jugador.
        buttonCollection.AddCoin();
    }
}
