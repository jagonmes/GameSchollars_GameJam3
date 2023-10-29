using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorFinales : MonoBehaviour
{
    public static List<bool> minijuegosSuperados = new List<bool>();
    static bool[] decallsActivados = new bool[7];

    private void Awake()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            reiniciar();
        }
        Debug.Log(minijuegosSuperados.Count);
    }
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
        }
        Debug.Log("Resultado añadido");
        minijuegosSuperados.Add(resultado);
    }
    
    public static void reiniciar()
    { 
        if (minijuegosSuperados == null)
        {
            minijuegosSuperados = new List<bool>();
        }
        minijuegosSuperados.Clear();
        for (int i = 0; i < decallsActivados.Length; i++)
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
        if(indice == 3)
        {
            decallsActivados[3] = true;
            decallsActivados[2] = false;
        }
        else
        {
            decallsActivados[indice] = true;
        }
    }
}
