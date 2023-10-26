using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Patos : MonoBehaviour
{
    public void Spawn(GameObject duck, GameObject rail, float speedX, int score)
    {
        if (Random.Range(0, 2) == 0)
        {
            GameObject pato_spawneado = GameObject.Instantiate(duck, rail.transform.position, Quaternion.identity);
            pato_spawneado.GetComponent<Comportamiento_Patos>().posY = rail.transform.position.y;
            pato_spawneado.GetComponent<Comportamiento_Patos>().speedX = speedX;
            pato_spawneado.GetComponent<Comportamiento_Patos>().score = score;
        }
        else
        {
            GameObject pato_spawneado = GameObject.Instantiate(duck, new Vector3(rail.transform.position.x * -1, rail.transform.position.y, 0), Quaternion.identity);
            pato_spawneado.GetComponent<Comportamiento_Patos>().posY = rail.transform.position.y;
            pato_spawneado.GetComponent<Comportamiento_Patos>().speedX = speedX * -1;
            pato_spawneado.GetComponent<Comportamiento_Patos>().score = score;
            pato_spawneado.GetComponent<Comportamiento_Patos>().Flip();
        }
    }
}
