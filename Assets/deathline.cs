using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathline : MonoBehaviour
{
    public GameObject respawn;
    // Start is called before the first frame update


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = respawn.transform.position;
            //collision.gameObject.transform.rotation = respawn.transform.rotation;
        }
    }
}
