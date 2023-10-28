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
    
    
    [SerializeField] private AudioClip cAudio;
    [SerializeField] private float volume = 0.2f;
    [SerializeField] private float spatialBlend = 1.0f;
    [SerializeField] private bool loop = false;
    
    private bool abierto = false;
    private AudioSource aSource;
    
    void Start()
    {
        Puerta.PuntosDeNavegacion = new PuntoDeNavegación[1];
        Puerta.PuntosDeNavegacion[0] = Cerrar;
        Puerta.activo = true;
    }
    
    public void AbrirCerrar()
    {
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
