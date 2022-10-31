using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{
    public GameObject[] ui_Object = new GameObject[7];

    // [0] - pauseMenu || [1] - settingsMenu || [2] - startMenu || [3] - creditsMenu
    // [4] - toturialBox  || [5] - upgradeScreenCDtoClick || [6] - hiscoresScrene

    private bool isPausedOpen, isSettingsOpen, isGameStarted, isCreditsOpen, isHiscoresOpen, isGameFinished;
    public bool canStart, cameraShakeState, startPressed;

    public VolumeSlider slider;
    public TextMeshProUGUI screenShakeState, slimeLevel, timeSurvived;

    public PlayFabManager playfabManager;
    public GameObject loginAlert;
    public GameObject sendConfirmation;
    public PlayerHealth playerState;
    public Timer score;

    private void Awake()
    {
        Time.timeScale = 0;
        cameraShakeState = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameStarted == true)
            {
                if (isPausedOpen == true || isSettingsOpen == true)
                    Resume();
                else
                    PauseMenu();
            }
        }
    }

    public void SendScores()
    {
        sendConfirmation.SetActive(true);
        playfabManager.SendLeaderboard(score.currentTime);
    }

    public void ShowStats()
    {
        slimeLevel.text = "Slime Level: " + ExpSystem.instance.playerLevel.ToString();
        timeSurvived.text = "Time Survived: " + score.currentTime.ToString();
    }

    public void HideAlert()
    {
        loginAlert.SetActive(false);
    }

    public void PlayPressed()
    {
        if (canStart == true)
        {
            ui_Object[2].SetActive(false); 
        }
        else
        {
            loginAlert.SetActive(true);
            startPressed = true;
        }
    }

    public void StartGame()
    {
        if (isGameStarted == false)
        { 
            isGameStarted = true;
            Time.timeScale = 1;
            ui_Object[4].SetActive(false);
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
            ui_Object[0].SetActive(true);
            isPausedOpen = true;
        }
    }
    public void SettingsMenu()
    {
        if (isSettingsOpen == false)
        {
            Time.timeScale = 0;
            ui_Object[1].SetActive(true);
            isSettingsOpen = true;
        }
    }

    public void OpenCredits()
    {
        if (isCreditsOpen == false)
        {
            ui_Object[3].SetActive(true);
            isCreditsOpen = true;
        }
    }

    public void OpenHiscores()
    {
        if (isHiscoresOpen == false)
        {
            ui_Object[6].SetActive(true);
            isHiscoresOpen = true;
        }
    }

    public void Resume()
    {
        if (isGameStarted == true)
        {
            ui_Object[1].SetActive(false);
            ui_Object[0].SetActive(false);
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
            ui_Object[1].SetActive(false);
            isSettingsOpen = false;
            ui_Object[3].SetActive(false);
            isCreditsOpen = false;
            ui_Object[6].SetActive(false);
            isHiscoresOpen = false;
        }
    }

    public void CloseUpgradeCD()
    {
        ui_Object[5].SetActive(false);
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
        cameraShakeState = !cameraShakeState;
        if (cameraShakeState  == true)
        {
            screenShakeState.text = "On";
        }
        if (cameraShakeState == false)
        {
            screenShakeState.text = "Off";
        }
    }
}
