using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                pintadas[2].SetActive(true);
            }
        }
    }

    public void activaPintada(int indicePintada)
    {
        //Debug.Log("AAAAAAAAAAAA" +  indicePintada);
        finalesScript.activarPintada(indicePintada);
        if(indicePintada == 3)
        {
            pintadas[indicePintada].SetActive(true);
            pintadas[2].SetActive(false);
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
