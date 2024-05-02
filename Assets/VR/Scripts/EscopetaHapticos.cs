using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EscopetaHapticos : MonoBehaviour
{
    [SerializeField]private XRBaseControllerInteractor[] interactorI;
    [SerializeField]private XRBaseControllerInteractor[] interactorD;


    public void Disparo(ActivateEventArgs args)
    {
        if (args.interactorObject == interactorI[1] || args.interactorObject == interactorI[0] ||
            args.interactorObject == interactorI[2])
        {
            Movimiento_Mira.dispararIzquierda = true;
            Movimiento_Mira.dispararDerecha = false;
        }
        else if (args.interactorObject == interactorD[1] || args.interactorObject == interactorD[0] ||
            args.interactorObject == interactorD[2])
        {
            Movimiento_Mira.dispararIzquierda = false;
            Movimiento_Mira.dispararDerecha = true;
        }
    }

}
