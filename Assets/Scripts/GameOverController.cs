using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    private const string highscoreKey = "highscore";
    [SerializeField]
    private CoinCollector coinCollector;
    [SerializeField]
    private Text currentScore, highscoreText;
    [SerializeField]
    private GameObject newHighscoreLabel;
    [SerializeField]
    private GameState gameState;

    private void Start()
    {
        gameState.GameLost += GameOver;
        gameObject.SetActive(false);
    }

    public void GameOver() 
    {
        int score = coinCollector.Coins;
        currentScore.text = "Your score: " + score.ToString();
        int highScore = PlayerPrefs.GetInt(highscoreKey, 0);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(highscoreKey, highScore);
            newHighscoreLabel.SetActive(true);
        }

        highscoreText.text = "Best: " + highScore.ToString();

        gameObject.SetActive(true);
    }
 
}
