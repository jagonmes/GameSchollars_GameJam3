using UnityEngine;

public class CopiarMovimientoDeLaCamara : MonoBehaviour
{
    [SerializeField] private Camera camara;
    public bool activo = true;
    
    void Update()
    {
        if (activo)
        {
            this.transform.position = camara.transform.position;
            this.transform.rotation = camara.transform.rotation;
        }
    }
}
