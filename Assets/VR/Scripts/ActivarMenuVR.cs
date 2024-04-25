using UnityEngine;
using UnityEngine.InputSystem;

public class ActivarMenuVR : MonoBehaviour
{
    
    [SerializeField] private InputActionReference activador;
    [SerializeField] private GameObject menu;
    [SerializeField] private MenuVR menuVR;
    [SerializeField] private Transform posicionMarcador;
    [SerializeField] private Transform posicionCamara;
    [SerializeField] private GameObject[] UIInteractors;
    public bool pausaPermitida = true;
    private bool activado = false;
    private float coolDown = 0.0f;
    private float InitialCooldown = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (coolDown <= 0.0f && pausaPermitida)
            comprobarActivacion();
        coolDown -= Time.deltaTime;
    }
    
    void comprobarActivacion()
    {
        bool valor = activador.action.ReadValue<float>() != 0.0f;
        if (!activado && valor)
        {
            mostrarMenu();
            coolDown = InitialCooldown;
        }else if (activado && valor)
        {
            ocultarMenu();
            coolDown = InitialCooldown;
        }
    }

    void mostrarMenu()
    {
        menu.SetActive(true);
        menu.transform.position = posicionMarcador.position;
        menu.transform.LookAt(posicionCamara);
        foreach (var interactor in UIInteractors)
        {
            interactor.SetActive(true);
        }
        activado = true;
    }

    void ocultarMenu()
    {
        menuVR.aplicarCambios();
        menu.SetActive(false);
        foreach (var interactor in UIInteractors)
        {
            interactor.SetActive(false);
        }
        activado = false;
    }
}
