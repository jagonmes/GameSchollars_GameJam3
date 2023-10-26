using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProhibidoPasar : MonoBehaviour
{
    [SerializeField] private PuntoDeNavegación[] puntosDeNavegacion;
    [SerializeField] private GameObject jugador;
    [SerializeField] private GameObject robot;

    private SeguirPuntoDeNavegacion robotSPDN;
    private Movimiento jugadorM;
    private Transform jugadorParent;
    private bool enMovimiento = false;
    private int indice = 0;

    private void Start()
    {
        robotSPDN = robot.GetComponent<SeguirPuntoDeNavegacion>();
        jugadorM = jugador.GetComponent<Movimiento>();
        jugadorParent = jugador.transform.parent;
    }

    private void Update()
    {
        if (enMovimiento)
        {
            if (robotSPDN.finDelCamino)
            {
                Debug.Log("FinDElCamino");
                switch (indice)
                {
                    case 0:
                        robotSPDN.PuntosDeNavegacion = new PuntoDeNavegación[1];
                        robotSPDN.PuntosDeNavegacion[0] = puntosDeNavegacion[2];
                        jugadorM.transform.parent = robotSPDN.transform;
                        robotSPDN.reiniciarCamino();
                        indice = 1;
                        break;
                    case 1:
                        robotSPDN.PuntosDeNavegacion = new PuntoDeNavegación[2];
                        robotSPDN.PuntosDeNavegacion[0] = puntosDeNavegacion[3];
                        robotSPDN.PuntosDeNavegacion[1] = puntosDeNavegacion[4];
                        jugadorM.transform.parent = jugadorParent;
                        robotSPDN.reiniciarCamino();
                        indice = 2;
                        break;
                    case 2:
                        enMovimiento = false;
                        indice = 0;
                        jugadorM.JugadorActivo = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        jugadorM.JugadorActivo = false;
        robotSPDN.PuntosDeNavegacion = new PuntoDeNavegación[2];
        robotSPDN.PuntosDeNavegacion[0] = puntosDeNavegacion[0];
        robotSPDN.PuntosDeNavegacion[1] = puntosDeNavegacion[1];
        robotSPDN.reiniciarCamino();
        robotSPDN.activo = true;
        enMovimiento = true;
    }
}
