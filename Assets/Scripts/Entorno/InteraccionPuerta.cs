using System;
using TMPro;
using UnityEngine;

public class InteraccionPuerta : MonoBehaviour
{
    private GameObject Text;

    private void Start()
    {
        Text = GameObject.Find("TextoAcción");
    }

    public void AbrirCerrar()
    {
        this.GetComponentInParent<Animator>().SetTrigger("abrir");
    }

    public void InformacionVisual()
    {
        Text.GetComponent<TextMeshProUGUI>().text = "Puerta";
    }
}