using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintar : MonoBehaviour
{
    [SerializeField] int indicePintada;
    [SerializeField] private ControladorPintadas controladorPintadas;
    public void activaPintada()
    {
        controladorPintadas.activaPintada(indicePintada);
    }

}
