using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SeguirPuntoDeNavegacion : MonoBehaviour
{
    
    [SerializeField] public PuntoDeNavegación[] PuntosDeNavegacion;
    private int indice = 0;

    [SerializeField] private float velocidad = 1.0f;
    [SerializeField] private float velocidadDeRotacion = 1.0f;
    [SerializeField] private float DistanciaMinima = 0.1f;
    [SerializeField] private float DistanciaMinimaRotacion = 0.1f;
    public bool finDelCamino = false;
    public bool activo = false;

    [SerializeField] private bool continuo = false;


    private void Update()
    {
        if (!finDelCamino && activo && !Pausa.juegoPausado)
        {
            if (PuntosDeNavegacion != null && PuntosDeNavegacion.Length > indice)
            {
                //Comprobamos si hemos llegado al destino
                if ((PuntosDeNavegacion[indice].posicionActiva && !PuntosDeNavegacion[indice].rotacionActiva &&
                     comprobarDistancia()) ||
                    !PuntosDeNavegacion[indice].posicionActiva && PuntosDeNavegacion[indice].rotacionActiva &&
                    comprobarRotacion() || (PuntosDeNavegacion[indice].posicionActiva &&
                                            PuntosDeNavegacion[indice].rotacionActiva && comprobarDistancia() &&
                                            comprobarRotacion()))
                {
                    indice++;
                    if (indice >= PuntosDeNavegacion.Length)
                    {
                        finDelCamino = true;
                        if (continuo)
                            reiniciarCamino();
                    }
                }
                else
                {
                    //Si no hemos llegado a la posición deseada, nos movemos
                    if (PuntosDeNavegacion[indice].posicionActiva && !comprobarDistancia())
                    {
                        transform.position = Vector3.MoveTowards(transform.position,
                            PuntosDeNavegacion[indice].transform.position, velocidad * Time.deltaTime);
                    }

                    if (PuntosDeNavegacion[indice].rotacionActiva && !comprobarRotacion())
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                            PuntosDeNavegacion[indice].rotacion, velocidadDeRotacion * Time.deltaTime);
                    }
                }
            }
        }
    }

    public void reiniciarCamino()
    {
        indice = 0;
        finDelCamino = false;
    }

    private bool comprobarRotacion()
    {
        return Math.Abs(Quaternion.Angle(PuntosDeNavegacion[indice].rotacion, transform.rotation)) <= DistanciaMinimaRotacion;
    }
    
    private bool comprobarDistancia()
    {
        return Math.Abs(Vector3.Distance(PuntosDeNavegacion[indice].posicion, transform.position)) <= DistanciaMinima;
    }

    
}
