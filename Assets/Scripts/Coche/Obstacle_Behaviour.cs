using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Behaviour : MonoBehaviour
{
    public float fallSpeed = 5.0f;
    public bool active = true;
    void Update()
    {
        if (active)
        {
            transform.Translate(new Vector3(0, -1, 0) * fallSpeed * Time.deltaTime);

            if(transform.position.y < -8)
            {
                Destroy(gameObject);
                //Debug.Log("murió");
            }
        }
    }
}
