using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Abrir_Cerrar : MonoBehaviour
{
    [SerializeField]private SeguirPuntoDeNavegacion Puerta;
    [SerializeField]private Interactuable PuertaI;
    [SerializeField] private PuntoDeNavegación Abrir;
    [SerializeField] private PuntoDeNavegación Cerrar;
    [SerializeField] private float tiempoAbierta = 5;
    private bool abierto = false;
    
    void Start()
    {
        Puerta.PuntosDeNavegacion = new PuntoDeNavegación[1];
        Puerta.PuntosDeNavegacion[0] = Cerrar;
        Puerta.activo = true;
    }
    
    public void AbrirCerrar()
    {
        if (!abierto)
        {
            Puerta.PuntosDeNavegacion[0] = Abrir;
            Puerta.reiniciarCamino();
            abierto = true;
            PuertaI.Reutilizable = false;
            Invoke("AbrirCerrar", tiempoAbierta);
        }
        else
        {
            Puerta.PuntosDeNavegacion[0] = Cerrar;
            Puerta.reiniciarCamino();
            abierto = false;
            PuertaI.Reutilizable = true;
        }
    }
}
