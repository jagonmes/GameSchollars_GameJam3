using TMPro;
using UnityEngine;

public class Dia3Fade : MonoBehaviour
{
    [SerializeField] ControladorPintadas controladorPintadasScript;
    [SerializeField] GameObject puntoDepertar;
    private GameObject player;
    [SerializeField] private Fade fade;
    [SerializeField] private GameObject texto1;
    private TextMeshProUGUI texto1Text;

    private static bool yaActicado = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        texto1 = GameObject.Find("TextoAcción");
        texto1Text = texto1.GetComponent<TextMeshProUGUI>();
        yaActicado = false;
    }
    public void fadeMaquina()
    {
        if (!yaActicado)
        {
            GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = false;
            fade.active = true;
            controladorPintadasScript.activaPintada(5);
            texto1Text.text = "";
            Invoke("Teleportacion", 3f);
            Invoke("fadeVuelta", 5f);
            Invoke("DevolverControl", 6f);
            yaActicado = true;
        }
    }

    private void Teleportacion()
    {
        player.transform.position = puntoDepertar.transform.position;
    }

    private void fadeVuelta()
    {
        fade.activar();
    }
    private void DevolverControl()
    {
        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = true;
    }
    
}
