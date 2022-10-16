using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMenager : MonoBehaviour
{
    public GameObject pauseMenu, settingsMenu, startMenu, creditsMenu;
    private bool isPausedOpen, isSettingsOpen, isGameStarted, isCreditsOpen;

    public static GameMenager instance;

    private void Awake()
    {
        Time.timeScale = 0;
    }
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

    public void OpenCredits()
    {
        if (isCreditsOpen == false)
        {
            creditsMenu.SetActive(true);
            isCreditsOpen = true;
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
            creditsMenu.SetActive(false);
            isCreditsOpen = false;
        }
    }

    public void AudioToggle()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
