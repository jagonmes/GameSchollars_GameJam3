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
     Invoke("activarFade", 10);
     Invoke("quitarImagen", 12);
     Invoke("activarFade", 13);
     Invoke("activarFade", 17);
     Invoke("activarCambio", 20);//+10
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
