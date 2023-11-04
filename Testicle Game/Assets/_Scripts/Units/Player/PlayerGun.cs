using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField, Tooltip("Bullets per second")] private float fireRate;

    [SerializeField] private Projectile playerBulletPrefab;
    [SerializeField, Tooltip("To organise bullet clones")] private Transform playerBulletPool;

    private CustomObjectPool<Projectile> playerBullets;
    

    private float nextFireTime = 0;
    private bool canFire = true;

    private void Awake()
    {
        playerBullets = new CustomObjectPool<Projectile>(playerBulletPrefab, playerBulletPool, 10, true);
    }

    void Update()
    {
        if (CheckIfEnoughTimePassed() && Input.GetButton("Fire1"))
        {
            Shoot();
            SetNextFireTime();
        }

        // if (Input.GetButtonDown("Fire1"))
        // {
        //     this.Log("Fire input");
        //     Shoot();
        // }
    }

    private bool CheckIfEnoughTimePassed()
    {
        return Time.time >= nextFireTime;
    }
    private void SetNextFireTime()
    {
        nextFireTime = Time.time + 1 / fireRate;
    }

    private void Shoot()
    {
        Projectile firedBullet = playerBullets.SpawnObject();
        firedBullet.Initialize(playerBullets, firePoint, 15, TargetTypes.Enemy);
    }
}
