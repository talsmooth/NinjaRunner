using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UiManager : MonoBehaviour

{
    public static UiManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public GameObject gameOverScreen;
    public GameObject upgradeScreen;
    int score;
    

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        upgradeScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        scoreText.text = Player.Instance.playerScore.ToString();
        lifeText.text = Player.Instance.playerLife.ToString();

        Player.PlayerIsLeveledUp += LevelUp;
        Player.PlayerIsDead += GameOverScreen;
        Player.PlayerIsHit += TextReduceLife;
        Player.PlayerIsAddedScore += TextAddScore;
      
    }   

    void Update()
    {
        if (Input.anyKeyDown && gameOverScreen.activeSelf)
        {

            GameReset();

        }
    }

    public void TextAddScore()
    {

        
        scoreText.text = Player.Instance.playerScore.ToString();
     

    }

    public void TextReduceLife()
    {

        lifeText.text =  Player.Instance.playerLife.ToString();

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

    public void LevelUp()
    {
        upgradeScreen.SetActive(true);
        Time.timeScale = 0;

    }

    public void GameResume()
    {
        upgradeScreen.SetActive(false);
        Time.timeScale = 1;

    }

}
