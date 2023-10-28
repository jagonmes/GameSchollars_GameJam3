using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public int TargetScene = 0;

    public void changeScene()
    {
        Debug.Log("AA");
        if(TargetScene == -1)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(TargetScene);
        }

    }
}
