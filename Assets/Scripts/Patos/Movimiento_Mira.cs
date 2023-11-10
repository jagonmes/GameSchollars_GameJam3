using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento_Mira : MonoBehaviour
{
    private float velocidad = 5f; // Velocidad de movimiento de la mira
    private bool disparando = false;

    private float tiempoDisparando = 0.1f;
    private float tiempoDesdeInicioDisparo = 0.0f;

    public bool active = false;
    public int score = 0;

    public AudioSource popSFX;
    public AudioSource pumSFX;
    public GameObject blood;

    void Update()
    {
        if (active) {
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            float desplazamientoX = movimientoHorizontal * velocidad * Time.deltaTime;
            float desplazamientoY = movimientoVertical * velocidad * Time.deltaTime;

            transform.Translate(new Vector3(desplazamientoX, desplazamientoY, 0f));

            float limiteX = Mathf.Clamp(transform.position.x, -9f, 9f); // L�mites en el eje X
            float limiteY = Mathf.Clamp(transform.position.y, -5f, 5f); // L�mites en el eje Y

            transform.position = new Vector3(limiteX, limiteY, transform.position.z);

            if (Input.GetKeyDown(KeyCode.Space) && !disparando)
            {
                Disparar();
            }
            else if (disparando)
            {
                //Debug.Log("PIUM!");
                if(Time.time - tiempoDesdeInicioDisparo > tiempoDisparando)
                {
                    disparando = false;
                }
            }
        }
    }

    void Disparar()
    {
        disparando = true;
        tiempoDesdeInicioDisparo = Time.time;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Chocan");
        if (collision.transform.tag == "Pato" && disparando)
        {
            if(System.Math.Abs(collision.GetComponent<Comportamiento_Patos>().speedX) > 4)
            {
                pumSFX.Play();
                GameObject bloodInst = Instantiate(blood, new Vector3(collision.GetComponent<Transform>().position.x, 
                    collision.GetComponent<Transform>().position.y - 0.1f, collision.GetComponent<Transform>().position.z), Quaternion.identity);
            }
            else
            {
                popSFX.Play();
            }
            score += collision.GetComponent<Comportamiento_Patos>().score;
            Destroy(collision.gameObject);
        }
    }
}
