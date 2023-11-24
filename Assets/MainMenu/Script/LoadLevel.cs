using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelScene;

     public void LoadScene()
    {
        SceneManager.LoadScene(levelScene);
    }
}
