using Unity.VisualScripting;
using UnityEngine;

public class MoverCamaraAPC : MonoBehaviour
{
    [SerializeField] private PuntoDeNavegación destino;
    [SerializeField] private CopiarMovimientoDeLaCamara cCamara;
    [SerializeField] private SeguirPuntoDeNavegacion camara;
    
    [SerializeField] private AudioClip cAudio;
    [SerializeField] private float volume = 0.2f;
    [SerializeField] private float spatialBlend = 1.0f;
    [SerializeField] private bool loop = false;
    
    private AudioSource aSource;
    
    public void moverCamaraAPC()
    {
        if (destino != null && cCamara != null && camara != null)
        {
            cCamara.activo = false;
            camara.PuntosDeNavegacion = new PuntoDeNavegación[1];
            camara.PuntosDeNavegacion[0] = destino;
            camara.activo = true;
            camara.reiniciarCamino();
            
            if (this.GetComponent<AudioSource>() == null)
            {
                this.AddComponent<AudioSource>();
            }
            if (cAudio != null)
            {
                aSource = this.GetComponent<AudioSource>();
                aSource.Stop();
                aSource.loop = loop;
                aSource.spatialBlend = spatialBlend;
                aSource.volume = volume;
                aSource.clip = cAudio;
                aSource.Play();
            }
        }
    }
}
