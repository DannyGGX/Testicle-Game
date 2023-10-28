using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathTimeOut : MonoBehaviour
{
    [SerializeField] private PlayerDeathTimeOutUI ui;
    [SerializeField] private int timeOutSeconds = 10;
    
    private void OnEnable()
    {
        EventManager.OnPlayerDie.Subscribe(PlayerDie);
    }

    private void OnDisable()
    {
        EventManager.OnPlayerDie.Unsubscribe(PlayerDie);
    }

    private void PlayerDie()
    {
        StartCoroutine(CountDownTimeOut());
    }

    private IEnumerator CountDownTimeOut()
    {
        var secondWait = new WaitForSeconds(1);
        ui.ShowUI();

        for (int currentSecond = timeOutSeconds; currentSecond > timeOutSeconds; currentSecond--)
        {
            ui.UpdateTime(currentSecond);
            yield return secondWait;
        }
        
        ui.HideUI();
        EventManager.OnPlayerRevive.Invoke();
    }
}