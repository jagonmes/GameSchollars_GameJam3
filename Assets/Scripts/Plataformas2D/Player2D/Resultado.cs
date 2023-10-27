using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resultado : MonoBehaviour
{
    public void Victoria()
    {
        SelectorFinales.añadirALaLista(true);
    }

    public void Derrota()
    {
        SelectorFinales.añadirALaLista(false);
    }
}
