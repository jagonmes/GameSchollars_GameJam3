using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resultado : MonoBehaviour
{
    public void Victoria()
    {
        SelectorFinales.a�adirALaLista(true);
    }

    public void Derrota()
    {
        SelectorFinales.a�adirALaLista(false);
    }
}
