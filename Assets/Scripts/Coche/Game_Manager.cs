using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class Game_Manager : MonoBehaviour
{
    public Spawn_Obstacle spawner;
    public GameObject car;
    public GameObject victimaPrefab;

    public bool finishing = false;
    public bool active = true;
    public TextMeshProUGUI textoCentralGUI;
    public float tiempoDeCuentaAtras = 3f;
    private float tiempoRestante;

    private List<int> gameSpeeds = new List<int>();
    private int actualGameSpeed = 0;

    private List<float> tiemposDeEspera = new List<float>();
    private int tiempoDeEsperaActual = 0;

    private float tiempoUltimoSpawn = 0f;

    public GameObject carretera1;
    public GameObject carretera2;

    public AudioSource winSound;
    public AudioSource music;

    void Start()
    {
        //InicioPartida();

        carretera1 = GameObject.Find("SpriteCarretera1");
        carretera2 = GameObject.Find("SpriteCarretera2");

        carretera2.transform.position = new Vector3(carretera1.transform.position.x, 
                                    carretera1.transform.position.y + carretera1.GetComponent<SpriteRenderer>().bounds.size.y, 
                                    carretera1.transform.position.z);

        gameSpeeds.Add(3);
        gameSpeeds.Add(5);
        gameSpeeds.Add(7);
        gameSpeeds.Add(10);
        gameSpeeds.Add(13);

        tiemposDeEspera.Add(3.0f);
        tiemposDeEspera.Add(2.5f);
        tiemposDeEspera.Add(2.0f);
        tiemposDeEspera.Add(1.5f);
        tiemposDeEspera.Add(1.0f);
    }

    private void Update()
    {
        if(active && !car.GetComponent<Car_Movement>().canMove && !finishing)
        {
            car.GetComponent<Car_Movement>().canMove = true;
            GameObject[] obstaculos = GameObject.FindGameObjectsWithTag("Obstacle");
            for (int i = 0; i < obstaculos.Length; i++)
            {
                obstaculos[i].GetComponent<Obstacle_Behaviour>().active = true;
            }
            ManageGame();
        }
        if (active)
        {
            ManageGame();
        }
        else
        {
            car.GetComponent<Car_Movement>().canMove = false;
            GameObject[] obstaculos = GameObject.FindGameObjectsWithTag("Obstacle");
            for (int i = 0; i < obstaculos.Length; i++)
            {
                obstaculos[i].GetComponent<Obstacle_Behaviour>().active = false;
            }
        }
    }

    public void InicioPartida()
    {
        this.active = true;
        music.Play();
        spawner.spawnActivo = false;
        car.GetComponent<Car_Movement>().canMove = false;
        tiempoRestante = tiempoDeCuentaAtras;
        ActualizarTextoCuentaAtras();

        InvokeRepeating("ActualizarCuentaAtras", 1f, 1f);
    }

    public void FinPartida()
    {
        //Debug.Log("ACABASTE");
        car.GetComponent<Car_Movement>().canMove = false;

        Vector3 posicionCarril = new Vector3(car.GetComponent<Car_Movement>().carriles[car.GetComponent<Car_Movement>().carrilActual].position.x, 
                                             3, car.GetComponent<Car_Movement>().carriles[car.GetComponent<Car_Movement>().carrilActual].position.z);
        GameObject victima = Instantiate(victimaPrefab, posicionCarril, Quaternion.identity);

        textoCentralGUI.text = "¡Lo lograste!";
        music.Stop();
        winSound.Play();
    }

    void ActualizarCuentaAtras()
    {
        tiempoRestante -= 1f;
        ActualizarTextoCuentaAtras();
        if (tiempoRestante <= 0f)
        {
            CancelInvoke("ActualizarCuentaAtras");
            textoCentralGUI.text = " ";
            spawner.spawnActivo = true;
            car.GetComponent<Car_Movement>().canMove = true;
        }
    }

    void ActualizarTextoCuentaAtras()
    {
        textoCentralGUI.text = tiempoRestante.ToString();
    }

    void ManageGameSpeed()
    {
        if (carretera1.transform.position.y + carretera1.GetComponent<SpriteRenderer>().bounds.size.y/2 < -carretera1.GetComponent<SpriteRenderer>().bounds.size.y/2)
        {
            carretera1.transform.position = new Vector3(carretera1.transform.position.x,
                                    carretera2.transform.position.y + carretera1.GetComponent<SpriteRenderer>().bounds.size.y,
                                    carretera1.transform.position.z);
        }
        else if (carretera2.transform.position.y + carretera2.GetComponent<SpriteRenderer>().bounds.size.y / 2 < -carretera2.GetComponent<SpriteRenderer>().bounds.size.y / 2)
        {
            carretera2.transform.position = new Vector3(carretera2.transform.position.x,
                                    carretera1.transform.position.y + carretera2.GetComponent<SpriteRenderer>().bounds.size.y,
                                    carretera2.transform.position.z);
        }

        carretera1.transform.Translate(new Vector3(0, -1, 0) * gameSpeeds[actualGameSpeed] * Time.deltaTime);
        carretera2.transform.Translate(new Vector3(0, -1, 0) * gameSpeeds[actualGameSpeed] * Time.deltaTime);

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for(int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<Obstacle_Behaviour>().fallSpeed = gameSpeeds[actualGameSpeed];
        }
    }

    void ManageGame()
    {
        if (spawner.spawnActivo)
        {
            if (Time.time - tiempoUltimoSpawn >= tiemposDeEspera[tiempoDeEsperaActual])
            {
                spawner.SpawnObstacle(Random.Range(0, car.GetComponent<Car_Movement>().carriles.Length));
                tiempoUltimoSpawn = Time.time;

                if (spawner.spawnedObstacles % 6 == 0 && gameSpeeds.Count - 1 > actualGameSpeed)
                {
                    actualGameSpeed++;
                    tiempoDeEsperaActual++;
                }
            }
        }


        if (spawner.spawnedObstacles == 30)
        {
            spawner.spawnActivo = false;
            if (GameObject.FindWithTag("Obstacle") == null && !finishing)
            {
                finishing = true;
                FinPartida();
            }
        }

        if (finishing)
        {
            car.transform.Translate(new Vector3(0, 7, 0) * Time.deltaTime, Space.World);

            if(car.transform.position.y > 10)
            {
                SelectorFinales.añadirALaLista(true);
                Pintar pintar = this.GetComponent<Pintar>();
                pintar.activaPintada(0);
                devolverControlAlJugador();
            }
        }
        else
        {
            ManageGameSpeed();
        }
    }

    public void devolverControlAlJugador()
    {
        active = false;
        AudioSource musica = this.GetComponent<AudioSource>();
        if (musica != null)
        {
            musica.Stop();
        }
        car.GetComponent<Car_HP_Manager>().crushSound.Stop();
        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = true;
        GameObject.Find("Player").GetComponent<DevolverCamaraAlJugador>()?.devolverCamaraAlJugador();
    }
}
