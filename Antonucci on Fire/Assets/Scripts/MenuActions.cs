using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public string playScene;
    public string creditsScene;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayAction()
    {
        if (IsValidScene(playScene))
        {
            SceneManager.LoadScene(playScene);
        }
    }

    public void CreditsAction()
    {
        if (IsValidScene(creditsScene))
        {
            SceneManager.LoadScene(creditsScene);
        }
    }

    public void ExitAction()
    {
        Quit();
    }

    private void Quit()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    private bool IsValidScene(string sceneName)
    {
        return (sceneName != null && sceneName != "");
    }

}
