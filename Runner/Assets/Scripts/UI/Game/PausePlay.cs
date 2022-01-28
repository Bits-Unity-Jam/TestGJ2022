using Mechanics.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePlay : MonoBehaviour
{
    [SerializeField]
    GameObject congratulations;
    [SerializeField]
    GameObject pausePanel;
    [SerializeField]
    GameObject settingsPanel;
    [SerializeField]
    GameObject diePanel;
    [SerializeField]
    GameObject joystick;

    [SerializeField]


    public void CloseCongratulations()
    {
        congratulations.SetActive(false);
    }

    public void ReplayDieMenu()
    {
        SceneLoader.Instance.Replay();
        diePanel.SetActive(false);
        
    }

    public void Play()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        joystick.SetActive(true);
    }
    public void Settings()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
        
    }
    public void Replay()
    {
        Time.timeScale = 1;
        SceneLoader.Instance.Replay();
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
