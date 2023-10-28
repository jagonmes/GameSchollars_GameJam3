using System.Collections.Generic;
using UnityEngine;

public class SelectorFinales : MonoBehaviour
{
    public static List<bool> minijuegosSuperados;

    static bool[] decallsActivados = new bool[6];
    public static bool finalActivado()
    {
        bool activo = true;
        foreach (var superado in minijuegosSuperados)
        {
            if (!superado)
                activo = false;
        }

        return activo;
    }

    public static void añadirALaLista(bool resultado)
    {
        if (minijuegosSuperados == null)
        {
            minijuegosSuperados = new List<bool>();
            Debug.Log("Creando nueva lista de minijuegos superados");
        }
        minijuegosSuperados.Add(resultado);
    }
    
    public static void reiniciar()
    { 
        if (minijuegosSuperados == null)
        {
            minijuegosSuperados = new List<bool>();
            Debug.Log("Creando nueva lista de minijuegos superados");
        }
        minijuegosSuperados.Clear();
        for (int i = 0; i < 6; i++)
        {
            decallsActivados[(int)i] = false;
        }
    }

    public bool[] ConseguirPintadas()
    {
        return decallsActivados;
    }

    public void activarPintada(int indice)
    {
        if(indice == 4)
        {
            decallsActivados[4] = true;
            decallsActivados[3] = false;
        }
        else
        {
            decallsActivados[indice] = true;
        }
    }
}
