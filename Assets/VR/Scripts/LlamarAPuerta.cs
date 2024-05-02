using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class LlamarAPuerta : MonoBehaviour
{
    private int contador;
    
    [SerializeField] public UnityEvent Interaccion;
    [SerializeField] public AudioSource Knock;
    [SerializeField]private XRPokeInteractor interactorI;
    [SerializeField]private XRPokeInteractor interactorD;
    [SerializeField] private XRBaseControllerInteractor[] I;
    [SerializeField] private XRBaseControllerInteractor[] D;

    public bool activo = true;

    private void Update()
    {
        if (activo && contador >= 3)
        {
            Interaccion?.Invoke();
            activo = false;
        }
    }


    public void Llamar(HoverEnterEventArgs args)
    {
        contador++;
        Knock.Play();
        if(args.interactorObject == interactorI)
            foreach (var interactor in I)
            {
                if(interactor.isActiveAndEnabled)
                    interactor.SendHapticImpulse(1f, 0.1f);
            }
        if(args.interactorObject == interactorD)
            foreach (var interactor in D)
            {
                if(interactor.isActiveAndEnabled)
                    interactor.SendHapticImpulse(1f, 0.1f);
            }
    }
}
