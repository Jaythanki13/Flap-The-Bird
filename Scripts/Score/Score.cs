using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public static Score instance;

    private const string BEST_SCORE = "bestScore";


    void Awake () {
        MakeSingleton();
        GameStartedFirstTime();
	}
	
	void Update () {
		
	}

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void GameStartedFirstTime()
    {
        if (!PlayerPrefs.HasKey("isGameStartedFirstTime"))
        {
            PlayerPrefs.SetInt(BEST_SCORE, 0);
            PlayerPrefs.SetInt("isGameStartedFirstTime", 0);
        }
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(BEST_SCORE, score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(BEST_SCORE);
    }
}
