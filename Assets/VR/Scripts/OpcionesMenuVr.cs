using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpcionesMenuVr
{
    private static OpcionesMenuVr instance;

    public bool MContinuo;
    public bool MTeletransporte;
    public bool GContinuo;
    public bool GSnap;
    public bool IDirecta;
    public bool IRayo;
    public bool ASubtitulos;
    public bool AVig;
    public bool Iniciado;

    public static OpcionesMenuVr getInstance()
    {
        if (instance == null)
        {
            Debug.Log("Creando Nueva Instancia");
            instance = new OpcionesMenuVr();
            return instance; 
        }
        return instance;
    }
}
