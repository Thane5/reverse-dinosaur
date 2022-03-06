using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] public GameObject winScreen;
    [SerializeField] public GameObject obstaclePanel;
    private bool isPlaying = false;
    public int aliveDinosaurs = 3;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (aliveDinosaurs <= 0)
            {
                PauseGame();
            }
            else
            {
                StopWatch();
            }
        }
    }

    void StopWatch()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("0000.0");
    }

    public void StartGame()
    {
        timer = 0;

        winScreen.SetActive(false);

        Time.timeScale = 1;
        isPlaying = true;
    }

    public void PauseGame()
    {
        if (isPlaying)
        {
            timerText.gameObject.SetActive(false);
            obstaclePanel.gameObject.SetActive(false);
            winScreen.SetActive(true);

            Time.timeScale = 0;
            isPlaying = false;
            scoreText.text = timer.ToString("0000.0");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}