using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PeriodicoView : MonoBehaviour
{
    [SerializeField]private GameObject periodico;

    private String textoAMostrar = "Pulsa E para salir";

    private TextMeshProUGUI Text;

    private bool canScape = false;

    private void Start()
    {
        Text = GameObject.Find("TextoSubtitulos").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && canScape)
        {
            // Realiza alguna acción cuando se presiona la tecla W
            Debug.Log("Tecla E presionada");
            periodico.SetActive(false);
            Text.text = null;
            devolverControlAlJugador();
            this.gameObject.SetActive(false);
        }

    }
    public void CogerPeriodico()
    {
        Debug.Log(periodico);
        quitarControlAlJugador();
        periodico.SetActive(true);
        Invoke("activarBoolScape", 0.5f);
        Text.text = textoAMostrar;
    }

    private void devolverControlAlJugador()
    {
        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = true;
    }

    private void quitarControlAlJugador()
    {
        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = false;
    }

    private void activarBoolScape()
    {
        canScape = true;
    }
}

