using UnityEngine;
using UnityEngine.Events;

public class Evento : MonoBehaviour
{
    //Indica si el evento saltara automaticamente pasado un tiempo
    [SerializeField] private bool Automatico = false;

    //Tiempo que indica cuando se ejecutara el evento, en caso de ser automático
    [SerializeField] private float Temporizador = 0.0f;

    //Indica si el evento saltara por un disparador
    [SerializeField] private bool Disparador = false;

    //Indica si el evento esta activo
    [SerializeField] public bool Activo;

    //Indica si el evento puede pasar solo una o varias veces
    [SerializeField] private bool Reutilizable = true;

    //Indica el tiempo entre eventos
    [SerializeField] private float TiempoDeReutilizacion = 1.0f;

    //Ejecuta la acción del evento
    [SerializeField] private UnityEvent Accion;

    //Tiempo desde el último evento
    private float CoolDown = 0.0f;

    void Update()
    {
        if (Activo)
        {
            if (Automatico)
            {
                if (Temporizador <= 0.0f && CoolDown <= 0.0f)
                {
                    Accion?.Invoke();
                    CoolDown = TiempoDeReutilizacion;
                }

                Temporizador -= Time.deltaTime;
            }
            if (Reutilizable && CoolDown <= 0.0f)
            {
                CoolDown -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Activo)
            if (Disparador && CoolDown <= 0.0f)
            {
                Accion?.Invoke();
                CoolDown = TiempoDeReutilizacion;
            }
    }
}