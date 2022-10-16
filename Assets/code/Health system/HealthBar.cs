using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public PlayerHealth phealth;
    public TextMeshProUGUI valueText;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        valueText.text = "Health: " + slider.value + " / " + (phealth.maxHealth);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        slider.value = Mathf.Round(slider.value);
        valueText.text = "Health: " + slider.value + " / " + (phealth.maxHealth);
    }

}
