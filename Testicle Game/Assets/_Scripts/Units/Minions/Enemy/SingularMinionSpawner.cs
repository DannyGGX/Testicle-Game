using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingularMinionSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField, Tooltip("An object to organise all pooled minions. It mustn't move, or all minions will move")]
    private Transform minionPoolParent;
    
    [SerializeField] private Minion minionPrefab;
    [Space] [SerializeField] private float startSpawnInterval = 2;
    [SerializeField] private float timeDecreasePerInterval = 0.05f;
    [SerializeField] private float minTimeInterval = 0.1f;

    [SerializeField] private Transform opponentBase;

    private float currentIntervalLength;
    private float currentTime = 0;

    private CustomObjectPool<Minion> minionPool;

    private void Awake()
    {
        currentIntervalLength = startSpawnInterval;
        minionPool = new CustomObjectPool<Minion>(minionPrefab, minionPoolParent, 10);
    }

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime > currentIntervalLength)
        {
            currentTime = 0;
            DecreaseTimeInterval();
            SpawnMinion();
        }
    }

    private void DecreaseTimeInterval()
    {
        currentIntervalLength -= timeDecreasePerInterval;
        if (currentIntervalLength < minTimeInterval)
        {
            currentIntervalLength = minTimeInterval;
        }
    }

    private void SpawnMinion()
    {
        Minion minion = minionPool.SpawnObject(spawnPoint.position, spawnPoint.rotation);
        minion.Initialize(minionPool, opponentBase);
    }
}
