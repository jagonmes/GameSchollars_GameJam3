using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintar : MonoBehaviour
{
    [SerializeField] private ControladorPintadas controladorPintadas;
    public void activaPintada(int indicePintada)
    {
        Debug.Log(indicePintada);

        controladorPintadas.activaPintada(indicePintada);
    }

}
