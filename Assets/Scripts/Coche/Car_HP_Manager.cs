using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_HP_Manager : MonoBehaviour
{
    public int hp = 3;
    private bool bloodReady = true;

    public UI_Manager manager;
    public GameObject bloodMark;
    public AudioSource crushSound;

    // Update is called once per frame
    void Update()
    {
        manager.ActualizarVidas(hp);

        if(hp <= 0)
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            crushSound.Play();
            hp--;
        }
        else
        {
            if (bloodReady)
            {
                Vector3 posicion = transform.position;
                GameObject blood = Instantiate(bloodMark, posicion, Quaternion.identity);

                bloodReady = false;
            }
        }
    }
}
