using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Source ----------")]
    public AudioClip mainMusic;
    public AudioClip music30s;
    public AudioClip mainMusicLoop;

    [Header("---------- SFX Source ----------")]
    public AudioClip characterDeathIn;
    public AudioClip characterDeathOut;
    public AudioClip enemyDeath;

    private void Awake()
    {
        //if (instanceObj == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void Start()
    {
        musicSource.clip = music30s;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
