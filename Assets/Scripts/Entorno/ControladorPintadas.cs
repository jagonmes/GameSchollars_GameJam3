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
        activadoresPintadas = finalesScript.ConseguirMinijuegos();
        for (int i = 0; i < pintadas.Length; i++)
        {
            if (activadoresPintadas[i])
            pintadas[i].gameObject.SetActive(true);
        }
    }

    public void activaPintada(int indicePintada)
    {
        finalesScript.activarPintada(indicePintada);
        pintadas[indicePintada].gameObject.SetActive(true);
    }




}
