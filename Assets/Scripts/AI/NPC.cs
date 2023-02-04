using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public NavMeshAgent agent;
    public AIState currentState;
    protected GameObject[] regions;

    public virtual void SetupAI()
    {
        agent = this.GetComponent<NavMeshAgent>();
        FindRegions();
        SetDestination(transform.position);
    }

    /// <summary>
    /// Sets the AI's destination to whatever is passed in.
    /// </summary>
    /// <param name="position">The position to move the AI to.</param>
    public virtual void SetDestination(Vector3 position)
    {
        Debug.Log($"moving to {position}");
        agent.SetDestination(position);
    }

    public virtual void SetAIState(AIState state)
    {
        agent.isStopped = true;
        currentState = state;
    }

    [ContextMenu("Find Regions")]
    private void FindRegions()
    {
        regions = new GameObject[0];
        regions = GameObject.FindGameObjectsWithTag("Region");
        Debug.Log($"Found {regions.Length} regions.");
    }
}

/// <summary>
/// The current state of the AI. This is used in the switch case.
/// More can be added, so it is very expandable
/// </summary>
public enum AIState
{
    Nothing,
    Targetting
}

