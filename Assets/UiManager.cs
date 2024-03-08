using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour

{
    public static UiManager Instance;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    int score;
    

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameOverScreen.SetActive(false);
        scoreText.text = score.ToString();

        Player.PlayerIsDead += GameOverScreen;
     
        Enemy.EnemyIsDead += AddScore;
    }   

    void Update()
    {
        if (Input.anyKeyDown && gameOverScreen.activeSelf)
        {

            GameReset();

        }
    }

    public void AddScore()
    {

        score++;
        scoreText.text = score.ToString();
     

    }

    public void GameOverScreen()
    {
        Debug.Log("Dead");
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;

    }

    public void GameReset()
    {
            Player.PlayerIsDead -= GameOverScreen;
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);


    }




}
