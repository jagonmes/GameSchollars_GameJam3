using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //audioSource del juego
    [SerializeField] private AudioSource soundSource;

    //clips de sonido
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip Scream1Clip;
    [SerializeField] private AudioClip Scream2Clip;
    [SerializeField] private AudioClip monsterClip;
    [SerializeField] private AudioClip knifeClip;

    //metodos publicos para llamar a los sonidos
    public void coinSound()
    {
        soundSource.PlayOneShot(coinClip);
    }
    public void scream1Sound()
    {
        soundSource.PlayOneShot(Scream1Clip);
    }
    public void scream2Sound()
    {
        soundSource.PlayOneShot(Scream2Clip);
    }
    public void monsterSound()
    {
        soundSource.PlayOneShot(monsterClip);
        Invoke("stopMonsterSound",7f);
    }

    private void stopMonsterSound()
    {
        soundSource.Stop();
    }

    public void knifeSound()
    {
        soundSource.PlayOneShot(knifeClip);
    }
}
