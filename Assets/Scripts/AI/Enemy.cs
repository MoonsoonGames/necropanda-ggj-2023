using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : NPC
{
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
                // stop the AI
                base.currentState = AIState.Targetting;
                break;

            case AIState.Targetting:
                Debug.Log(GetClosestTarget());
                base.SetDestination(GetClosestTarget());
                break;
        }
    }

    private Vector3 GetClosestTarget()
    {
        Dictionary<GameObject, float> regionsAndDistances = new Dictionary<GameObject, float>();

        foreach (GameObject region in base.regions)
        {
            var dist = Vector3.Distance(base.agent.transform.position, region.transform.position);
            regionsAndDistances[region] = dist;
        }

        // Find the smallest distance (closest)
        float closestDistance = regionsAndDistances.Values.Min();
        GameObject closestRegion = regionsAndDistances.FirstOrDefault(x => x.Value == closestDistance).Key;

        // Pass out the closest region as a Vector3
        Vector3 closestRegionPosition = closestRegion.transform.position;

        return closestRegionPosition;
    }
}
