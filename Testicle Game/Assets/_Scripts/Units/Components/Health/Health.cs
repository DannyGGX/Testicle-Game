using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

[System.Serializable]
public class Health
{
    [SerializeField] private HealthBar ui; // prefab
    [SerializeField] private int maxHealth = 100;

    private int unitID;
    private int currentHealth;

    public void InitializeHealthBar(int unitID)
    {
        this.unitID = unitID;
        currentHealth = maxHealth;

        ui.InitializeHealthBar(maxHealth);
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

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        ui.UpdateUI(currentHealth);
    }

    public void HealToFull()
    {
        //Start coroutine in ui.
    }

    private void Die()
    {
        EventManager.OnUnitDie.Invoke(unitID);
    }

}
