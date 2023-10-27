using UnityEngine;
using UnityEngine.SceneManagement;


public class CambioDeEscena : MonoBehaviour
{
    [SerializeField] private int indice = -1;
    [SerializeField] private float tiempo = 3.0f;

    public void cambiarDeEscena()
    {
        if(indice == -1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(indice);
    }

    public void invocarCambiarDeEscena()
    {
        Invoke("cambiarDeEscena", tiempo);
    }
}
