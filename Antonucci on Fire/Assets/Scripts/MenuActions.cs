using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (playScene != null && playScene != "")
        {
            Application.LoadLevel(playScene);
        }
    }

    public void CreditsAction()
    {
        if (creditsScene != null && creditsScene != "")
        {
            Application.LoadLevel(creditsScene);
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

}
