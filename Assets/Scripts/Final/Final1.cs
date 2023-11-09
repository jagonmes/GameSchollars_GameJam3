using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Final1 : MonoBehaviour
{
    [SerializeField] private Fade fade;
    [SerializeField] private CambiarEscena cambiarDeEscena;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private GameObject imagen;
   void Start()
   {
     Invoke("activarFade", 15);
     Invoke("quitarImagen", 17);
     Invoke("activarFade", 18);
     Invoke("activarFade", 22);
     Invoke("activarCambio", 25);//+10
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
    texto.text = "¿Que te parece "+ Environment.UserName +"? Un final perfecto para nosotros, ¿verdad?";
   }
}
