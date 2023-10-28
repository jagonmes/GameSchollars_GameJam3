using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambioDeEscena : MonoBehaviour
{
    [SerializeField] private int indice = -1;
    [SerializeField] private float tiempo = 3.0f;
    [SerializeField] private String textoAMostrar;
    [SerializeField] private Fade fade;

    public bool haComido = false;
    public void cambiarDeEscena()
    {
        if (haComido)
        {
            fade.activar();
            if (indice == -1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene(indice);
        }
        else
        {
            Debug.Log("No puedo dormir");
        }
    }

    public void invocarCambiarDeEscena()
    {     
        Invoke("cambiarDeEscena", tiempo);       
    }
}
