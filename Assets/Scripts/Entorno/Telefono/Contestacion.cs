using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class Contestacion : MonoBehaviour
{
    [SerializeField] private AudioClip cAudio;
    [SerializeField] private float volume;
    [SerializeField] private TextAsset subtitulos;
    
    private TextMeshProUGUI TextoSubtitulos;
    private bool ActivarSubtitulos = false;
    private Subtitulos sub = new Subtitulos();
    private AudioSource aSource;

    private void Start()
    {
        if(subtitulos != null)
            sub.CargarSubtitulos(subtitulos);
        TextoSubtitulos = GameObject.Find("TextoSubtitulos").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (ActivarSubtitulos)
        {
            ActivarSubtitulos = sub.imprimirPorPantalla(TextoSubtitulos);
        }
    }

    public void contestacion()
    { 
        if (this.GetComponent<AudioSource>() == null)
        {
            this.AddComponent<AudioSource>();
        }
        aSource = this.GetComponent<AudioSource>();
        aSource.Stop();
        aSource.loop = false;
        aSource.volume = volume;
        aSource.clip = cAudio;
        aSource.Play();
        if(subtitulos != null)
            ActivarSubtitulos = true;
    }
}