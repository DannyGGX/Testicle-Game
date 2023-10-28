using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class PlayerDeathTimeOutUI
{
    [SerializeField] private TextMeshProUGUI timeDisplay;

    public void UpdateTime(int seconds)
    {
        timeDisplay.text = FormatDisplay(seconds);
    }

    private string FormatDisplay(int seconds)
    {
        return $"{seconds} seconds till revive";
    }

    public void HideUI()
    {
        timeDisplay.enabled = false;
    }

    public void ShowUI()
    {
        timeDisplay.enabled = true;
    }
}