using System;
using UnityEditor;
using UnityEngine;

public class UtilidadesSubtitulos : MonoBehaviour
{
    public Subtitulos CargarSubtitulos(TextAsset jsonFile)
    {
        Subtitulos sub = JsonUtility.FromJson<Subtitulos>(jsonFile.text);
        return sub;
    }

    public void GuardarSubtitulos(Subtitulos sub, String filename)
    {
        string d = AssetDatabase.GetAssetPath(this);
        if (filename == "")
        {
            filename = d + "/subtitulos sin nombre.txt";
        }
        filename = d + filename + ".txt";
        try
        {
            System.IO.File.AppendAllText(filename, JsonUtility.ToJson(sub));
        }
        catch
        {
        }
    }

    public void imprimirPorPantalla()
    {
        
    }
}