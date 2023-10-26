using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevolverCamaraAlJugador : MonoBehaviour
{
    [SerializeField] private PuntoDeNavegación destino;
    [SerializeField] private CopiarMovimientoDeLaCamara cCamara;
    [SerializeField] private SeguirPuntoDeNavegacion camara;
    
    public void devolverCamaraAlJugador()
    {
        if (destino != null && cCamara != null && camara != null)
        {
            camara.PuntosDeNavegacion = new PuntoDeNavegación[1];
            camara.PuntosDeNavegacion[0] = destino;
            camara.activo = true;
            camara.reiniciarCamino();
            Invoke("copiarMovimientoCamara", 5);
        }
    }

    public void copiarMovimientoCamara()
    {
        cCamara.activo = true;
    }
}
