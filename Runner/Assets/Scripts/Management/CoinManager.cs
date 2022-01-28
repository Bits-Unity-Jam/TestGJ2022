using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    int coinCount;

    static CoinManager instance;
    public static CoinManager Instance { get => instance; }
    string key = "CoinValue";

    public event EventHandler<int> OnCoinChanged;

    public int CoinCount
    {
        get => coinCount; set
        {
            coinCount += value;
            PlayerPrefs.SetInt(key, coinCount);
            print(value);
            OnCoinChanged?.Invoke(this, coinCount);
        }
    }


    private void Awake()
    {
        coinCount = PlayerPrefs.GetInt(key, coinCount);
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
}
