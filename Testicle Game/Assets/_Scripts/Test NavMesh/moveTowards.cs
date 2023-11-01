using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTowards : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;
    private NavMeshAgent agent;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        if (targets.Count == 0)
        {
            Debug.LogWarning("No targets assigned to the list.");
        }
    }

    void Update()
    {
        if (targets.Count > 0)
        {
            Transform closestTarget = GetClosestTarget();
            agent.SetDestination(closestTarget.position);
        }
    }

    Transform GetClosestTarget()
    {
        Transform closest = targets[0];
        float closestDistance = Vector3.Distance(transform.position, targets[0].position);

        for (int i = 1; i < targets.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, targets[i].position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = targets[i];
            }
        }

        return closest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Check if the collided object is one of the targets.
            if (targets.Contains(collision.transform))
            {
                Debug.Log("Collision with a target");
                targets.Remove(collision.transform); // Remove the target from the list.
                Destroy(collision.gameObject); // Destroy the collided object.
            }
        }
    }
}
