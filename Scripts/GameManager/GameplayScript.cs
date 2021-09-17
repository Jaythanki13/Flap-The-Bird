using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayScript : MonoBehaviour {

    public static GameplayScript instance;

    public GameObject panel;
    public Button pauseButton;
    public Text pauseText, gameOverText, highScore;

    public AudioSource audioSource;

	void Start () {
        Time.timeScale = 1f;
        if (instance == null) {
            instance = this;
        }
	}
	
	void Update () {
		
	}

    public void PauseGame() {
        audioSource.Pause();
        Time.timeScale = 0f;
        pauseText.gameObject.SetActive(true);
        panel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        highScore.text = "" + Score.instance.GetHighScore();
    }

    public void ResumeGame() {
        audioSource.Play();
        Time.timeScale = 1f;
        pauseText.gameObject.SetActive(false);
        panel.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main");
    }

    public void GameOver() {
        audioSource.Stop();
        gameOverText.gameObject.SetActive(true);
        panel.SetActive(true);
        highScore.text = "" + Score.instance.GetHighScore();
    }

    public void IfGameIsOver(int score) {        

        if (score > Score.instance.GetHighScore() ) {
            Score.instance.SetHighScore(score);
        }

    }
}
