using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autor : Jesús Bastante López
public class PltColors : MonoBehaviour
{
    public GameObject[] platforms;
      
    public void Orange()
    {
        Debug.Log("Orange");
        for (int i = 0;i < platforms.Length;i++)
        {
            platforms[i].GetComponent<Animator>().SetInteger("State", 1);          
        }
    }

    public void Red()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].GetComponent<Animator>().SetInteger("State", 2);
        }
    }
}
