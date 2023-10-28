using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPintadas : MonoBehaviour
{
    [SerializeField] private GameObject[] pintadas;
    private bool[] activadoresPintadas;

    [SerializeField] private SelectorFinales finalesScript;

    private void Start()
    {
        activadoresPintadas = finalesScript.ConseguirPintadas();
        for (int i = 0; i < pintadas.Length; i++)
        {
            Debug.Log(i);
            if (activadoresPintadas[i])
            {
                Debug.Log(i);
                Debug.Log(activadoresPintadas[i]);
                pintadas[i].gameObject.SetActive(true);
            }
            else
            {
                pintadas[i].gameObject.SetActive(false);
            }
        }
    }

    public void activaPintada(int indicePintada)
    {
        //Debug.Log("AAAAAAAAAAAA" +  indicePintada);
        finalesScript.activarPintada(indicePintada);
        if(indicePintada == 4)
        {
            pintadas[indicePintada].SetActive(true);
            pintadas[3].SetActive(false);
        }
        else
        {
            pintadas[indicePintada].SetActive(true);
        }
    }

    public bool mirarPintada(int indicePintada)
    {
        return activadoresPintadas[indicePintada];
    }
}
