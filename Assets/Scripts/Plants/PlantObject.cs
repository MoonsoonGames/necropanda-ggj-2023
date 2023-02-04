using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantObject : MonoBehaviour
{
    #region Setup

    bool active = false;
    Health health;
    BoxCollider boxCollider;
    SpriteRenderer spriteRenderer;
    float radius;
    Plant plant;

    public void Setup(Plant plant, GridSpace space)
    {
        //set up values
        this.plant = plant;

        name = plant.plantName;

        health = GetComponent<Health>();
        health.maxHealth = plant.health;
        health.ResetHealth();

        radius = plant.radius * space.size.x;

        boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(radius, 1, radius);

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = plant.sprite;

        InvokeRepeating("Tick", plant.tickTime, plant.tickTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(transform.position, new Vector3(radius, 1, radius));
    }

    #endregion

    List<GameObject> affectTargets = new List<GameObject>();
    public LayerMask plantLayer;
    public LayerMask enemyLayer;

    private void Tick()
    {
        if (affectTargets.Count <= 0) return;

        foreach(var item in affectTargets)
        {
            Health health = item.GetComponent<Health>();
            if (health != null)
            {
                if (item.gameObject.layer == plantLayer)
                {
                    health.Heal(plant.healing);
                }
                else if (item.gameObject.layer == enemyLayer)
                {
                    health.Damage(plant.damage);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == plantLayer || other.gameObject.layer == enemyLayer)
        {
            affectTargets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (affectTargets.Contains(other.gameObject))
        {
            affectTargets.Add(other.gameObject);
        }
    }
}