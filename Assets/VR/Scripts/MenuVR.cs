using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuVR : MonoBehaviour
{
    public static bool MContinuo = true;
    public static bool MTeletransporte = false;
    public static bool GContinuo = true;
    public static bool GSnap = false;
    public static bool IDirecta = true;
    public static bool IRayo = false;
    public static bool ASubtitulos = true;
    public static bool AVig = true;
    public bool CambioPermitido = true;

    [SerializeField] private Toggle[] Toggles;

    [SerializeField] private GameObject[] Movimiento;
    [SerializeField] private GameObject[] Giro;
    [SerializeField] private GameObject[] Interaccion;
    [SerializeField] private GameObject[] Accesibilidad;
    [SerializeField] private GameObject[] TPInteractors;
    [SerializeField] private CharacterControllerDriver CCD;

    private void Start()
    {
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
        Toggles[7].isOn = true;
    }

    public void activarToggles()
    {
        foreach (Toggle toggle in Toggles)
        {
            toggle.interactable = CambioPermitido;
        }

        Toggles[0].isOn = MContinuo;
        Toggles[1].isOn = MTeletransporte;
        Toggles[2].isOn = GContinuo;
        Toggles[3].isOn = GSnap;
        Toggles[4].isOn = IDirecta;
        Toggles[5].isOn = IRayo;
        Toggles[6].isOn = ASubtitulos;
        Toggles[7].isOn = AVig;
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
        Debug.Log("Aplicando Cambios");
        Movimiento[0].SetActive(MContinuo);
        Debug.Log(MContinuo);
        Debug.Log(Movimiento[0].active);
        Movimiento[1].SetActive(MTeletransporte);
        //CCD.enabled = (MTeletransporte);
        if (MTeletransporte)
        {
            if (IRayo)
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
        Interaccion[0].SetActive(IDirecta);
        Interaccion[1].SetActive(IDirecta);
        Interaccion[2].SetActive(IRayo);
        Interaccion[3].SetActive(IRayo);
    }
    
    void asignarGiro()
    {
        Giro[0].SetActive(GContinuo);
        Giro[1].SetActive(GSnap);   
    }

    void asignarAccesibilidad()
    {
        Accesibilidad[0].SetActive(ASubtitulos);
        Accesibilidad[1].SetActive(AVig);
    }

    public void cambiarMovimiento()
    {
        MContinuo = Toggles[0].isOn;
        MTeletransporte = Toggles[1].isOn;
    }

    public void cambiarGiro()
    {
        GContinuo = Toggles[2].isOn;
        GSnap = Toggles[3].isOn;
    }
    
    public void cambiarInteraccion()
    {
        IDirecta = Toggles[4].isOn;
        IRayo = Toggles[5].isOn;
    }

    public void cambiarAccesibilidad()
    {
        ASubtitulos = Toggles[6].isOn;
        AVig = Toggles[7].isOn;
    }
}
