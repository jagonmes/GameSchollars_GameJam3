using UnityEngine;

public class ActivarPC : MonoBehaviour
{
    [SerializeField] private Interactuable pc;
    [SerializeField] private GameObject plano;
    [SerializeField] private int retraso;
    

    public void activarPC()
    {
        pc.Activo = true;
        plano.SetActive(false);
    }
    
    public void activarPCConRetardo()
    {
        Invoke("activarPC", retraso);
    }
}
