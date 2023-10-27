using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    public void InitializeHealthBar(int maxHealth, Transform barPosition)
    {
        transform.position = barPosition.position;
    }
    
    public void UpdateUI(int currentHealth)
    {
        
    }
}
