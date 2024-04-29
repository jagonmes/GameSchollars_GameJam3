using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuVR : MonoBehaviour
{
    public bool CambioPermitido = true;

    [SerializeField] private Toggle[] Toggles;
    [SerializeField] private Toggle Vig;

    [SerializeField] private GameObject[] Movimiento;
    [SerializeField] private GameObject[] Giro;
    [SerializeField] private GameObject[] Interaccion;
    [SerializeField] private GameObject[] Accesibilidad;
    [SerializeField] private GameObject[] TPInteractors;
    [SerializeField] private CharacterControllerDriver CCD;

    private void Awake()
    {
        
        if (!OpcionesMenuVr.getInstance().Iniciado)
        {
            OpcionesMenuVr.getInstance().MContinuo = true;
            OpcionesMenuVr.getInstance().MTeletransporte = false;
            OpcionesMenuVr.getInstance().GContinuo = true;
            OpcionesMenuVr.getInstance().GSnap = false;
            OpcionesMenuVr.getInstance().IDirecta = true;
            OpcionesMenuVr.getInstance().IRayo = false;
            OpcionesMenuVr.getInstance().ASubtitulos = true;
            OpcionesMenuVr.getInstance().AVig = true;
            OpcionesMenuVr.getInstance().Iniciado = true;
        }
        activarToggles();
        aplicarCambios();
    }

    public void resetearToggles()
    {
        Toggles[0].isOn = true;
        Toggles[1].isOn = false;
        Toggles[2].isOn = true;
        Toggles[3].isOn = false;
        Toggles[4].isOn = true;
        Toggles[5].isOn = false;
        Toggles[6].isOn = true;
        Vig.isOn = true;
    }

    public void activarToggles()
    {
        foreach (Toggle toggle in Toggles)
        {
            toggle.interactable = CambioPermitido;
        }

        Toggles[0].isOn = OpcionesMenuVr.getInstance().MContinuo;
        Toggles[1].isOn = OpcionesMenuVr.getInstance().MTeletransporte;
        Toggles[2].isOn = OpcionesMenuVr.getInstance().GContinuo;
        Toggles[3].isOn = OpcionesMenuVr.getInstance().GSnap;
        Toggles[4].isOn = OpcionesMenuVr.getInstance().IDirecta;
        Toggles[5].isOn = OpcionesMenuVr.getInstance().IRayo;
        Toggles[6].isOn = OpcionesMenuVr.getInstance().ASubtitulos;
        Vig.isOn = OpcionesMenuVr.getInstance().AVig;
        
    }

    public void aplicarCambios()
    {
        if (CambioPermitido)
        {
            asignarInteraccion();
            asignarMovimiento();
            asignarGiro();
        }
        asignarAccesibilidad();
    }

    void asignarMovimiento()
    {
        Movimiento[0].SetActive(OpcionesMenuVr.getInstance().MContinuo);
        Movimiento[1].SetActive(OpcionesMenuVr.getInstance().MTeletransporte);
        //CCD.enabled = (MTeletransporte);
        if (OpcionesMenuVr.getInstance().MTeletransporte)
        {
            if (OpcionesMenuVr.getInstance().IRayo)
            {
                TPInteractors[0].SetActive(false);
                TPInteractors[1].SetActive(false);
                TPInteractors[2].SetActive(true);
                TPInteractors[3].SetActive(true);
                Interaccion[2].SetActive(false);
                Interaccion[3].SetActive(false);
            }
            else
            {
                TPInteractors[0].SetActive(true);
                TPInteractors[1].SetActive(true);
                TPInteractors[2].SetActive(false);
                TPInteractors[3].SetActive(false);
            }

        }
        else
        {
            TPInteractors[0].SetActive(false);
            TPInteractors[1].SetActive(false);
            TPInteractors[2].SetActive(false);
            TPInteractors[3].SetActive(false);
        }
    }
    
    void asignarInteraccion()
    {
        Interaccion[0].SetActive(OpcionesMenuVr.getInstance().IDirecta);
        Interaccion[1].SetActive(OpcionesMenuVr.getInstance().IDirecta);
        Interaccion[2].SetActive(OpcionesMenuVr.getInstance().IRayo);
        Interaccion[3].SetActive(OpcionesMenuVr.getInstance().IRayo);
    }
    
    void asignarGiro()
    {
        Giro[0].SetActive(OpcionesMenuVr.getInstance().GContinuo);
        Giro[1].SetActive(OpcionesMenuVr.getInstance().GSnap);   
    }

    void asignarAccesibilidad()
    {
        Accesibilidad[0].SetActive(OpcionesMenuVr.getInstance().ASubtitulos);
        Accesibilidad[1].SetActive(OpcionesMenuVr.getInstance().AVig);
    }

    public void cambiarMovimiento()
    {
        OpcionesMenuVr.getInstance().MContinuo = Toggles[0].isOn;
        OpcionesMenuVr.getInstance().MTeletransporte = Toggles[1].isOn;
    }

    public void cambiarGiro()
    {
        OpcionesMenuVr.getInstance().GContinuo = Toggles[2].isOn;
        OpcionesMenuVr.getInstance().GSnap = Toggles[3].isOn;
    }
    
    public void cambiarInteraccion()
    {
        OpcionesMenuVr.getInstance().IDirecta = Toggles[4].isOn;
        OpcionesMenuVr.getInstance().IRayo = Toggles[5].isOn;
    }

    public void cambiarAccesibilidad()
    {
        OpcionesMenuVr.getInstance().ASubtitulos = Toggles[6].isOn;
    }
    
    public void cambiarVig()
    {
        OpcionesMenuVr.getInstance().AVig = Vig.isOn;
    }
}
