using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    
    public void InitializeHealthBar(int maxHealth, Transform barPosition)
    {
        transform.position = barPosition.position;
    }
    
    public void UpdateUI(int currentHealth)
    {
        
    }
}
