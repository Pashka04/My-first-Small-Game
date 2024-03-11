using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    public void ToggleMusic()
    {
        MainMenuAudioManager.Instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        MainMenuAudioManager.Instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        MainMenuAudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        MainMenuAudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
}
