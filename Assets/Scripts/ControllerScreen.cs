using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerScreen : MonoBehaviour
{
    public Dropdown dropdown;

    public void DropD()
    {
        if (dropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        if (dropdown.value == 1)
        {
            Screen.SetResolution(1366, 768, true);
        }
        if (dropdown.value == 2)
        {
            Screen.SetResolution(1280, 720, true);
        }
    }
}
