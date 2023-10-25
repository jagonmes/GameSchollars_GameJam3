using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuntoDeNavegación : MonoBehaviour
{
    public Vector3 posicion;
    public Quaternion rotacion;

    void Start()
    {
        posicion = this.transform.position;
        rotacion = this.transform.rotation;
    }
}
