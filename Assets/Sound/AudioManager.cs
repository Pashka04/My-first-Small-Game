using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadAudioSettings();
        PlayMusic("THEME");

    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
            return;
        }
        musicSource.clip = s.clip;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
            return;
        }
        sfxSource.PlayOneShot(s.clip);
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        PlayerPrefs.SetInt("MusicMuted", musicSource.mute ? 1 : 0);
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        PlayerPrefs.SetInt("SFXMuted", sfxSource.mute ? 1 : 0);
        PlayerPrefs.Save(); // Сохраняем изменения
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume; // Устанавливаем громкость напрямую
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume; // Устанавливаем громкость напрямую
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadAudioSettings()
    {
        musicSource.mute = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        sfxSource.mute = PlayerPrefs.GetInt("SFXMuted", 0) == 1;

        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 1.0f);

        musicSource.volume = musicVol;
        sfxSource.volume = sfxVol;

        // Если UIController подключен, обновляем слайдеры
        UIController ui = FindObjectOfType<UIController>();
        if (ui != null)
        {
            ui.UpdateSliders(musicVol, sfxVol);
        }
    }


    private IEnumerator FadeVolume(AudioSource source, float targetVolume)
    {
        if (Mathf.Approximately(source.volume, targetVolume)) yield break;

        float startVolume = source.volume;
        float duration = 0.5f;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }
        source.volume = targetVolume;
    }
}
