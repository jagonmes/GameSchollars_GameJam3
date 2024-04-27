using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class OnHoverStay : MonoBehaviour
{
    private bool Active = false;
    [SerializeField] public UnityEvent Interaccion;
    void Update()
    {
        if(Active)
            Interaccion?.Invoke();
    }

    public void Activar(HoverEnterEventArgs args)
    {

        if (args.interactorObject.ToString().Contains("SocketInteractor")) return;
        Active = true;
    }

    public void Desactivar(HoverExitEventArgs args)
    {
        if (args.interactorObject.ToString().Contains("SocketInteractor")) return;
        Active = false;
    }
}
