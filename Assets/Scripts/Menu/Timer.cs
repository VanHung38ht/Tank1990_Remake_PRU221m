using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    private int WaitSec;
    // private int WaitSecInt;//for text in game
    public Text text;
    public int Duration;
    public GameManagerScript managerScript;
    public Text ScoreText;
    public int Score;
    public Text ScoreTextFinal;
    public int ScoreFinal;
    public Text HighScoreText;
    public int HighScore;
    private void Start()
    {
        Being(Duration);
        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            HighScore = 0;
        }
    }
    void Update()
    {
        Score = TankController.Score.score;
        ScoreFinal = TankController.Score.score;
        ScoreText.text = Score.ToString();
        ScoreTextFinal.text = ScoreFinal.ToString() +" Points" ;
        HighScoreText.text = HighScore.ToString();
    }
    private void Being(int second)
    {
        WaitSec = second;
        StartCoroutine(Fix());
    }
    private IEnumerator Fix()
    {
        while (WaitSec > 0)
        {
            // WaitSec -= Time.fixedDeltaTime;
            // WaitSecInt = (int)WaitSec;
            text.text = $"{WaitSec / 60:00}:{WaitSec % 60:00}";
            WaitSec--;
            yield return new WaitForSeconds(1f);
        }

        OnEnd();
    }
    private void OnEnd()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 0f;

        if (Score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }

        managerScript.GameOver();
    }
}
