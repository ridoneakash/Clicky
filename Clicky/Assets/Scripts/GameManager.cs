using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float spwanTime = 1.0f;
    public List<GameObject> target;
    public GameObject pausescreen;
    private bool paused = true;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public int lives = 3;
    public Button restartButton;

    private int score = 0;
    public bool gameOver = false;

    public GameObject titleScreen;
    public GameObject volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore(0);
        if (Input.GetKeyDown(KeyCode.P))
        {
            CheckForPause();
        }
    }

    IEnumerator Spwan()
    {
        while (gameOver == false)
        {
            yield return new WaitForSeconds(spwanTime);
            int index = Random.Range(0, target.Count);
            Instantiate(target[index]);

        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
        restartButton.gameObject.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        spwanTime /= difficulty;
        StartCoroutine(Spwan());
        
    }

    void CheckForPause()
    {
        if (paused)
        {
            pausescreen.SetActive(true);
            Time.timeScale = 0;
            paused = false;
        }
        else
        {
            pausescreen.SetActive(false);
            Time.timeScale = 1;
            paused = true;
        }
    }
    public void UpdatesLives(int updateLives)
    {
        lives += updateLives;

        if (lives >= 0)
        {
            livesText.text = "Lives:" + lives;
        }

        if(lives <= 0)
        {
            GameOver();
        }
    }
}
