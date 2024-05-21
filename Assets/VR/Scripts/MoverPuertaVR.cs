using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MoverPuertaVR : MonoBehaviour
{
    private Transform mano;
    [SerializeField]private Transform manilla;
    private bool agarrado = false;
    [SerializeField]private Transform limiteIzquierda;
    [SerializeField]private Transform limiteDerecha;
    [SerializeField] private Interactuable _interactuable;
    [SerializeField] private bool puertab = false;
    
    

    // Update is called once per frame
    void Update()
    {
        if (agarrado)
        {
            if (puertab)
            {
                Vector3 nuevaPosicion = manilla.position;
                float nuevaZ = 0.0f;
                nuevaZ = mano.position.z;
                if (nuevaZ < limiteIzquierda.position.z)
                    nuevaZ = limiteIzquierda.position.z;
                if (nuevaZ > limiteDerecha.position.z)
                    nuevaZ = limiteDerecha.position.z;
                nuevaPosicion.z = nuevaZ;
                manilla.position = nuevaPosicion;
            }
            else
            {
                Vector3 nuevaPosicion = manilla.position;
                float nuevaX = 0.0f;
                nuevaX = mano.position.x;
                if (nuevaX < limiteIzquierda.position.x)
                    nuevaX = limiteIzquierda.position.x;
                if (nuevaX > limiteDerecha.position.x)
                    nuevaX = limiteDerecha.position.x;
                nuevaPosicion.x = nuevaX;
                manilla.position = nuevaPosicion;
            }
        }
    }
    
    public void PuertaAgarrada(SelectEnterEventArgs args)
    {
        if (!args.interactorObject.ToString().Contains("RayInteractor"))
        {
            mano = args.interactorObject.transform;
            agarrado = true;
            _interactuable.Activo = false;
        }

        if (args.interactorObject.ToString().Contains("RayInteractor"))
        {
            _interactuable.Interactuar();
        }


    }
    
    public void PuertaAgarrada(SelectExitEventArgs args)
    {
        if (!args.interactorObject.ToString().Contains("RayInteractor"))
        {
            mano = null;
            agarrado = false;
            _interactuable.Activo = true;
        }
    }
}
