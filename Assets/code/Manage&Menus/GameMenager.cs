using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    public GameObject pauseMenu, settingsMenu, startMenu;
    public bool isPausedOpen, isSettingsOpen, isGameStarted;

    public static GameMenager instance;

    public void StartGame()
    {
        if (isGameStarted == false)
        {
            isGameStarted = true;
            Time.timeScale = 1;
            startMenu.SetActive(false);
        }
    }

    public void QuitGame()
    {
        System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe"));
        Application.Quit();
    }

    public void PauseMenu()
    {
        if (isPausedOpen == false)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            isPausedOpen = true;
        }
    }
    public void SettingsMenu()
    {
        if (isSettingsOpen == false)
        {
            Time.timeScale = 0;
            settingsMenu.SetActive(true);
            isSettingsOpen = true;
        }
    }
    public void Resume()
    {
        if (isGameStarted == true)
        {
            Time.timeScale = 1;
            settingsMenu.SetActive(false);
            pauseMenu.SetActive(false);
            isPausedOpen = false;
            isSettingsOpen = false;
        }
        else
        {
            settingsMenu.SetActive(false);
            isSettingsOpen = false;
        }
    }
}