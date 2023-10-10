using UnityEngine;

public class InteraccionPuerta : MonoBehaviour
{
    public void AbrirCerrar()
    {
        this.GetComponentInParent<Animator>().SetTrigger("abrir");
    }
}