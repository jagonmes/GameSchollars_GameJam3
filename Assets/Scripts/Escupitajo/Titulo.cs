using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titulo : MonoBehaviour
{
    public static bool intro = true;
    void Awake()
    {
        if (intro)
        {
            intro = false;
            SceneManager.LoadScene(11);
        }
    }

}
