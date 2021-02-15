using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float moveSpeed = 5;
    private Rigidbody rb;
    NavMeshAgent agent;
    

    public void applyDamage (float _damage)
    {
        health -= _damage;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TargetTransform(Transform _target)
    {
        agent.SetDestination(_target.position);
    }
}
