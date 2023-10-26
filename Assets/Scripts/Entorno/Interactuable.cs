using System;
using TMPro;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactuable : MonoBehaviour
{
    //Evento que indica que se quiere realizar la interacción
    [SerializeField] private UnityEvent Interaccion;

    //Indica si la interacción puede pasar solo una o varias veces
    [SerializeField] public bool Reutilizable = true;

    //Indica si la interacción puede pasar solo una o varias veces
    [SerializeField] public bool Activo = true;

    //Indica si la interacción tiene alguna informacion visual (texto, un reborde, que el objeto brille...)
    [FormerlySerializedAs("InformacionVisualBool")] [SerializeField]
    private bool InformacionVisual = true;

    //Indica el tiempo entre interacciones
    [SerializeField] private float TiempoDeReutilizacion = 1.0f;

    //Tiempo desde la última interacción
    private float CoolDown = 0.0f;

    //Material para resaltar el objeto cuando se pueda interactuar con el
    [SerializeField] private Material materialResaltar;

    //Texto que mostrara el objeto cuando se pueda interactuar con el
    [SerializeField] private String textoAMostrar;

    //Campo de texto donde se mostrara el texto del objeto
    private TextMeshProUGUI Text;

    //Mesh del objeto
    private MeshRenderer mesh;

    //Array de materiales originales del objeto
    private Material[] materialesOriginales;

    //Array con los materiales originales y los usados para resaltar el objeto
    private Material[] materialesResaltados;

    //Booleano que dicta si se esta mostrando la información visual
    private bool IVisual = false;

    //Booleano que dicta si el objeto tiene sus materiales originales
    private bool OGMaterial = true;

    void Start()
    {
        //Se asignan el campo de texto, el mesh del objeto y los materiales
        Text = GameObject.Find("TextoAcción").GetComponent<TextMeshProUGUI>();
        mesh = this.GetComponent<MeshRenderer>();
        materialesOriginales = mesh.materials;
        materialesResaltados = new Material[materialesOriginales.Length + 1];
        for (int i = 0; i < materialesOriginales.Length; i++)
            materialesResaltados[i] = materialesOriginales[i];
        materialesResaltados[materialesResaltados.Length - 1] = materialResaltar;
    }

    void Update()
    {
        if (Activo)
        {
            //Si la interacción puede hacerse más de una vez, el tiempo de reutilización decrece hasta ser <= 0
            if (Reutilizable && CoolDown > 0.0f)
            {
                CoolDown -= Time.deltaTime;
            }

            //Si el material del objeto no es el original y no se esta mostrando la información visual
            //restaura los materiales y el campo de texto
            if (!OGMaterial)
            {
                if (!IVisual)
                {
                    mesh.materials = materialesOriginales;
                    Text.text = "";
                    OGMaterial = true;
                }
                else
                {
                    IVisual = false;
                }
            }
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

    //Método que se invoca para aplicar cambios visuales cuando el foco esta sobre el objeto interactuable
    public void Visual()
    {
        //Si esta indicado que tiene información visual y el cooldown es menor o igual a cero
        //muestra dicha información visual
        if (InformacionVisual && CoolDown <= 0.0f)
        {
            Text.text = textoAMostrar;
            mesh.materials = materialesResaltados;
            IVisual = true;
            OGMaterial = false;
        }
    }
}