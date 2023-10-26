using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuntoDeNavegación : MonoBehaviour
{
    public Vector3 posicion;
    public Quaternion rotacion;
    public bool movil = false;
    public bool rotacionActiva = false;
    public bool posicionActiva = true;

    void Start()
    {
        posicion = this.transform.position;
        rotacion = this.transform.rotation;
    }
    
    void Update()
    {
        if (movil)
        {
            posicion = this.transform.position;
            rotacion = this.transform.rotation;
        }
    }
}
