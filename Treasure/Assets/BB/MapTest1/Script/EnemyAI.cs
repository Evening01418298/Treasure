using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float wanderRadius = 10f;
    public float wanderInterval = 3f;

    NavMeshAgent agent;
    float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderInterval;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderInterval)
        {
            timer = 0;

            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius);
            agent.SetDestination(newPos);
        }
    }

    Vector3 RandomNavSphere(Vector3 origin, float dist)
    {
        Vector3 randomPoint = origin + Random.insideUnitSphere * dist;
        NavMeshHit hit;

        NavMesh.SamplePosition(randomPoint, out hit, dist, NavMesh.AllAreas);

        return hit.position;
    }
}
