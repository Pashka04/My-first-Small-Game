using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Dropdown qualityDropdown;

    void Start()
    {
        LoadSettings();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.Save(); // ����������� ��������� ���������
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
        {
            int savedQuality = PlayerPrefs.GetInt("QualitySettingPreference");
            qualityDropdown.value = savedQuality;
            QualitySettings.SetQualityLevel(savedQuality);
        }
        else
        {
            qualityDropdown.value = 3; // �������� �� ���������
            QualitySettings.SetQualityLevel(3);
        }
    }
}
