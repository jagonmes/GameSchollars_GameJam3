using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DesactivarRayo : MonoBehaviour
{
    public void Desactivar()
    {
        this.GetComponent<XRInteractorLineVisual>().enabled = false;
    }
    
    public void Activar()
    {
        this.GetComponent<XRInteractorLineVisual>().enabled = true;
    }
}
