using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class Contestacion : MonoBehaviour
{
    [SerializeField] private AudioClip cAudio;
    [SerializeField] private TextAsset subtitulos;
    [SerializeField] private float volume = 0.2f;
    [SerializeField] private float spatialBlend = 1.0f;
    [SerializeField] private bool loop = false;
    [SerializeField] private ControladorPintadas pintadas;

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
        pintadas?.activaPintada(1);
        if (this.GetComponent<AudioSource>() == null)
        {
            this.AddComponent<AudioSource>();
        }
        aSource = this.GetComponent<AudioSource>();
        aSource.Stop();
        aSource.loop = loop;
        aSource.spatialBlend = spatialBlend;
        aSource.volume = volume;
        aSource.clip = cAudio;
        aSource.Play();
        if(subtitulos != null)
            ActivarSubtitulos = true;
    }
}