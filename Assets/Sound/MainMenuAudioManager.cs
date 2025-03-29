using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenuAudioManager : MonoBehaviour
{
    public static MainMenuAudioManager Instance;


    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        // Устанавливаем громкость на 10% (0.1f)
        musicSource.volume = 0.1f;
        sfxSource.volume = 0.1f;
        PlayMusic("THEME");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp(volume, 0f, 1f);
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp(volume, 0f, 1f);
    }

}