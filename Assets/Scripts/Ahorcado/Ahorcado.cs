using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class Ahorcado : MonoBehaviour
{
    //Campos de texto
    [SerializeField] private TextMeshProUGUI palabra;
    [SerializeField] private TextMeshProUGUI aciertos;
    [SerializeField] private TextMeshProUGUI fallos;

    //Palabras que saldrán en el juego
    [SerializeField] private String[] palabras;
    private String palabraActiva;
    private char[] letrasPalabraActiva;
    private List<char> letrasUsadas = new List<char>();
    private bool[] aciertosPalabraActiva;
    

    [SerializeField] private float TiempoDeRefresco = 2.0f;
    private float CoolDown = 0.0f;
    private bool habilitado = false;
    public bool activo = true;


    void OnGUI()
    {
        Event e = Event.current;
        if (habilitado && e.isKey)
        {
            switch (e.keyCode)
            {
                case KeyCode.A:
                    comprobarLetra('a');
                    break;
                case KeyCode.B:
                    comprobarLetra('b');
                    break;
                case KeyCode.C:
                    comprobarLetra('c');
                    break;
                case KeyCode.D:
                    comprobarLetra('d');
                    break;
                case KeyCode.E:
                    comprobarLetra('e');
                    break;
                case KeyCode.F:
                    comprobarLetra('f');
                    break;
                case KeyCode.G:
                    comprobarLetra('g');
                    break;
                case KeyCode.H:
                    comprobarLetra('h');
                    break;
                case KeyCode.I:
                    comprobarLetra('i');
                    break;
                case KeyCode.J:
                    comprobarLetra('j');
                    break;
                case KeyCode.K:
                    comprobarLetra('k');
                    break;
                case KeyCode.L:
                    comprobarLetra('l');
                    break;
                case KeyCode.M:
                    comprobarLetra('m');
                    break;
                case KeyCode.N:
                    comprobarLetra('n');
                    break;
                case KeyCode.BackQuote:
                    comprobarLetra('ñ');
                    break;
                case KeyCode.O:
                    comprobarLetra('o');
                    break;
                case KeyCode.P:
                    comprobarLetra('p');
                    break;
                case KeyCode.Q:
                    comprobarLetra('q');
                    break;
                case KeyCode.R:
                    comprobarLetra('r');
                    break;
                case KeyCode.S:
                    comprobarLetra('s');
                    break;
                case KeyCode.T:
                    comprobarLetra('t');
                    break;
                case KeyCode.U:
                    comprobarLetra('u');
                    break;
                case KeyCode.V:
                    comprobarLetra('v');
                    break;
                case KeyCode.W:
                    comprobarLetra('w');
                    break;
                case KeyCode.X:
                    comprobarLetra('x');
                    break;
                case KeyCode.Y:
                    comprobarLetra('y');
                    break;
                case KeyCode.Z:
                    comprobarLetra('z');
                    break;
                default:
                    break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cargarPalabra();
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            if (!habilitado && CoolDown <= 0.0f)
            {
                habilitado = true;
            }
            else
            {
                CoolDown -= Time.deltaTime;
            }
        }
    }

    void cargarPalabra()
    {
        int i = Random.Range(0, palabras.Length);
        palabraActiva = palabras[i];
        String aux = palabraActiva.ToLower();
        //reemplazar acentos y dieresis
        aux = aux.Replace('á', 'a');
        aux = aux.Replace('ä', 'a');
        aux = aux.Replace('é', 'e');
        aux = aux.Replace('ë', 'e');
        aux = aux.Replace('í', 'i');
        aux = aux.Replace('ï', 'i');
        aux = aux.Replace('ó', 'o');
        aux = aux.Replace('ö', 'o');
        aux = aux.Replace('ú', 'u');
        aux = aux.Replace('ü', 'u');
        //se rellena el array con las letras de la palabra activa
        letrasPalabraActiva = aux.ToCharArray();
        //se inicializan los aciertos (todos a falso)
        aciertosPalabraActiva = new bool[letrasPalabraActiva.Length];
        for (i = 0; i < aciertosPalabraActiva.Length; i++)
            aciertosPalabraActiva[i] = false;
        //se borran las letras usadas
        letrasUsadas.Clear();
        //se borran los campos palabra, aciertos y fallos
        palabra.text = "";
        aciertos.text = "";
        fallos.text = "";
        //Pintamos la palabra activa
        pintarPalabraActiva();
    }

    void comprobarLetra(char c)
    {
        bool acierto = false;
        if (!letrasUsadas.Contains(c))
        {
            for (int i = 0; i < letrasPalabraActiva.Length; i++)
            {
                if (letrasPalabraActiva[i] == c)
                {
                    acierto = true;
                    aciertosPalabraActiva[i] = true;
                }
            }

            letrasUsadas.Add(c);


            if (acierto)
            {
                aciertos.text += c.ToString().ToUpper();
                pintarPalabraActiva();
            }
            else
            {
                fallos.text += c.ToString().ToUpper();
            }
        }
        
        habilitado = false;
        CoolDown = TiempoDeRefresco;
    }

    void pintarPalabraActiva()
    {
        palabra.text = "\" ";
        for (int i = 0; i < aciertosPalabraActiva.Length; i++)
        {
            if (aciertosPalabraActiva[i])
            {
                palabra.text += palabraActiva[i] + " ";
            }
            else
            {
                palabra.text += "_ ";
            }
        }
        palabra.text += "\"";
    }
}
