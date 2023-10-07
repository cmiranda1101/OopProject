using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;

    public TextMeshProUGUI startGameText;
    public TextMeshProUGUI gameOverText;

    public Button restartButton;

    public GameObject player;
    public GameObject spawnManager;
    private PlayerController playerStats;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        player.SetActive(false);
        spawnManager.SetActive(false);
        startGameText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        playerStats = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive == false)
        {
            if(Input.anyKeyDown)
            {
                player.SetActive(true);
                StartGame();
            }
        }

        if (playerStats.Health <= 0)
        {
            GameOver();
        }
    }

    private void StartGame()
    {
        isGameActive = true;

        spawnManager.SetActive(true);
        startGameText.gameObject.SetActive(false);
    }

    private void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
