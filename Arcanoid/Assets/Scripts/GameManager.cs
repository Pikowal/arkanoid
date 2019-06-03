using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text scoreText;
    public Text liveText;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        if (lives <= 0)
        {
            GameOver();
        }

        liveText.text = $"Lives: {lives}";
    }
   
    public void UpdateScores(int changeScore)
    {
        score += changeScore;
        scoreText.text = $"Score: {score}";
    }

    private void Init()
    {
        liveText.text = $"Lives: {lives}";
        scoreText.text = $"Score: {score}";
    }

    private void GameOver()
    {
        gameOver = true;
    }

}
