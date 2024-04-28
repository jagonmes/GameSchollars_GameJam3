using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCoche : MonoBehaviour
{
    
    [SerializeField] private GameObject instrucciones;
    [SerializeField] private Game_Manager coches;
    [SerializeField] private TransportarJugadorVR TP;
    
    public void activarCoches()
    {
        TP.IniciarTeletransporte();
    }
}
