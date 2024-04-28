using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambioDeEscena : MonoBehaviour
{
    [SerializeField] private int indice = -1;
    [SerializeField] private float tiempo = 3.0f;


    private String textoAMostrar1 = "Debes comer antes de dormir";
    private String textoAMostrar2 = "Debes jugar antes de dormir";
    private String textoAMostrar3 = "Debes jugar y comer antes de dormir";
    [SerializeField] private Fade fade;

    public bool haComido = false;
    private bool haJugado = false;

    //Campo de texto donde se mostrara el texto del objeto
    private TextMeshProUGUI Text;

    private void Start()
    {
       Text = GameObject.Find("TextoSubtitulos").GetComponent<TextMeshProUGUI>();
    }
    public void cambiarDeEscena()
    {

        if (indice == -1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(indice);
            
    }

    public void invocarCambiarDeEscena()
    {
        if (haComido && haJugado)
        {
            fade.activar();
            Invoke("cambiarDeEscena", tiempo);
        }
        else
        {
            noCambiarEscena();
        }
    }

    public void activarJugado()
    {
        haJugado = true;
    }

    private void QuitaTexto()
    {
        Text.text = null;
    }

    private void noCambiarEscena()
    {

        if (!haComido && haJugado)
        {
            Text.text = textoAMostrar1;
        }
        else if (haComido && !haJugado)
        {
            Text.text = textoAMostrar2;
        }
        else
        {
            Text.text = textoAMostrar3;
        }
         Invoke("QuitaTexto", 2f);
    }
}
