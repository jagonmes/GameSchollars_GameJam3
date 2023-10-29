using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colgarllamada : MonoBehaviour
{
    [SerializeField] private GameObject[] paneles;
    [SerializeField] private MenuFinales menu;
    public void colgar()
    {
        if (paneles != null)
        {
            for (int i = 0; i < paneles.Length; i++)
            {
                paneles[i].SetActive(false);
            }
            menu.Reanudar();
        }
    }
}
