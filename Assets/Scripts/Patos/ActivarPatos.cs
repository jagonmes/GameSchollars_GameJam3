using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPatos : MonoBehaviour
{
    [SerializeField] private GameManager patos;
    [SerializeField] private AudioSource mPatos;
    [SerializeField] private TransportarJugadorVR TP;

    public void activarPatos()
    {
        TP.IniciarTeletransporte();
        patos.GetComponent<GameManager>().ShowInstructions();
        //GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = false;
        //this.transform.GetComponent<MoverCamaraAPC>().moverCamaraAPC();
        patos.active = true;
        mPatos.Play();
    }
}
