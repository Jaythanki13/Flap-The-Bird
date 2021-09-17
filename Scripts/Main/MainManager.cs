using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

    public static MainManager instance;

    public Text highscore;


    void Awake() {
        Time.timeScale = 1f;

        if (instance == null) {
            instance = this;
        }
    }

    void Start () {
        highscore.text = "" + PlayerPrefs.GetInt("bestScore");
    }
	
	void Update () {
		
	}

    public void PlayGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
