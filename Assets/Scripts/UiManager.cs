using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UiManager : MonoBehaviour

{
    public static UiManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public GameObject gameOverScreen;
    public GameObject upgradeScreen;
    public Slider frenzySilder;
    int score;
    

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        upgradeScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        TextAddScore();
        TextReduceLife();
        FrenzySlider();

    }   

    void Update()
    {

        TextAddScore();
        TextReduceLife();
        FrenzySlider();

        if (Input.anyKeyDown && gameOverScreen.activeSelf)
        {

            GameReset();

        }
    }

    public void TextAddScore()
    {

        
        scoreText.text = Player.Instance.playerKills.ToString();
     

    }

    public void TextReduceLife()
    {

        lifeText.text =  Player.Instance.playerLife.ToString();

    }

    public void FrenzySlider()
    {

        frenzySilder.value = Player.Instance.playerKills;

    }

    public void GameOverScreen()
    {
        
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;

    }

    public void GameReset()
    {
        Player.PlayerIsLeveledUp -= LevelUp;
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
