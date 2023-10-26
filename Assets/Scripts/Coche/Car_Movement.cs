using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform[] carriles;
    public int carrilActual = 1;
    public bool canMove = true;

    public float tiempoDeEspera = 0.005f; 
    private float tiempoUltimoCambio = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3 (carriles[carrilActual].position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        var movimiento = Input.GetAxis("Horizontal");

        if (Time.time - tiempoUltimoCambio >= tiempoDeEspera && canMove) { 
            if (movimiento > 0 && carrilActual != 2)
            {
                carrilActual++;
                tiempoUltimoCambio = Time.time;
                //Debug.Log(carrilActual);
            }
            else if (movimiento < 0 && carrilActual != 0)
            {
                carrilActual--;
                tiempoUltimoCambio = Time.time;
                //Debug.Log(carrilActual);
            }

            transform.position = new Vector3 (carriles[carrilActual].position.x, transform.position.y, transform.position.z);
        }
    }
}
