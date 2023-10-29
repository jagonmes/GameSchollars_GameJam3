using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USB : MonoBehaviour
{
    [SerializeField] private Interactuable robot;

    public void activarRobot()
    {
        robot.Activo = true;
    }
}
