using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    private void Start()
    {
        // Подписываемся на событие изменения значения слайдеров
        _musicSlider.onValueChanged.AddListener(MusicVolume);
        _sfxSlider.onValueChanged.AddListener(SFXVolume);
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume(float volume)
    {
        AudioManager.Instance.MusicVolume(volume);
    }

    public void SFXVolume(float volume)
    {
        AudioManager.Instance.SFXVolume(volume);
    }

    public void UpdateSliders(float musicVol, float sfxVol)
    {
        _musicSlider.value = musicVol;
        _sfxSlider.value = sfxVol;
    }
}
