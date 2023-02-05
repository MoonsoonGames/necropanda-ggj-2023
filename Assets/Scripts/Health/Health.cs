using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    public int maxHealth = 50;
    int currentHealth;
    Slider slider; 

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        ResetHealth();
    }

    [ContextMenu("Reset Health")]
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        AdjustSlider();
    }

    [ContextMenu("Damage(10)")]
    public void ForceDamage()
    {
        Damage(10);
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        if (CheckKill())
        {
            Kill();
        }
        else
        {
            AdjustSlider();
        }
    }

    public void Heal(int healing)
    {
        currentHealth = Mathf.Clamp(currentHealth + healing, 0, maxHealth);
        if (CheckKill())
        {
            Kill();
        }
        else
        {
            AdjustSlider();
        }
    }

    public bool CheckKill()
    {
        return currentHealth <= 0;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void AdjustSlider()
    {
        if (slider == null) return;

        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }
}
