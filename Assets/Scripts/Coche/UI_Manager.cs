using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject vidaPrefab;
    public Transform vidasContainer;

    public void ActualizarVidas(int cantidadDeVidas)
    {
        // Elimina todos los sprites de vida existentes en el contenedor
        foreach (Transform child in vidasContainer)
        {
            Destroy(child.gameObject);
        }

        // Instancia los nuevos sprites de vida seg�n la cantidad de vidas del jugador
        for (int i = 0; i < cantidadDeVidas; i++)
        {
            GameObject vida = Instantiate(vidaPrefab, vidasContainer);
            // Puedes ajustar la posici�n de los sprites de vida seg�n tu dise�o
            vida.transform.localPosition = new Vector3(i * 50, 0, 0);
        }
    }
}
