using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Llamada : MonoBehaviour
{
    [SerializeField] private AudioClip ringtone;
    [SerializeField] private float volume = 0.2f;
    [SerializeField] private float spatialBlend = 1.0f;
    [SerializeField] private bool loop = true;

    public void LlamadaDeTelefono()
    {
        if (this.GetComponent<AudioSource>() == null)
        {
            this.AddComponent<AudioSource>();
        }
        AudioSource aSource = this.GetComponent<AudioSource>();
        aSource.clip = ringtone;
        aSource.loop = loop;
        aSource.spatialBlend = spatialBlend;
        aSource.volume = volume;
        aSource.Play();
        this.GetComponent<Interactuable>().Activo = true;
    }
}