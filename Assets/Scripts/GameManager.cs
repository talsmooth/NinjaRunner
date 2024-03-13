using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Player player;
    public Enemy enemy;
    public UiManager uiManager;
    void Start()
    {
        
    // Player Attack

        Player.PlayerIsAttacking += player.Attack;
    

    // Player Frenzy
     

        Player.PlayerIsInFrenzy += player.Frenzy;


    // Player Death

        Player.PlayerIsDead += uiManager.GameOverScreen;


    // Player Upgrade

        Player.PlayerIsLeveledUp += uiManager.LevelUp;




        


    }

    void Update()
    {
        
    }
}
