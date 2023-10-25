using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPuntoDeNavegacion : MonoBehaviour
{
    
    [SerializeField] private PuntoDeNavegación[] PuntosDeNavegacion;
    [SerializeField]private int indice = 0;

    [SerializeField] private float velocidad = 2.0f;
    [SerializeField] private float velocidadDeRotacion = 2.0f;
    [SerializeField] private float velocidadMinima = 0.05f;
    [SerializeField] private float velocidadDeRotacionMinima = 0.05f;
    [SerializeField] private float velocidadMaxima = 2.0f;
    [SerializeField] private float velocidadDeRotacionMaxima = 2.0f;
    [SerializeField] private float DistanciaMinima = 0.1f;
    [SerializeField]private bool finDelCamino = false;
    private float distanciaALaProximaPosicion = 0.0f;
    private float distanciaALaProximaRotacion = 0.0f;
    private int ultimoIndice = -1;

    [SerializeField] private bool continuo = false;

    private void Update()
    {
        if (!finDelCamino)
        {
            
            //Comprobamos si hemos llegado al destino
            if (Math.Abs(Vector3.Distance(PuntosDeNavegacion[indice].posicion, transform.position)) < DistanciaMinima && Math.Abs(Quaternion.Angle(PuntosDeNavegacion[indice].rotacion, transform.rotation)) < DistanciaMinima) 
            {
                
                indice++;
                if (indice >= PuntosDeNavegacion.Length) 
                {
                    finDelCamino = true;
                    ultimoIndice = -1;
                    if(continuo)
                        reiniciarCamino();
                }
            }
            
            //calculamos la velocidad
            calcularVelocidad();
            
            //Si no hemos llegado a la posición deseada, nos movemos
            if (Math.Abs(Vector3.Distance(PuntosDeNavegacion[indice].posicion, transform.position)) > DistanciaMinima)
                transform.position = Vector3.MoveTowards(transform.position, PuntosDeNavegacion[indice].transform.position, Time.deltaTime * velocidad);
            
            //Si no hemos llegado a la rotación deseada, rotamos
            if(Math.Abs(Quaternion.Angle(PuntosDeNavegacion[indice].rotacion, transform.rotation)) > DistanciaMinima)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, PuntosDeNavegacion[indice].rotacion, velocidadDeRotacion);
        }
    }

    public void reiniciarCamino()
    {
        indice = 0;
        finDelCamino = false;
    }

    private void calcularVelocidad()
    {
        
        if (ultimoIndice != indice)
        {
            distanciaALaProximaPosicion = Math.Abs(Math.Abs(Vector3.Distance(PuntosDeNavegacion[indice].posicion, transform.position)) * 2 - 1);
            distanciaALaProximaRotacion = Math.Abs(Quaternion.Angle(PuntosDeNavegacion[indice].rotacion, transform.rotation));
            ultimoIndice = indice;
        }

        float factorDistancia = 1, factorRotacion = 1;
        if(distanciaALaProximaPosicion != 0.0f)
            factorDistancia = Math.Abs(Vector3.Distance(PuntosDeNavegacion[indice].posicion, transform.position)) / distanciaALaProximaPosicion;
        if(distanciaALaProximaRotacion != 0.0f)
            factorRotacion = Quaternion.Angle(PuntosDeNavegacion[indice].rotacion, transform.rotation );
        Debug.Log(factorRotacion);

        velocidad = velocidadMaxima * (1 - (float)Math.Sqrt(factorDistancia));
        velocidadDeRotacion = velocidadDeRotacionMaxima * (1 - (float)Math.Sqrt(factorRotacion));
        if (velocidad < velocidadMinima)
            velocidad = velocidadMinima;
        if (velocidadDeRotacion < velocidadDeRotacionMinima)
            velocidadDeRotacion = velocidadDeRotacionMinima;
    }
    

}
