using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ControlCoche : MonoBehaviour
{
    [SerializeField] private XRKnob dial;
    public static bool izquierda = false;
    public static bool derecha = false;
    public static bool centro = true;
    [SerializeField] private Game_Manager coches;
    [SerializeField] private GameObject instrucciones;
    private bool enActivo = false;
    void Update()
    {
        if (enActivo)
        {
            izquierda = dial.value == 0.0f;
            centro = dial.value == 0.5f;
            derecha = dial.value == 1.0f;
        }
    }

    public void activarCoches()
    {
        if (!enActivo)
        {
            coches.InicioPartida();
            instrucciones?.SetActive(false);
            enActivo = true;
        }
    }
}
