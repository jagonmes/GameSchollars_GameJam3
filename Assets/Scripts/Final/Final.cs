using System;
using TMPro;
using UnityEngine;


public class Final : MonoBehaviour
{
    [SerializeField] private Fade fade;
    [SerializeField] private CambiarEscena cambiarDeEscena;
    [SerializeField] private TextMeshProUGUI texto;
   void Start()
   {
    texto.text = Environment.UserName + texto.text;
     
     Invoke("activarFade", 5);
     Invoke("activarCambio", 7);
    }

   void activarFade()
   {
    fade.activar();
   }

   void activarCambio()
   {
    cambiarDeEscena.changeScene();
   }
}
