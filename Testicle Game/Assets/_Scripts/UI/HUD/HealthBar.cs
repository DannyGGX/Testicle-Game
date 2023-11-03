using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject wholeHealthBarUI;
    [SerializeField] private Slider slider;
    private int maxHealth;
    
    public void InitializeHealthBar(int maxHealth)
    {
        this.maxHealth = maxHealth;
        Hide();
    }
    
    public void UpdateUI(int currentHealth)
    {
        slider.value = (float)currentHealth / maxHealth;
        Show();
    }

    private void Show()
    {
        wholeHealthBarUI.SetActive(true);
    }

    private void Hide()
    {
        wholeHealthBarUI.SetActive(false);
    }
    
    
}
