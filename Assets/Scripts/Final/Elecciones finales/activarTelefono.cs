using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarTelefono : MonoBehaviour
{
    [SerializeField] private Interactuable i;
    [SerializeField] private Interactuable c;
    public void activar()
    {
        Invoke("activarMenus", 3);
    }

    private void activarMenus()
    {
        c.Interaccion = i.Interaccion;
        c.Activo = true;
        c.Reutilizable = true;
    }
}
