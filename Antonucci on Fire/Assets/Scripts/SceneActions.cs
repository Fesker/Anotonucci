using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneActions : MonoBehaviour
{
    public string nextScene;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GoToNextScene()
    {
        if (IsValidScene(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    private bool IsValidScene(string sceneName)
    {
        return (sceneName != null && sceneName != "");
    }

}
