using System;
using UnityEngine;

public class ActivarAhorcado : MonoBehaviour
{
   [SerializeField] private Ahorcado ahorcado;
   [SerializeField] private GameObject instrucciones;
   private bool activo = false;
   void OnGUI()
   {
      Event e = Event.current;
      if (activo && e.isKey)
      {
         switch (e.keyCode)
         {
            case KeyCode.X:
               ahorcado.activo = ahorcado.iniciarJuego = ahorcado.juegoEnMarcha = true;
               instrucciones?.SetActive(false);
               break;
            default:
               break;
         }
      }
   }

   public void activarAhorcado()
   {
      
      GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = false;
      this.transform.GetComponent<MoverCamaraAPC>().moverCamaraAPC();
      activo = true;
   }
}
