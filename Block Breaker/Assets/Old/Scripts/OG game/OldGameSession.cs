using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OldGameSession : MonoBehaviour
{
    
    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 100;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // state variables
    [SerializeField] int currentScore = 0;
    
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<OldGameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }
    
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed; // When block is destroyed, add points to the current score.
        scoreText.text = currentScore.ToString();
    }
    
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
    
}
