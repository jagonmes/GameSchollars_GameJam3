using UnityEngine;

public class DespausarEscupitajo : MonoBehaviour
{
    void Start()
    {
        Pausa.juegoPausado = false;
        Time.timeScale = 1f;
    }

}
