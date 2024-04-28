using UnityEngine;

public class TransportarJugadorVR : MonoBehaviour
{
    [SerializeField] private Transform jugador;
    [SerializeField] private Transform puntoDeSpawn;
    [SerializeField] public bool fade = true;
    [SerializeField] private Fade fadeScript;

    public void IniciarTeletransporte()
    {
        if (fade)
        {
            Fade();
            Invoke("teletransporte", 3);
        }
        else
        {
            teletransporte();
        }
    }

    private void teletransporte()
    {
        jugador.position = puntoDeSpawn.position;
        jugador.rotation = puntoDeSpawn.rotation;
        if (fade)
        {
            Fade();
        }
    }

    private void Fade()
    {
        fadeScript.activar();
    }
}
