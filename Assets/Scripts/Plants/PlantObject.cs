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
        int i = 0;

        foreach (var item in affectTargets)
        {
            if (i >= plant.maxTargets) return;

            if (item == null)
            {
                affectTargets.Remove(item);
                return;
            }
            else
            {
                i++;
            }

            Health health = item.GetComponent<Health>();
            if (health != null)
            {
                if ((plantLayer & (1 << item.gameObject.layer)) != 0)
                {
                    health.Heal(plant.healing);
                }
                else if ((enemyLayer & (1 << item.gameObject.layer)) != 0)
                {
                    Debug.Log(plant.plantName + " damaged " + item.name + " for " + plant.damage + " damage");
                    health.Damage(plant.damage);

                    Enemy enemy = item.GetComponent<Enemy>();
                    if (enemy != null && plant.confusion > 0)
                    {
                        enemy.Confuse(plant.confusion);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //https://forum.unity.com/threads/checking-if-a-layer-is-in-a-layer-mask.1190230/
        if ((plant.targetLayers & (1 << other.gameObject.layer)) != 0)
        {
            Debug.Log("Collided with + " + other.gameObject.name + " with layer " + other.gameObject.layer.ToString() + " || " + plantLayer.ToString());
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