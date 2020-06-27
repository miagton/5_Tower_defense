using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] Text highScore;
    Text text;
    int highscore = 0;
    int Score = 0;
    void Start()
    {
       // PlayerPrefs.DeleteKey("Highscore");
        highscore = PlayerPrefs.GetInt("Highscore");
        text = GetComponent<Text>();
       // IncreaseScore(0);
    }
    private void Update()
    {
        SetHighScore();
    }
    public void IncreaseScore(int amount)
    {
        Score += amount;
        text.text = "Score: " + Score;
    }
    public int GetScore()//for game manager to improve logic
    {
        return Score;
    }

    void SetHighScore()
    {
        if (Score > highscore)
        {
            highscore = Score;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
        highScore.text = "Highscore: " + highscore;
    }
}
