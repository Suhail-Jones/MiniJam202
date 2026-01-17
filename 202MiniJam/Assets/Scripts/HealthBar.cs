using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float Health, MaxHealth, Width, Height;

    [SerializeField]
    private RectTransform healthBar;

    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        if (health < 0 || health > MaxHealth)
        {
            return;
        }
        
        Health = health;
        float newWidth = (Health / MaxHealth) * Width;

        healthBar.sizeDelta = new Vector2(newWidth, Height);
    }

    public void Update()
    {
        SetHealth(Width);
    }
}
