using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject instructions;
    public GameObject player;
    public bool playing = false;
    public bool active = false;

    private int minScore = (50*20 + 200*4 + 500) / 2;

    private float nextDuckSpawn = 0.0f;

    private float tiempoUltimoSpawn = 0;
    private float spawnedDucks = 0;

    List<GameObject> rails = new List<GameObject>();

    public GameObject[] ducks = new GameObject[3];
    private List<float> duckSpeeds = new List<float>();
    private List<int> duckScores = new List<int>();

    public Text scoreGUI;
    public Text resultGUI;


    void Start()
    {
        LoadLists();
    }

    // Update is called once per frame
    void Update()
    {
        if (active && !player.GetComponent<Movimiento_Mira>().active)
        {
            GameObject[] patos = GameObject.FindGameObjectsWithTag("Pato");
            for (int i = 0; i < patos.Length; i++)
            {
                patos[i].GetComponent<Comportamiento_Patos>().active = true;
            }
            player.GetComponent<Movimiento_Mira>().active = true;
            ManageGame();
        }
        else if (active)
        {
            ManageGame();
        }
        else
        {
            GameObject[] patos = GameObject.FindGameObjectsWithTag("Pato");
            for(int i = 0; i < patos.Length; i++)
            {
                patos[i].GetComponent<Comportamiento_Patos>().active = false;
            }
            player.GetComponent<Movimiento_Mira>().active = false;
        }
        
        if(instructions.active == true && Input.GetKeyDown("x"))
        {
            HideInstructions();
        } 

    }

    public void ShowInstructions()
    {
        playing = false;
        player.GetComponent<Movimiento_Mira>().active = false;
        instructions.SetActive(true);
    }

    public void HideInstructions()
    {
        playing = true;
        player.GetComponent<Movimiento_Mira>().active = true;
        instructions.SetActive(false);
    }

    void LoadLists()
    {
        duckSpeeds.Add(3.0f);
        duckSpeeds.Add(6.0f);
        duckSpeeds.Add(9.0f);

        duckScores.Add(50);
        duckScores.Add(200);
        duckScores.Add(500);

        rails.Add(GameObject.Find("Rail1"));
        rails.Add(GameObject.Find("Rail2"));
        rails.Add(GameObject.Find("Rail3"));

        nextDuckSpawn = Random.Range(25, 51)/10;
    }

    void ManageGame()
    {
        scoreGUI.text = "Score: " + player.GetComponent<Movimiento_Mira>().score + " / " + minScore;
        if (playing)
        {
            if (spawnedDucks == 25)
            {
                playing = false;
            }

            if (Time.time - tiempoUltimoSpawn >= nextDuckSpawn)
            {
                spawnedDucks++;
                int nextDuckType = 0;
                switch (spawnedDucks)
                {
                    default:
                        nextDuckType = 0;
                        break;

                    case 5:
                    case 10:
                    case 15:
                    case 20:
                        nextDuckType = 1;
                        break;

                    case 25:
                        nextDuckType = 2;
                        break;
                }

                //GetComponent<Spawn_Patos>().Spawn(ducks[2], rails[Random.Range(0, rails.Count)], duckSpeeds[2], duckScores[2]);
                GetComponent<Spawn_Patos>().Spawn(ducks[nextDuckType], rails[Random.Range(0, rails.Count)], duckSpeeds[nextDuckType], duckScores[nextDuckType]);
                tiempoUltimoSpawn = Time.time;
                nextDuckSpawn = Random.Range(25, 51) / 10;
            }
        }
        else
        {
            if(spawnedDucks == 25 && GameObject.FindGameObjectsWithTag("Pato").Length == 0)
            {
                if (player.GetComponent<Movimiento_Mira>().score > minScore)
                {
                    resultGUI.text = "¡Ganaste!";
                    SelectorFinales.añadirALaLista(true);
                }
                else
                {
                    resultGUI.text = "Perdiste";
                    SelectorFinales.añadirALaLista(false);
                }
                Invoke("devolverControlAlJugador", 3);
            }
        }
    }
    
    void devolverControlAlJugador()
    {
        active = false;
        AudioSource musica = this.GetComponent<AudioSource>();
        if (musica != null)
        {
            musica.Stop();
        }
        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = true;
        GameObject.Find("Player").GetComponent<DevolverCamaraAlJugador>()?.devolverCamaraAlJugador();
    }
}
