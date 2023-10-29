using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverATitulo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("volver", 6);
    }

    private void volver()
    {
        SceneManager.LoadScene(0);
    }
}
