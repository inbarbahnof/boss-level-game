using System;
using System.Collections;
using System.Collections.Generic;
using Characters.Enemies;
using Characters.Player;
using Loaders;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private SunSpawner _sunSpawner;

    private PlayerController _playerController;
    private Boss _boss;
    
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy any duplicate instances
        }

        
        gameOverCanvas.SetActive(false);
    }

    public void Init(PlayerController player, Boss boss)    
    {
        _playerController = player;
        _boss = boss;
    }

    public void GameOver()
    {
        _sunSpawner.StopSpawn();
        _playerController.GameOver();
        _boss.GameOver();
        gameOverCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        gameOverCanvas.SetActive(false);
        _playerController.Restart();
        _boss.Restart();
        _sunSpawner.RestartSpawn();
    }
}
