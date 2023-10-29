using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))] // For enemies to deal damage
public class Player : Unit, IFriendly
{
    private void OnEnable()
    {
        EventManager.OnPlayerRevive.Subscribe(Revive);
    }

    private void OnDisable()
    {
        EventManager.OnPlayerRevive.Unsubscribe(Revive);
    }

    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private PlayerGunRotation _playerGunRotation;
    [SerializeField] private PlayerGun _playerGun;
    
    

    public override void Die(int unitID)
    {
        base.Die(unitID);
        
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
