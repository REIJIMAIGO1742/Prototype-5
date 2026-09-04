using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using System;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;


public class GamemanagerB : MonoBehaviour
{
    public List<GameObject> target;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;

    public Button restartButton;

    public GameObject titleScreen;
    public GameObject valumScreen;

    public Canvas pauseScreen;

    private int score;
    public int live;

    private float spawnRate = 1.0f;

    public bool isGameActive;
    public bool gamePause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseScreen.gameObject.SetActive(false);
        gamePause = false;
    }

    public void StartGame(int diificulty)
    {
        spawnRate /= diificulty;
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        valumScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        live = 3;
        livesText.text = "Lives : " + live;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                ResumGame();
            }
            else
            {
                PauseGame();
            }
        } 
    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,target.Count);
            Instantiate(target[index]);
        
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    public void UpdateLive(int takeDamage)
    {
            live -= takeDamage;
            livesText.text = "Lives : " + live; 
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    private void ResumGame()
    {
        pauseScreen.gameObject.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
    }
    private void PauseGame()
    {
        pauseScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
