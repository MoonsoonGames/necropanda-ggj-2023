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

        foreach (var item in affectTargets)
        {
            if (item == null)
            {
                affectTargets.Remove(item);
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
                    health.Damage(plant.damage);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (affectTargets.Count >= plant.maxTargets) return;

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