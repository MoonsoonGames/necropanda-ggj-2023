using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : NPC
{
    public int damageAmount;
    public float attackTime = 5f;
    float currentTime = 5f;
    public float range = 5f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

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
                base.SetDestination(GetClosestTarget());
                // Make sure the target isnt null
                if (base.target == null)
                    return;

                var dist = Vector3.Distance(target.transform.position, transform.position);
                if (dist < range)
                {
                    SetAIState(AIState.Attacking);
                }
                break;
            case AIState.Attacking:
                // Make the target take damage
                if (base.target == null)
                {
                    SetAIState(AIState.Targetting);
                }

                // This will throw an error, basically there's a frame where unity still thinks that the target exists, this happens
                // before we get chance to change the state, it only throws 1 error per AI, not hundreds
                if (base.target.TryGetComponent(out IDamageable targetObject))
                {
                    if (currentTime >= attackTime)
                    {
                        // damage
                        targetObject.Damage(damageAmount);
                        // If the target dies, go back to targetting
                        if (targetObject == null)
                        {
                            SetAIState(AIState.Targetting);
                        }

                        currentTime = 0;
                    }
                    else
                    {
                        currentTime += Time.deltaTime;
                    }
                }
                break;
        }
    }

    private Vector3 GetClosestTarget()
    {
        // Update targets array
        base.FindTargets();

        if (base.targets.Length == 0)
        {
            return transform.position;
        }

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
