using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    //animator del player
    public Animator playerAnimator;
    //gameobject knife y su animador
    public GameObject knife;
    private Animator knifeAnimator;
    //gameObject texto "Felicidades"
    public GameObject feliz;

    private int numMonedas;

    //obtiene el codigo PlayerMovement
    [SerializeField] private PlayerMovement controller;
    //obtiene el codigo PltColorAdmin para cambiar colores del mapa
    [SerializeField] private GroundColorAdmin colorAdm;
    //obtiene el codigo ButtonCollection para devolve el control al jugador
    [SerializeField] private ButtonCollection collector;

    void Start()
    {
        //consigue animator del player
        //consigue el animator de knife
        knifeAnimator = knife.GetComponent<Animator>();
        //consigue el animator de felicidades
    }

    public void SceneColors(int state)
    {
        numMonedas = state;
        switch (state)
        {
            case 1:
                UnityEngine.Debug.Log("1");
                colorAdm.orangeColor();
                break;
            case 2:
                UnityEngine.Debug.Log("2");
                colorAdm.redColor();
                break;
            case 3:
                UnityEngine.Debug.Log("Final");
                endAnimation();
                break;
        }

    }
    private void endAnimation()
    {
        //impide movimiento de jugador
        controller.active = 0;
        //activa cuchillo y regula tiempos de animacion
        knife.gameObject.SetActive(true);
        UnityEngine.Debug.Log("1");
        Invoke("Kill", 2f);
        Invoke("Death", 3f);
        Invoke("Transform", 8f);

    }
    //activa la animacion Knife killing
    private void Kill()
    {
        knifeAnimator.SetBool("iskilling", true);
    }
    //activa la animacion Knife transforming
    // y el mensaje felicidades
    private void Transform()
    {
        knifeAnimator.SetBool("isTransforming", true);
        feliz.gameObject.SetActive(true);
        Invoke("devolverControlAlJugador", 7f);
    }
    //actuva la aniamcion de player death
    private void Death()
    {
        playerAnimator.SetInteger("State", numMonedas + 1);

    }

    void devolverControlAlJugador()
    {
        collector.DevolverControlAlJugador();
    }
}
