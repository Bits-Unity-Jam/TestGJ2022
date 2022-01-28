using Mechanics.Management;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField]
    GameObject shopPanel;

    [SerializeField]
    TextMeshProUGUI coinsCount;

    [SerializeField]
    TextMeshProUGUI shopCoinsCount;

    [SerializeField]
    GameObject panel;

    [SerializeField]
    GameObject settingsPanel;

    private const int SceneBuildIndex = 1;
    private int cC = 0;

    private int ccc;
    // Start is called before the first frame update
    private void Start()
    {
        CoinManager.Instance.OnCoinChanged += Instance_OnCoinChanged;

        ccc = CoinManager.Instance.CoinCount;

        coinsCount.text = $"Coins: " + ccc;
        shopCoinsCount.text = $"Coins: " + ccc;
    }
    private void Update()
    {
        coinsCount.text = $"Coins: " + ccc;
        shopCoinsCount.text = $"Coins: " + ccc;
    }
    private void UpdateCoins()
    {
        ccc = CoinManager.Instance.CoinCount;
    }

    private void Instance_OnCoinChanged(object sender, int e)
    {
        UpdateCoins();
    }

    public void _PlayGame()
    {

        SceneManager.LoadScene(SceneBuildIndex);
        Time.timeScale = 1;
    }
    public void ExitName()
    {
        Application.Quit();
    }
    public void Settings()
    {
        panel.SetActive(false);
        settingsPanel.SetActive(true);

    }
    public void Back()
    {
        settingsPanel.SetActive(false);
        panel.SetActive(true);
    }

    public void OpenShop()
    {
        panel.SetActive(false);
        shopPanel.SetActive(true);
    }
    
    
}
