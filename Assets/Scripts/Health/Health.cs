using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int maxHealth = 50;
    int currentHealth;

    private void Start()
    {
        ResetHealth();
    }

    [ContextMenu("Reset Health")]
    public void ResetHealth()
    {
        currentHealth = maxHealth;
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
    }

    public void Heal(int healing)
    {
        currentHealth = Mathf.Clamp(currentHealth + healing, 0, maxHealth);
        if (CheckKill())
        {
            Kill();
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
}
