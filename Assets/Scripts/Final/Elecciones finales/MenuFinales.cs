using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFinales : MonoBehaviour
{
    [SerializeField] private GameObject menuFinales;
    [SerializeField] private GameObject EF;
    [SerializeField] private GameObject boton;
    public static bool enMenuFinal = false;
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pausa.juegoPausado && enMenuFinal)
            {
                Reanudar();
            }
        }
    
    }

    public void activarMenuFinales()
    {
        Cursor.visible = true;
        Pausa.juegoPausado = true;
        enMenuFinal = true;
        menuFinales.SetActive(true);
        EF.SetActive(true);
        boton.SetActive(true);
        Time.timeScale = 0f;
    }
   
    public void Reanudar()
    {
        Cursor.visible = false;
        Pausa.juegoPausado = false;
        enMenuFinal = false;
        Time.timeScale = 1f;
        menuFinales.SetActive(false);
        EF.SetActive(false);
        boton.SetActive(false);
    }
}
