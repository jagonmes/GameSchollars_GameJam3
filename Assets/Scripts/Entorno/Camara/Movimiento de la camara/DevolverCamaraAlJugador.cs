using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DevolverCamaraAlJugador : MonoBehaviour
{
    [SerializeField] private PuntoDeNavegación destino;
    [SerializeField] private CopiarMovimientoDeLaCamara cCamara;
    [SerializeField] private SeguirPuntoDeNavegacion camara;
    
    [SerializeField] private AudioClip cAudio;
    [SerializeField] private float volume = 0.2f;
    [SerializeField] private float spatialBlend = 1.0f;
    [SerializeField] private bool loop = false;
    
    private AudioSource aSource;
    
    public void devolverCamaraAlJugador()
    {
        if (destino != null && cCamara != null && camara != null)
        {
            camara.PuntosDeNavegacion = new PuntoDeNavegación[1];
            camara.PuntosDeNavegacion[0] = destino;
            camara.activo = true;
            camara.reiniciarCamino();
            Invoke("copiarMovimientoCamara", 5);
            if (cAudio != null)
            {
                aSource = this.AddComponent<AudioSource>();
                aSource.Stop();
                aSource.loop = loop;
                aSource.spatialBlend = spatialBlend;
                aSource.volume = volume;
                aSource.clip = cAudio;
                aSource.Play();
            }
        }
    }

    public void copiarMovimientoCamara()
    {
        cCamara.activo = true;
    }
}
