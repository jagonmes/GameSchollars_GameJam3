using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
//Autor del codigo: Coding in Flow https://www.youtube.com/@codinginflow
{
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private float speed = 2f;
    private int currentWaypointIndex = 0;
    private void Update()
    {
        if (Vector3.Distance(wayPoints[currentWaypointIndex].transform.position,transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
