using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAhorcado : MonoBehaviour
{

   [SerializeField] private Ahorcado ahorcado;

   public void activarAhorcado()
   {
      ahorcado.activo = ahorcado.iniciarJuego = ahorcado.juegoEnMarcha = true;
      GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = false;
   }


}
