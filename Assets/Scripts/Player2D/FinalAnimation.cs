using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMovement controller;

    public void endAnimation()
    {
        controller.active = 0;
    }
   
}
