using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPintadas : MonoBehaviour
{
    [SerializeField] private GameObject[] pintadas;
    public bool[] activadoresPintadas;

    [SerializeField] private SelectorFinales finalesScript;

    private void Start()
    {
        activadoresPintadas = finalesScript.ConseguirPintadas();
        for (int i = 0; i < pintadas.Length; i++)
        {
            if (activadoresPintadas[i])
            {
                pintadas[i].gameObject.SetActive(true);
            }
        }
    }

    public void activaPintada(int indicePintada)
    {
        Debug.Log("AAAAAAAAAAAA" +  indicePintada);
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
