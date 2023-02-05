using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        Paused,
        End
    }

    public GameState gameState;
    public List<Light2D> luces;
    [SerializeField] private GameObject fxVolume;

    [SerializeField]private float dayLightIntensity;
    [SerializeField]private float lightIntensityMin;
    private float maxLightIntensity = 1.0f;
    private float minLightIntensity = .3f;
    [SerializeField] private float lightIntensityRate = .1f;
    private PlayerMovement playerMovement;
    public Light2D dayLight;
    public float currentScore;
    [SerializeField] private TMP_Text scoreText;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
        gameState = GameState.Playing;
        StartCoroutine(GraduallyReduceIntensity());

    }
    
        
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.Playing:
            {
                scoreText.text = "Score: " + currentScore.ToString();
                break;
            }
            case GameState.Paused:
            {
                break;
            }
            case GameState.End:
            {
                EndGame();
                break;
            }            
        }
    }

    private void EndGame()
    {
        // Pause / Disable Movement
        //playerMovement.canMove = false;
        // Change Scene
        SceneManager.LoadScene("ScoreScene");
    }

    IEnumerator GraduallyReduceIntensity()
    {
        while (dayLight.intensity > 0)
        {
            float delta =  lightIntensityRate * Time.deltaTime;
            if (delta > dayLightIntensity)
            {
                dayLight.intensity -= dayLightIntensity - lightIntensityMin;
                break;
            }
            dayLightIntensity -= delta;
            dayLight.intensity = dayLightIntensity;

            // Prendo luces
            if (dayLightIntensity < .3f)
            {
                foreach (var luz in luces)
                {
                    luz.gameObject.SetActive(true);
                }
                fxVolume.SetActive(true);
            }
            
            // Endgame
            if (dayLightIntensity <= 0.001f)
            {
                gameState = GameState.End;
            }
            
            yield return null;
        }
    }

    public void UpdateScore(float amount)
    {
        currentScore += amount;
    }

}
