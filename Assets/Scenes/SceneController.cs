using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
        DataContenier.checkpointIndex = 0;

    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadLevelByName(sceneName)); 

    }

    public void RestartLevel()
    {
        StartCoroutine(RestartScene());
    }


    IEnumerator RestartScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        transitionAnim.SetTrigger("Start");

    }

    IEnumerator LoadLevel()
    {
        GameManager.SaveHealth();
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");

    }

    IEnumerator  LoadLevelByName(string sceneName)
    {
        
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
        //GameManager.SaveHealth();
        transitionAnim.SetTrigger("Start");

    }
}
