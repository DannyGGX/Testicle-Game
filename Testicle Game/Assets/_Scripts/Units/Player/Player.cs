using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))] // For enemies to deal damage
public class Player : Unit, IFriendly
{
    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private PlayerGunRotation _playerGunRotation;
    [SerializeField] private PlayerGun _playerGun;
        
    private void OnEnable()
    {
        BaseOnEnable();
        
        EventManager.OnPlayerRevive.Subscribe(Revive);
    }
    private void OnDisable()
    {
        BaseOnDisable();
        EventManager.OnPlayerRevive.Unsubscribe(Revive);
    }

    private void Awake()
    {
        BaseAwake();
    }

    public override void Die(int unitID)
    {
        base.Die(unitID);
        
        if (CheckForIDMatch(unitID) == false)
            return;
        
        EventManager.OnPlayerDie.Invoke();
        DisableInput();
    }

    private void Revive()
    {
        EnableInput();
    }

    private void DisableInput()
    {
        _playerMovement.enabled = false;
        _playerGunRotation.enabled = false;
        _playerGun.enabled = false;
    }

    private void EnableInput()
    {
        _playerMovement.enabled = true;
        _playerGunRotation.enabled = true;
        _playerGun.enabled = true;
    }
}
