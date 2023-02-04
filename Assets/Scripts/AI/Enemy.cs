using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : NPC
{
    public int damageAmount;

    private void Start()
    {
        base.SetupAI();
    }

    private void Update()
    {
        FSM();
    }

    public void FSM()
    {
        switch (base.currentState)
        {
            case AIState.Nothing:
                SetAIState(AIState.Targetting);
                break;

            case AIState.Targetting:
                Debug.Log(GetClosestTarget());
                base.SetDestination(GetClosestTarget());
                if (base.agent.remainingDistance < 5)
                {
                    SetAIState(AIState.Attacking);
                }
                break;
            case AIState.Attacking:
                // Make the target take damage
                if (base.target.TryGetComponent(out IDamageable targetObject))
                {
                    // damage
                    targetObject.Damage(damageAmount);
                    // If the target dies, go back to targetting
                    if (targetObject == null)
                    {
                        SetAIState(AIState.Targetting);
                    }
                }
                break;
        }
    }

    private Vector3 GetClosestTarget()
    {
        // Update targets array
        base.FindTargets();

        Dictionary<GameObject, float> targetsAndDistances = new Dictionary<GameObject, float>();

        foreach (GameObject target in base.targets)
        {
            var dist = Vector3.Distance(base.agent.transform.position, target.transform.position);
            targetsAndDistances[target] = dist;
        }

        // Find the smallest distance (closest)
        float closestDistance = targetsAndDistances.Values.Min();
        GameObject closestTarget = targetsAndDistances.FirstOrDefault(x => x.Value == closestDistance).Key;

        // Set the NPCs target, used in the attacking state.
        base.target = closestTarget;

        // Pass out the closest region as a Vector3
        Vector3 closestTargetPosition = closestTarget.transform.position;

        return closestTargetPosition;
    }
}
