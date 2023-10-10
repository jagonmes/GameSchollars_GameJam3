using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Llamada : MonoBehaviour
{
    [SerializeField] private AudioClip ringtone;
    [SerializeField] private float volume;
    [SerializeField] private float spatialBlend;
    [SerializeField] private bool loop;

    public void LlamadaDeTelefono()
    {
        this.AddComponent<AudioSource>();
        AudioSource aSource = this.GetComponent<AudioSource>();
        aSource.clip = ringtone;
        aSource.loop = loop;
        aSource.spatialBlend = spatialBlend;
        aSource.volume = volume;
        aSource.Play();
        this.GetComponent<Interactuable>().Activo = true;
    }
}