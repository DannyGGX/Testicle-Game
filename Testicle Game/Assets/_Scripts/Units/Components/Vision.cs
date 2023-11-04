using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Vision : MonoBehaviour
{
    private int unitID;
    [SerializeField] private TargetTypes opponent;
    [SerializeField] private Minion minion;
    [SerializeField] private Transform opponentBase;
    private Transform currentTarget; // equal to opponent base or opponent in vision

    private void Start()
    {
        if (opponentBase != null) // if minion is in scene and not spawned from spawner.
        {
            Initialize(opponentBase);
        }
    }

    public void Initialize(Transform opponentBase)
    {
        this.opponentBase = opponentBase;
        currentTarget = opponentBase;
        SetTargetToOpponentBase();
    }
    private void SetTargetToOpponentBase()
    {
        minion.SetAgentDestination(opponentBase.position);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (currentTarget != opponentBase) return;
        
        if (other.gameObject.CompareTag(opponent.ToString()))
        {
            currentTarget = other.GetComponent<Transform>();
            minion.SetAgentDestination(currentTarget.position);
        }
    }

    private void FixedUpdate()
    {
        if (currentTarget == opponentBase) return;
        
        minion.SetAgentDestination(currentTarget.position);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentTarget == opponentBase) return;
        
        if (other.gameObject.transform == currentTarget)
        {
            currentTarget = opponentBase;
            SetTargetToOpponentBase();
            this.Log("Set target to base");
        }
    }
}
