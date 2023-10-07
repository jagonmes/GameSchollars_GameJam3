using System;
using UnityEngine;

public class AccionDelJugador : MonoBehaviour
{
    [SerializeField]private Transform camara;
    [SerializeField]private float distanciaDeActivacion;
    [SerializeField] private KeyCode teclaDeAccion;

    private void Update()
    {
        RaycastHit hit;
        
        if (Input.GetKeyDown(teclaDeAccion))
        {
            //Comprueba si hay un objeto al que el jugador este mirando y dentro de la distancia de activación
            if (Physics.Raycast(camara.position, camara.TransformDirection(Vector3.forward), out hit, distanciaDeActivacion))
            {
                //Comprueba si el objeto es interactuable
                if (hit.transform.GetComponent<Interactuable>() != null)
                {
                    hit.transform.GetComponentInParent<Animator>().SetTrigger("abrir");
                }
            }
        }
    }
}
