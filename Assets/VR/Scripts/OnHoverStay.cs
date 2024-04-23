using UnityEngine;
using UnityEngine.Events;

public class OnHoverStay : MonoBehaviour
{
    private bool Active = false;
    [SerializeField] public UnityEvent Interaccion;
    void Update()
    {
        if(Active)
            Interaccion?.Invoke();
    }

    public void Activar()
    {
        Active = true;
    }

    public void Desactivar()
    {
        Active = false;
    }
}
