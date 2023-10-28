using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLocation : MonoBehaviour, IInteractable
{
    private Tower currentTower;

    private void Awake()
    {
        currentTower = gameObject.AddComponent<NoTower>();
    }
}
