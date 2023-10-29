using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resultado : MonoBehaviour
{
    [SerializeField] private ControladorPintadas pintadaScript;
    [SerializeField] private AudioSource mPlataformas;

    public void Victoria()
    {
        SelectorFinales.a�adirALaLista(true);
        pintadaScript.activaPintada(4);
        pintadaScript.activaPintada(6);
        mPlataformas.Stop();
    }

    public void Derrota()
    {
        SelectorFinales.a�adirALaLista(false);
        mPlataformas.Stop();
    }
}
