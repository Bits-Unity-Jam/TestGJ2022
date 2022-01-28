using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int bestScore;
    string key = "BestScore";
    static ScoreManager instance;

    public int BestScore { get => bestScore; private set
        { 
            bestScore = value;
            PlayerPrefs.SetInt(key, bestScore);
        } 
    }

    public static ScoreManager Instance { get => instance; set => instance = value; }

    
    private void Awake()
    {
        BestScore = PlayerPrefs.GetInt(key);
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
       
    }
    
    public void CheckNewBestScore(int endGameScore)
    {
        
        if (endGameScore > BestScore)
        {
            
            BestScore = endGameScore;
            Debug.Log("Best score: " + BestScore);
        }

    } 
        public bool sNewScore(int endGameScore)
    {
        if (endGameScore > BestScore)
            return true;
        else
            return false;
    }
}
