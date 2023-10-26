using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Comportamiento_Patos : MonoBehaviour
{
    public bool active = true;
    public float speedX;
    public float posY;
    private int yRange = 1;
    private float speedY = 0.8f;
    public int score;
    bool secondChance = true;

    void Update()
    {
        if (active) { 
            //Movimiento en X
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speedX, Space.World);

            //Movimiento en Y
            if(transform.position.y >= posY + yRange || transform.position.y <= posY - yRange)
            {
                speedY *= -1;
            }
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speedY, Space.World);

            //Para el pato dorado
            if(Math.Abs(speedX) == 9)
            {
                if (Math.Abs(transform.position.x) > 12 && secondChance){
                    Flip();
                    speedX *= -1;
                    secondChance = false;
                }
            }

            //Destruir
            if (transform.position.x > 20 || transform.position.x < -20)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Flip()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
    }

}
