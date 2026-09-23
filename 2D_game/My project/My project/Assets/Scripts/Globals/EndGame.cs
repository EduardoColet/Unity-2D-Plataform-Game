using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EndGame : MonoBehaviour
{
    public string level;
    public TextMeshProUGUI bestScoreText; 
    public TextMeshProUGUI currentScoreText; 
    public TextMeshProUGUI finalTimeText; 
    public TextMeshProUGUI bestTimeText; 

private void OnEnable()
{
    string difficulty = ChooseDifficulty.selectedDifficulty.ToString(); 

    string bestScoreKey = $"BestScore_{difficulty}";
    string bestTimeKey = $"BestTime_{difficulty}";

    int currentScore = ScoreManager.instance != null ? ScoreManager.instance.score : 0;
    float currentTime = TimerController.instance.elapsedTime;

    int bestScore = PlayerPrefs.GetInt(bestScoreKey, 0);
    float bestTime = PlayerPrefs.GetFloat(bestTimeKey, float.MaxValue);

    bool isNewRecord = false;
    if (currentScore > bestScore) 
    {
        isNewRecord = true;
    }
    else if (currentScore == bestScore && currentTime < bestTime)
    {
        isNewRecord = true;
    }

    if (isNewRecord)
    {
        PlayerPrefs.SetInt(bestScoreKey, currentScore);
        PlayerPrefs.SetFloat(bestTimeKey, currentTime);
        PlayerPrefs.Save();
    }

    if (bestScoreText != null)
    {
        bestScoreText.text = $"Best Score {difficulty}: {PlayerPrefs.GetInt(bestScoreKey)}";
    }

    if (bestTimeText != null)
    {
        TimeSpan bestTimeSpan = TimeSpan.FromSeconds(PlayerPrefs.GetFloat(bestTimeKey));
        bestTimeText.text = $"Best Time {difficulty}: {bestTimeSpan:mm':'ss'.'ff}";
    }

    if (currentScoreText != null)
    {
        currentScoreText.text = "Score: " + currentScore.ToString();
    }

    if (finalTimeText != null)
    {
        finalTimeText.text =  TimerController.instance.timeCounter.text;
    }
}


public void Restart()
{
    ScoreManager.instance?.ResetScore();

    GameObject player = GameObject.FindWithTag("Player");
    if (player != null)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.ResetLife();
        }
    }

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}


    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
