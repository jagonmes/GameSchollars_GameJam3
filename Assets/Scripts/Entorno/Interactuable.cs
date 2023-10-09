using TMPro;
using UnityEngine.Events;
using UnityEngine;

public class Interactuable : MonoBehaviour
{
    //Evento que indica que se quiere realizar la interacción
    [SerializeField] private UnityEvent Interaccion;
    
    [SerializeField] private UnityEvent InformacionVisual;

    //Indica si la interacción puede pasar solo una o varias veces
    [SerializeField] private bool Reutilizable = true;

    //Indica si la interacción tiene alguna informacion visual (texto, un reborde, que el objeto brille...)
    [SerializeField] private bool InformacionVisualBool = true;
    
    //Indica el tiempo entre interacciones
    [SerializeField] private float TiempoDeReutilizacion = 1.0f;

    //Tiempo desde la última interacción
    private float CoolDown = 0.0f;

    void Update()
    {
        //Si la interacción puede hacerse más de una vez, el tiempo de reutilización decrece hasta ser <= 0
        if (Reutilizable && CoolDown > 0.0f)
        {
            CoolDown -= Time.deltaTime;
        }
    }

    //Metodo que se invoca para intentar interactuar
    public void Interactuar()
    {
        //Si el tiempo desde la ultima interacción es menor o igual a 0, se ejecuta la interacción
        if (CoolDown <= 0.0f)
        {
            Interaccion?.Invoke();
            //Se actualiza el tiempo de reutilización
            CoolDown = TiempoDeReutilizacion;
        }
    }

    //Metodo que se invoca para aplicar cambios visuales cuando el foco esta sobre el objeto interactuable
    public void Visual()
    {
        if (InformacionVisualBool)
        {
            InformacionVisual.Invoke();
        }
    }
}