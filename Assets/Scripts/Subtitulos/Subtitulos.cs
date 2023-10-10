using System;
using TMPro;
using UnityEngine;

public class Subtitulos
{
    public float[] tiempos;
    public String[] frases;
    private int contador = 0;
    private float tiempo = 0.0f;

    public void CargarSubtitulos(TextAsset jsonFile)
    {
        Subtitulos sub = JsonUtility.FromJson<Subtitulos>(jsonFile.text);
        this.tiempos = sub.tiempos;
        this.frases = sub.frases;
    }

    public void GuardarSubtitulos(String filename, String d)
    {
        if (filename == "")
        {
            filename = d + "/subtitulos sin nombre.json";
        }

        filename = d + filename + ".json";
        try
        {
            System.IO.File.WriteAllText(filename, JsonUtility.ToJson(this));
        }
        catch
        {
        }
    }

    public bool imprimirPorPantalla(TextMeshProUGUI Text)
    {
        if (contador < this.tiempos.Length)
        {
            if (tiempo < this.tiempos[contador])
            {
                Text.text = this.frases[contador];
            }
            else
            {
                contador++;
            }
            tiempo += Time.deltaTime;
            if (this.tiempos[contador] == 0.0f)
            {
                this.reiniciarSubtitulos();
                return false;
            }
        }

        return true;
    }

    public void reiniciarSubtitulos()
    {
        this.contador = 0;
        this.tiempo = 0.0f;
    }
}