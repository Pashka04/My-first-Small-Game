using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    //public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;

    Resolution[] resolutions;

    void Start()
    {
        //resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        //resolutionDropdown.AddOptions(options);
        //resolutionDropdown.RefreshShownValue();
        //LoadSettings(currentResolutionIndex);
    }

    //public void SetResolution(int resolutionIndex)
    //{
    //    Resolution resolution = resolutions[resolutionIndex];
    //    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    //}

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        //    PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        //}
        //    public void LoadSettings(int currentResolutionIndex)
        //    {
        //        if (PlayerPrefs.HasKey("QualitySettingPreference"))
        //            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        //        else
        //        {
        //            qualityDropdown.value = 3;
        //        }
        //        if (PlayerPrefs.HasKey("ResolutionPreference"))
        //            //resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        //        else
        //        {
        //            //resolutionDropdown.value = currentResolutionIndex;
        //        }
        //    }       



    }
}
    
