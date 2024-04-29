using UnityEngine;

public class Disparar : MonoBehaviour
{

    public static bool esconderInstrucciones = false;

    private void Start()
    {
        esconderInstrucciones = false;
    }

    public void intentarDisparar()
    {
        Movimiento_Mira.intentandoDisparar = true;
    }
    
    public void dejarDeIntentarDisparar()
    {
        Movimiento_Mira.intentandoDisparar = false;
    }
    
    public void EsconderInstrucciones()
    {
        esconderInstrucciones = true;
    }
}
