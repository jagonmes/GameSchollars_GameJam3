using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    public float velocidadRotacion = 100f;
    private void FixedUpdate()
    {
        // Rotar el objeto en sentido contrario a las agujas del reloj
        transform.Rotate(Vector3.forward * velocidadRotacion * Time.fixedDeltaTime);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    
}
