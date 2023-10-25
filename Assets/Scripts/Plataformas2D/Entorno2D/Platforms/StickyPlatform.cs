using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor : Coding in Flow https://www.youtube.com/@codinginflow
public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

}
