using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    public static bool juegoPausado = false;
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            
            }
            
        }
    
    }

    public void Pausar()
    {
        Cursor.visible = true;
        juegoPausado = true;
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }
   
    public void Reanudar()
    {
        Cursor.visible = false;
        juegoPausado = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }
}
