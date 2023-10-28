using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    [SerializeField] CambioDeEscena cambiaEscena;
    private GameObject[] maquinasExp;
    
    private void Start()
    {
       /* Debug.Log("a");
        maquinasExp = GameObject.FindGameObjectsWithTag("MaquinaExp"); // Usamos FindGameObjectsWithTag, ya que es común etiquetar objetos con etiquetas.

        // Ahora tienes todos los objetos del tipo en el array objetosDelTipo.
        foreach (var objeto in maquinasExp)
        {
            // Haz algo con cada objeto si es necesario.
            Debug.Log(objeto.name);
        }*/
    }
    public void comer()
    {
        Debug.Log("a");
        maquinasExp = GameObject.FindGameObjectsWithTag("MaquinaExp"); // Usamos FindGameObjectsWithTag, ya que es común etiquetar objetos con etiquetas.
        if (cambiaEscena.haComido == false)
        {
            cambiaEscena.haComido = true;
            apagaMaquinas();
        }
    }

    private void apagaMaquinas()
    {
        for (int i = 0; i < maquinasExp.Length; i++)
            if (maquinasExp[i] != this.gameObject)
            {
                maquinasExp[i].gameObject.GetComponent<Interactuable>().Activo = false;
            }
    }
}
