using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.PlayerLoop;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public List<GameObject> target;
    public TextMeshProUGUI scoreText;

    private int score;

    private float spawnRate = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (true)
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
}
