using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// There can be different health bar colours for friendly and enemy
[System.Serializable]
public class Health
{
    [SerializeField] private HealthBar ui; // prefab

    private int unitID;
    private int maxHealth;
    private int currentHealth;
    private Transform barDisplayPoint;

    public Health(int unitID, int maxHealth, Transform barDisplayPoint)
    {
        this.unitID = unitID;
        this.maxHealth = maxHealth;
        currentHealth = this.maxHealth;
        this.barDisplayPoint = barDisplayPoint;
    }

    private void InitializeHealthBar()
    {
        ui.InitializeHealthBar(maxHealth, barDisplayPoint);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        ui.UpdateUI(currentHealth);
    }

    private void Die()
    {
        // send death event to unit with their unit id so that they can do special things when they die
        
        // destroy this maybe
    }
}
