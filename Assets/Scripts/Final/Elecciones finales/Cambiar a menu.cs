using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambiaramenu : MonoBehaviour
{
    [SerializeField] private GameObject aCambiar;
    [SerializeField] private GameObject miMenu;

    public void cambiar()
    {
        miMenu.SetActive(false);
        aCambiar.SetActive(true);
    }
}
