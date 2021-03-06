﻿using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UILivesCounter : MonoBehaviour
{
    public int lives = 3;

    public int maxNumberOfHeartsInUI = 3;

    public int maxNumberOfLives = 10;

    private GameObject[] hearts;

    public GameObject gameOverScreen;

    private Text heartsText;

    // Start is called before the first frame update
    void Start()
    {
        // Initialise the array of hearts
        hearts = new GameObject[maxNumberOfHeartsInUI];

        heartsText = transform.GetComponentInChildren<Text>();
        heartsText.gameObject.SetActive(false);

        // Cycle among children and get the hearts we need
        for (int i = 0; i < maxNumberOfHeartsInUI; i++)
        {
            hearts[i] = transform.GetChild(i).gameObject;
        }
    }

    public void AddLife()
    {
        if (lives < maxNumberOfLives)
        {
            lives++;
        }

        UpdateGrafics();
    }

    public void RemoveLife()
    {
        lives--;
        if (lives <= 0)
        {
            // TODO: Game Over Screen
            if (gameOverScreen)
            {
                Time.timeScale = 0;        
                foreach (var item in FindObjectsOfType<AudioSource>().Where(aus => aus.isPlaying && aus.name == "Music"))
                {
                    item.Pause();
                }
                gameOverScreen.SetActive(true);
            }
        }

        UpdateGrafics();
    }

    public void UpdateGrafics()
    {
        for (int i = 0; i < maxNumberOfHeartsInUI; i++)
        {
            hearts[i].SetActive(i < lives);
        }

        if (lives > maxNumberOfHeartsInUI)
        {
            for (int i = 1; i < maxNumberOfHeartsInUI; i++)
            {
                hearts[i].SetActive(false);
            }
            heartsText.text = lives.ToString();
            heartsText.gameObject.SetActive(true);
        }
        else
        {
            heartsText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
