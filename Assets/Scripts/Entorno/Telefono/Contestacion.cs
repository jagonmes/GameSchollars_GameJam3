using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


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
        sub.CargarSubtitulos(subtitulos);
        TextoSubtitulos = GameObject.Find("TextoSubtitulos").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (ActivarSubtitulos)
        {
            sub.imprimirPorPantalla(TextoSubtitulos);
        }
    }

    public void Rick()
    { 
        aSource = this.GetComponent<AudioSource>();
        aSource.Stop();
        aSource.loop = false;
        aSource.volume = volume;
        aSource.clip = cAudio;
        aSource.Play();
        ActivarSubtitulos = true;
    }
}