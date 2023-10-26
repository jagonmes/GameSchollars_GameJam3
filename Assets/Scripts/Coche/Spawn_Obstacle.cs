using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn_Obstacle : MonoBehaviour
{
    public Transform[] carriles;
    public GameObject obstaculoPrefab;

    public bool spawnActivo = true;
    public int spawnedObstacles = 0;

    public void SpawnObstacle(int carril)
    {
        spawnedObstacles++;
        Vector3 posicionCarril = new Vector3(carriles[carril].position.x, 6, 0);
        GameObject obstaculo = Instantiate(obstaculoPrefab, posicionCarril, Quaternion.identity);
        obstaculo.transform.localScale = obstaculoPrefab.transform.localScale;
    }

}
