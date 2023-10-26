using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;


public class Ahorcado : MonoBehaviour
{
    //Campos de texto
    [SerializeField] private TextMeshProUGUI palabra;
    [SerializeField] private TextMeshProUGUI pregunta;
    [SerializeField] private TextMeshProUGUI aciertos;
    [SerializeField] private TextMeshProUGUI fallos;
    
    //Plano del Ahorcado
    [SerializeField] private GameObject ahorcado;
    private Material materialAhorcado;
    
    //EtapasDelAhorcado
    [SerializeField] private Texture2D[] etapasAhorcado;

    //Palabras que saldrán en el juego
    [SerializeField] private String[] preguntas;
    [SerializeField] private String[] palabras;
    
    //Colores de las preguntas, respuestas y del ahorcado
    [SerializeField] private Color[] coloresPreguntas;
    [SerializeField] private Color[] coloresRespuestas;
    [SerializeField] private Color[] coloresAhorcado;
    
    //VARIABLES INTERNAS PARA EL JUEGO///////////
    private String palabraActiva;
    private char[] letrasPalabraActiva;
    private List<char> letrasUsadas = new List<char>();
    private bool[] aciertosPalabraActiva;
    
    //tiempo de refresco entre pulsaciones de teclas
    [SerializeField] private float TiempoDeRefresco = 2.0f;
    private float CoolDown = 2.0f;
    
    //indica que la entrada por teclado esta habilitada
    private bool habilitado = false;
    
    //indica que el script esta activo
    public bool activo = true;

    //indica que empiece el juego
    public bool iniciarJuego = false;
    //indica que el juego esta en marcha
    public bool juegoEnMarcha = false;

    //Indica en que pregunta y palabra estamos
    private int contadorNumeroDePalabra = 0;
    
    //Indica cuantos fallos se han dado en esta ronda
    private int contadorFallos = 0;
    
    //Numero de fallos permitidos
    [SerializeField]private int limiteDeFallos = 5;
    


    //Recoge los eventos de teclado
    void OnGUI()
    {
        Event e = Event.current;
        if (habilitado && e.isKey && !Pausa.juegoPausado)
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

    void Start()
    {
        materialAhorcado = ahorcado.GetComponent<Renderer>(). material;
    }

    // En update 
    void Update()
    {
        if (activo)
        {
            //Si esta activo y se da la orden de iniciar el juego, se carga una palabra y una pregunta
            if (iniciarJuego)
            {
                cargarPalabra();
                //ponemos la variable iniciar juego a false para no seguir reseteando los campos
                iniciarJuego = false;
            }
            //Si el juego esta en marcha se pone en marcha la lógica interna
            if (juegoEnMarcha)
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
    }

    //Se carga una paralabra y una pregunta
    void cargarPalabra()
    {
        //ponemos el contador de fallos a 0
        contadorFallos = 0;
        aciertos.text = "";
        fallos.text = "";
        //cargamos la palabra
        palabraActiva = palabras[contadorNumeroDePalabra];
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
        for (int i = 0; i < aciertosPalabraActiva.Length; i++)
            aciertosPalabraActiva[i] = false;
        //se borran las letras usadas
        letrasUsadas.Clear();
        //se borran los campos palabra, aciertos y fallos
        palabra.text = "";
        aciertos.text = "";
        fallos.text = "";
        //Pintamos la palabra activa
        pintarPalabraActiva();
        //Pintamos la pregunta
        pintarPregunta();
        //Se actualiza la figura del ahorcado
        pintarAhorcado();
        
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
        }
        if (acierto)
        {
            aciertos.text += c.ToString().ToUpper();
            pintarPalabraActiva();
            //compruebo si la palabra esta completa
            bool palabraCompletada = true;
            foreach (bool a in aciertosPalabraActiva)
            {
                if (!a)
                    palabraCompletada = false;
            }

            if (palabraCompletada)
            {
                //paramos los inputs del jugador
                juegoEnMarcha = false;
                //Invocamos a la función tiempo finDePartida con un tiempo de espera para que el cambio no sea instantaneo
                Invoke("finDePartida", 2f);
            }


        }
        else
        {
            fallos.text += c.ToString().ToUpper();
            contadorFallos++;
            //Se actualiza la figura del ahorcado
            pintarAhorcado();
            //si se alcanza el limite de fallos
            if (contadorFallos > limiteDeFallos)
            {
                //paramos los inputs del jugador
                juegoEnMarcha = false;
                //Invocamos a la función tiempo finDePartida con un tiempo de espera para que el cambio no sea instantaneo
                Invoke("finDePartida", 2f);
            }

            

                
        }
        
        habilitado = false;
        CoolDown = TiempoDeRefresco;
    }

    //pinta por la palabra actual por pantalla con el color correspondiente
    void pintarPalabraActiva()
    {
        palabra.color = coloresRespuestas[contadorNumeroDePalabra];
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
    
    //pinta por pantalla la pregunta
    void pintarPregunta()
    {
        pregunta.color = coloresPreguntas[contadorNumeroDePalabra];
        pregunta.text = preguntas[contadorNumeroDePalabra];
    }
    
    //Pinta la fase actual del Ahorcado
    private void pintarAhorcado()
    {
        //Se actualiza la figura del ahorcado
        if (materialAhorcado.HasProperty("_Fase"))
            materialAhorcado.SetTexture("_Fase", etapasAhorcado[contadorFallos]);
        if (materialAhorcado.HasProperty("_Color"))
            materialAhorcado.SetColor("_Color", coloresAhorcado[contadorNumeroDePalabra]);
    }

    //Función que controla lo que pasa al final de la partida
    private void finDePartida(){
        //Si el jugador pierde
        if (contadorFallos > limiteDeFallos)
        {
            palabra.text = "HAS PERDIDO";
            Invoke("devolverControlAlJugador", 2f);
        }
        else
        {
            //Si el jugador gana y no quedan más palabras
            if (contadorNumeroDePalabra == palabras.Length - 1)
            {
                palabra.text = "HAS GANADO";
                Invoke("devolverControlAlJugador", 2f);
            }
            //Si el jugador gana y quedan más palabras
            else
            {
                contadorNumeroDePalabra++;
                cargarPalabra();
                juegoEnMarcha = true;
            }
        }
    }
    
    //Se ejecuta al finalizar el juego
    void devolverControlAlJugador()
    {
        juegoEnMarcha = habilitado = activo = juegoEnMarcha = false;
        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = true;
        this.transform.GetComponent<DevolverCamaraAlJugador>()?.devolverCamaraAlJugador();
    }
}
