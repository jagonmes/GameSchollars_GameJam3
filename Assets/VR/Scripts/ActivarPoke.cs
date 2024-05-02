using UnityEngine;
using UnityEngine.InputSystem;

public class ActivarPoke : MonoBehaviour
{
    [SerializeField] private InputActionReference _triggerI;
    [SerializeField] private InputActionReference _triggerD;
    [SerializeField] private GameObject PokeD;
    [SerializeField] private GameObject PokeI;

    private float _triggerValueI;
    private float _triggerValueD;

    private void Update()
    {
        Activar();
    }

    private void Activar()
    {
        _triggerValueI = _triggerI.action.ReadValue<float>();
        if (_triggerValueI >= 1.0f)
        {
            PokeI.SetActive(true);
        }
        else
        {
            PokeI.SetActive(false);
        }

        _triggerValueD = _triggerD.action.ReadValue<float>();
        if (_triggerValueD >= 1.0f)
        {
            PokeD.SetActive(true);
        }
        else
        {
            PokeD.SetActive(false);
        }
    }
}
