using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerResolution : MonoBehaviour
{
    private int width = 1920;
    private int height = 1080;
    public Toggle fullscreenToggle;
    public Image checkmarkImage; // Галочка у Toggle

    void Start()
    {
        bool isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        Screen.SetResolution(width, height, isFullscreen);
        Screen.fullScreen = isFullscreen;

        if (fullscreenToggle != null)
        {
            fullscreenToggle.onValueChanged.RemoveListener(ToggleFullscreen);
            fullscreenToggle.isOn = isFullscreen;
            fullscreenToggle.onValueChanged.AddListener(ToggleFullscreen);
        }

        UpdateCheckmark();
    }

    public void ToggleFullscreen(bool isFullscreen)
    {

        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
        UpdateCheckmark();
    }

    private void UpdateCheckmark()
    {
        if (checkmarkImage != null)
        {
            // Здесь мы не скрываем чекмаркер, а меняем его альфа-канал
            Color targetColor = fullscreenToggle.isOn ? new Color(1f, 1f, 1f, 1f) : new Color(1f, 1f, 1f, 0.5f);
            checkmarkImage.color = targetColor;
        }
    }
}    
