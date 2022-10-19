using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{
    public GameObject pauseMenu, settingsMenu, startMenu, creditsMenu, toturialBox, upgradeCD;
    private bool isPausedOpen, isSettingsOpen, isGameStarted, isCreditsOpen;
    public VolumeSlider slider;
    public TextMeshProUGUI screenShakeState;

    public static GameMenager instance;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void PlayPressed()
    {
        startMenu.SetActive(false);
    }

    public void StartGame()
    {
        if (isGameStarted == false)
        { 
            isGameStarted = true;
            Time.timeScale = 1;
            toturialBox.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            settingsMenu.SetActive(false);
            pauseMenu.SetActive(false);
            isPausedOpen = false;
            isSettingsOpen = false;

            if (ExpSystem.instance.isLevelUpPanelOpen == true)
            {
                Time.timeScale = 0;
            } else {
                Time.timeScale = 1;
            }
        }
        else
        {
            settingsMenu.SetActive(false);
            isSettingsOpen = false;
            creditsMenu.SetActive(false);
            isCreditsOpen = false;
        }
    }

    public void CloseUpgradeCD()
    {
        upgradeCD.SetActive(false);
    }

    public void AudioToggle()
    {
        AudioListener.pause = !AudioListener.pause;

        if (AudioListener.pause == true)
        {
            slider.volumeSlider.value = 0;
        }
        if (AudioListener.pause == false)
        {
            slider.volumeSlider.value = 1;
        }
        
    }

    public void ScreenShakeToggle()
    {
        GameObject.Find("Main Camera").GetComponent<ShakeCameraControll>().enabled = !GameObject.Find("Main Camera").GetComponent<ShakeCameraControll>().enabled;

        if (GameObject.Find("Main Camera").GetComponent<ShakeCameraControll>().enabled == true)
        {
            screenShakeState.text = "On";
        }
        if (GameObject.Find("Main Camera").GetComponent<ShakeCameraControll>().enabled == false)
        {
            screenShakeState.text = "Off";
        }
    }
}
