using UnityEngine;

public class ActivarPlataformas : MonoBehaviour
{
    [SerializeField] private GameObject instrucciones;
    [SerializeField] private PlayerMovement plataformas;
    [SerializeField] private AudioSource mPlataformas;
    private bool activo = false;
    void OnGUI()
    {
        Event e = Event.current;
        if (activo && e.isKey)
        {
            switch (e.keyCode)
            {
                case KeyCode.X:
                    //ahorcado.activo = ahorcado.iniciarJuego = ahorcado.juegoEnMarcha = true;
                    instrucciones?.SetActive(false);
                    plataformas.active = 1;
                    break;
                default:
                    break;
            }
        }
    }

    public void activarPlataformas()
    {
        GameObject.Find("Player").GetComponent<Movimiento>().JugadorActivo = false;
        this.transform.GetComponent<MoverCamaraAPC>().moverCamaraAPC();
        mPlataformas.Play();
        activo = true;
    }
}

