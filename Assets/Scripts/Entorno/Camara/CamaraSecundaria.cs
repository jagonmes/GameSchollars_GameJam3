using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camarasecundaria : MonoBehaviour
{
    
    [SerializeField]private Camera camara;
    private RenderTexture rt;
    private int UltimoAltoDePantalla;
    private int UltimoAnchoDePantalla;
    
    void Start()
    {
        /*
        rt = camara.targetTexture;
        UltimoAltoDePantalla = Screen.height;
        UltimoAnchoDePantalla = Screen.width;
        CambiarTamañoRT(rt, UltimoAnchoDePantalla, UltimoAltoDePantalla);
        */
    }

    void Update()
    {
        /*
        if (Screen.height != UltimoAltoDePantalla || Screen.width != UltimoAnchoDePantalla)
        {
            UltimoAltoDePantalla = Screen.height;
            UltimoAnchoDePantalla = Screen.width;
            CambiarTamañoRT(rt, UltimoAnchoDePantalla, UltimoAltoDePantalla);
        }
        */
    }

    void CambiarTamañoRT(RenderTexture rt, int ancho, int alto)
    {
       rt.Release();
       rt.width = ancho;
       rt.height = alto;
       camara.targetTexture = rt;
    }

}
