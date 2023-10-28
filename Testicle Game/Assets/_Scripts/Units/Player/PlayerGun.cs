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

    private CustomObjectPool<Projectile> playerBullets;
    

    private float nextFireTime = 0;
    private bool canFire = true;

    private void Awake()
    {
        playerBullets = new CustomObjectPool<Projectile>(playerBulletPrefab, transform, 15);
    }

    void Update()
    {
        if (CheckIfEnoughTimePassed() && Input.GetButton("Fire1"))
        {
            this.Log("Fire input");
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
        Projectile firedBullet = playerBullets.GetObject();
        firedBullet.Initialize(playerBullets, 5, TargetTypes.Enemy);
    }
}
