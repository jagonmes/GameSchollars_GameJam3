using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCoche : MonoBehaviour
{
    
    [SerializeField] private GameObject instrucciones;
    [SerializeField] private Game_Manager coches;
    
    private bool activo = false;
    private bool usado = false;
    void OnGUI()
    {
        Event e = Event.current;
        if (activo && e.isKey && !usado)
        {
            switch (e.keyCode)
            {
                case KeyCode.X:
                    coches.InicioPartida();
                    instrucciones?.SetActive(false);
                    usado = true;
                    break;
                default:
                    break;
            }
        }
    }
    public void activarCoches()
    {

        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = false;
        this.transform.GetComponent<MoverCamaraAPC>().moverCamaraAPC();
        activo = true;
    }
}
