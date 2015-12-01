using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int lives;
    public Text livesText;
    public int score;
    public Text scoreText;


    void Start()
    {
        lives = 3;
        livesText.text = lives.ToString();
        score = 0;
        scoreText.text = score.ToString();

    }

    public void depleteLife()
    {
        lives--;
        livesText.text = lives.ToString();
    }

    public void incrementScore(int inc)
    {
        score += inc;
        scoreText.text = score.ToString();
    }
}