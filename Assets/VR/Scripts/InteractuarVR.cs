using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractuarVR : MonoBehaviour
{
    [SerializeField] public UnityEvent[] Interacciones;
    [SerializeField] public UnityEvent[] InteraccionesSalida;
    
    public void interactuarVR(SelectEnterEventArgs args)
    {
        if (args.interactorObject.ToString().Contains("SocketInteractor")) return;
        foreach (var interaccion in Interacciones)
        {
            interaccion?.Invoke();
        }
    }
    public void interactuarVR(SelectExitEventArgs args)
    {
        if (args.interactorObject.ToString().Contains("SocketInteractor")) return;
        foreach (var interaccion in InteraccionesSalida)
        {
            interaccion?.Invoke();
        }
    }  
}
