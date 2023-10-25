using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor : Jesús Bastante López
public class PltColors : MonoBehaviour
{
    public GameObject[] platforms;
    /*void Start()
    {
        int childCount = this.transform.childCount;

        // Inicializa el array de plataformas con el tamaño correcto.
        platforms = new GameObject[childCount];

        // Llena el array con los objetos hijos del contenedor.
        for (int i = 0; i < childCount; i++)
        {
            platforms[i] = this.transform.GetChild(i).gameObject;
        }
    }*/

     
    public void Orange()
    {
        for(int i = 0;i < platforms.Length;i++)
        {
            platforms[i].GetComponent<Animator>().SetInteger("State", 1);          
        }
    }

    public void Red()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].GetComponent<Animator>().SetInteger("State", 2);
        }
    }
}
