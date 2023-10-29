
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Fade : MonoBehaviour
{
    
    [SerializeField] private Image panel;
    public bool fin = false;
    public bool fout = false;
    public float ratio = 3.0f;

    private Movimiento mJugador;

    private void Start()
    {
        if(GameObject.Find("Player"))
            mJugador = GameObject.Find("Player").GetComponent<Movimiento>();
    }

    void Update()
    {
        if (fin)
        {
            if (panel.color.a <= 1)
            {
                Color aux = panel.color;
                aux.a += ratio * Time.deltaTime;
                panel.color = aux;
                if (mJugador != null && mJugador.JugadorActivo)
                    mJugador.JugadorActivo = false;
            }
            else
            {
                fin = false;
            }
        }
        if (fout)
        {
            if (panel.color.a >= 0)
            {
                Color aux = panel.color;
                aux.a -= ratio * Time.deltaTime;
                panel.color = aux;
                if (mJugador != null && mJugador.JugadorActivo)
                    mJugador.JugadorActivo = false;
            }
            else
            {
                if (mJugador != null)
                    mJugador.JugadorActivo = true;
                fout = false;
            }
        }
    }

   public void activar()
    {
        Debug.Log("activando fade");
        if (panel.color.a < 1)
            fin = true;
        else
            fout = true;
    }
}
