using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundColorAdmin : MonoBehaviour
{

    //obtener los gameObjects que poseen el tileMap
    public GameObject redTilemap;
    public GameObject purpleTilemap;
    public GameObject orangeTilemap;
    public PltColors PltColors;

    //ajustan el color activando y desactivando
    //gameObjects poseedores de tileMaps
    public void orangeColor()
    {
        purpleTilemap.SetActive(false);
        orangeTilemap.SetActive(true);
        redTilemap.SetActive(false);
        Debug.Log(PltColors);
        PltColors.Orange();
    }
    public void redColor()
    {
        purpleTilemap.SetActive(false);
        orangeTilemap.SetActive(false);
        redTilemap.SetActive(true);
        PltColors.Red();
    }
}
