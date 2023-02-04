using TMPro;
using UnityEngine;

public class ScoreSceneBehaviour : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    
    void Start()
    {
        scoreText.text = GameManager.Instance.CurrentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
