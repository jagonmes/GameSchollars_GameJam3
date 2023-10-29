using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    [SerializeField] private GameObject boton;
    [SerializeField] private GameObject yo;
    void Start()
    {
        if (SelectorFinales.minijuegosSuperados.Count < 4 || !SelectorFinales.finalActivado())
        {
            Debug.Log("Numero de minijuegos: " + SelectorFinales.minijuegosSuperados.Count);
            Debug.Log("Superados: " + SelectorFinales.finalActivado());
            Destroy(yo);
        }
        else
        {
            Destroy(boton);
        }
    }

}
