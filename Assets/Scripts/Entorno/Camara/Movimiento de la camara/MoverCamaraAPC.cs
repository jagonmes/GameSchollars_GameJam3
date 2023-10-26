using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamaraAPC : MonoBehaviour
{
    [SerializeField] private PuntoDeNavegación destino;
    [SerializeField] private CopiarMovimientoDeLaCamara cCamara;
    [SerializeField] private SeguirPuntoDeNavegacion camara;
    
    public void moverCamaraAPC()
    {
        cCamara.activo = false;
        camara.PuntosDeNavegacion = new PuntoDeNavegación[1];
        camara.PuntosDeNavegacion[0] = destino;
        camara.activo = true;
        camara.reiniciarCamino();
    }
}
