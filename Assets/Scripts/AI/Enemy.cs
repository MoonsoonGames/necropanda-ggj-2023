using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class Enemy : NPC
{
    public int damageAmount;
    public float attackTime = 5f;
    float currentTime = 5f;
    public float range = 5f;

    bool confused = false;
    float confusedTime = 0;

    // Wander vars
    float wanderCooldown;
    float wanderRadius;
    float timer;
    public float maxWanderDuration = 30f;
    bool blocked;
    NavMeshHit hit;
    [SerializeField]
    private float timeLeftTillScriptCleanup;

    private Coroutine disableScript;

    // Variable used for the RandomNav Function
    Vector3 newPos;

    private void OnEnable()
    {
        timeLeftTillScriptCleanup = maxWanderDuration;
        //aiController.currentState = AIState.Wandering;
        disableScript = StartCoroutine(WaitForWander(maxWanderDuration));
    }

    /// <summary>
    /// Supposed to reset variables on disable, but just gave me more headaches as it seems to keep resetting things regardless
    /// of whether the script is enabled or not.
    /// </summary>
    private void OnDisable()
    {
        StopCoroutine(disableScript);
        StopCoroutine(Cooldown(.1f));
        timer = 0f;
        timeLeftTillScriptCleanup = maxWanderDuration;
        timer = 0f;
    }

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

        // Might be a good idea to just access the AIControllers timer to avoid sync issues.
        // Start the timer
        timer += Time.deltaTime;

        timeLeftTillScriptCleanup -= (timeLeftTillScriptCleanup > 0) ? Time.deltaTime : 0;
    }

    public void FSM()
    {
        switch (base.currentState)
        {
            case AIState.Nothing:
                base.SetAIState(AIState.Targetting);
                break;

            case AIState.Targetting:
                base.SetDestination(GetClosestTarget());
                // Make sure the target isnt null
                if (base.target == null)
                    return;

                var dist = Vector3.Distance(target.transform.position, transform.position);
                if (dist < range)
                {
                    base.SetAIState(AIState.Attacking);
                }
                if (confused)
                {
                    base.SetAIState(AIState.Confused);
                }
                break;

            case AIState.Attacking:
                // Make the target take damage
                if (base.target == null)
                {
                    base.SetAIState(AIState.Targetting);
                }
                else
                {
                    // This will throw an error, basically there's a frame where unity still thinks that the target exists, this happens
                    // before we get chance to change the state, it only throws 1 error per AI, not hundreds
                    if (base.target.TryGetComponent(out IDamageable targetObject))
                    {
                        if (currentTime >= attackTime)
                        {
                            Debug.Log("Enemy attacked for " + damageAmount);
                            // damage
                            targetObject.Damage(damageAmount);
                            // If the target dies, go back to targetting
                            if (targetObject == null)
                            {
                                base.SetAIState(AIState.Targetting);
                            }

                            currentTime = 0;
                        }
                        else
                        {
                            currentTime += Time.deltaTime;
                        }

                        // Confusion
                        if (confused)
                        {
                            base.SetAIState(AIState.Confused);
                        }
                    }
                }

                break;


            case AIState.Confused:
                WanderInRadius(blocked, hit);
                break;
        }
    }

    #region Other Functions

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

    #region Wander
    /// <summary>
    /// This function handles the wandering for the AI.
    /// Uses the Navmesh and picks a point on it to move to. If the point is blocked by something, go to a new point.
    /// This will eventually extend the vision function(or class) to move move out of the wandering state.
    /// </summary>
    /// <param name="timer">Timer, passed in from the controller.</param>
    /// <param name="wanderTimer">How long to wait before moving to a new point, passed in from controller.</param>
    /// <param name="wanderRadius">How far to wander, passed in from controller.</param>
    /// <param name="blocked">Checks to see if the current picked point is blocked, Passed in from controller.</param>
    /// <param name="hit">Used for storing the navmesh location variable, passed in from controller.</param>
    /// <param name="agent">The navmesh agent, passed in from controller.</param>
    public void WanderInRadius(bool blocked, NavMeshHit hit)
    {
        base.agent.speed = 15;
        if (timer >= wanderCooldown)
        {
            newPos = RandomWanderPoint(transform.position, wanderRadius, -1);
            blocked = NavMesh.Raycast(transform.position, newPos, out hit, NavMesh.AllAreas);
            Debug.DrawLine(transform.position, newPos, blocked ? Color.red : Color.green);
            if (!blocked)
            {
                base.SetDestination(newPos);
                StartCoroutine(Cooldown(.1f));
                timer = 0;
            }
            else
            {
                //Debug.Log($"{data.Agent.name} is blocked! Finding a new point..");
                timer = 0;
                return;
            }
        }
    }

    /// <summary>
    /// This void is what allows the AI to wander about the world, it's a little bit rudimentary
    /// but it is for sure good enough for what I need right now. For reference, some of this is
    /// identical to what I used in a previous project *Gimme Gimme*, it worked well enough then, and it
    /// should do the same for now
    ///
    /// <para>The only new parts are the blocked path detection which will make sure the AI doesn't run to a
    /// point it can't get to, causing it to do some unwanted behaviour</para>
    /// </summary>
    /// <param name="origin">Where the point is chosen from(around)</param>
    /// <param name="dist">How far it should pick from around the origin</param>
    /// <param name="layermask">The layermask of things to hit</param>
    /// <returns>nav hit point, which is a point on the navmesh</returns>
    private static Vector3 RandomWanderPoint(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    IEnumerator Cooldown(float coolDown)
    {
        yield return new WaitForSeconds(coolDown);
        wanderCooldown = UnityEngine.Random.Range(1f, 10f);
    }

    /// <summary>
    /// This coroutine manages the delay that the script will wait before cleaning itself up.
    /// </summary>
    /// <param name="time">How long before the script gets cleaned up</param>
    /// <returns>waits for the alloted time before continuing</returns>
    IEnumerator WaitForWander(float time)
    {
        yield return new WaitForSeconds(time);
        StopWander();
    }

    /// <summary>
    /// Disables script, is public so it can be called elsewhere if needed.
    /// </summary>
    public void StopWander()
    {
        //Debug.Log("ran");
        confused = false;
        base.agent.speed = agentSpeed;
        base.SetAIState(AIState.Nothing);
    }
    #endregion

    #region Confusion

    public void Confuse(float time)
    {
        confused = true;
        confusedTime += time;

        InvokeRepeating("CheckConfusionTime", 0, 0.1f);
    }

    void CheckConfusionTime()
    {
        if (confusedTime > 0)
        {
            confusedTime -= Time.deltaTime;
        }
        else
        {
            CancelInvoke();
            confused = false;
            confusedTime = 0;
        }
    }

    #endregion

    #endregion
}