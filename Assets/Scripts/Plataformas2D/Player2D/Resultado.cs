using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resultado : MonoBehaviour
{
    public void Victoria()
    {
        SelectorFinales.aņadirALaLista(true);
        GameObject.Find("FueEl").GetComponent<Movimiento>().JugadorActivo = true;
    }

    public void Derrota()
    {
        SelectorFinales.aņadirALaLista(false);
    }
}
