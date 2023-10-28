using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Final2 : MonoBehaviour
{
    [SerializeField] private Fade fade;
    [SerializeField] private CambiarEscena cambiarDeEscena;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private GameObject imagen;
   void Start()
   {
     Invoke("activarFade", 5);
     Invoke("quitarImagen", 7);
     Invoke("activarFade", 8);
     Invoke("activarFade", 12);
     Invoke("activarCambio", 15);
    }

   void activarFade()
   {
    fade.activar();
   }

   void activarCambio()
   {
    cambiarDeEscena.changeScene();
   }

   void quitarImagen()
   {
    imagen.SetActive(false);
    texto.text = "Es lo mejor para todos, " + Environment.UserName + ".\nAqui no haremos daño a nadie.";
   }
}
