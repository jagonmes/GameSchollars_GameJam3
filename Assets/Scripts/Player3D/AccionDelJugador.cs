using System;
using TMPro;
using UnityEngine;

public class AccionDelJugador : MonoBehaviour
{
    [SerializeField] private Transform camara;
    [SerializeField] private float distanciaDeActivacion;
    [SerializeField] private KeyCode teclaDeAccion;
    [SerializeField] private TextMeshProUGUI textoAccion;

    private void Update()
    {
        textoAccion.text = "";
        RaycastHit hit;

        //Comprueba si hay un objeto al que el jugador este mirando y dentro de la distancia de activación
        if (Physics.Raycast(camara.position, camara.TransformDirection(Vector3.forward), out hit,
                distanciaDeActivacion))
        {
            //Recoje el componente "Interactuable" del objeto, si existe
            Interactuable i = hit.transform.GetComponent<Interactuable>();
            //Comprueba si el objeto es interactuable
            if (i != null)
            {
                //Si es interactuable y se pulsaa la tecla de acción, interactua con el mismo
                if (Input.GetKeyDown(teclaDeAccion))
                {
                    i.Interactuar();
                }

                //Se muestra el cambio visual
                i.Visual();
            }
        }
    }
}