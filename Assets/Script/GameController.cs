﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverText;
    public bool gameOver;
    public float scrollSpeed = -1.5f;

    private int score = 0;
    public Text scoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        if(GameController.instance == null)
        {
            GameController.instance = this;
        }else if(GameController.instance!=this)
        {
            Destroy(gameObject);
            Debug.LogWarning("algo anda mal");
        }
        
    }
    public void BirdScored()
    {
        if (gameOver) return;

        score++;
        scoreText.text = "Score: " + score;

        SoundSystem.instance.PlayCoin();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    public void BirdDie()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
    private void OnDestroy()
    {
        if(GameController.instance==this)
        {
            GameController.instance = null;
        }
    }
}
