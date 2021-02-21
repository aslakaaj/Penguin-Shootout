using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public float health = 100;
    private Rigidbody rb;
    NavMeshAgent agent;

    Manager manager;
    

    public void applyDamage (float _damage)
    {
        health -= _damage;
    }

    private void Awake()
    {
        manager = FindObjectOfType<Manager>();
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

    private void FixedUpdate()
    {
        for (int i = 0; i < manager.targets.Length; i++)
        {
            TargetTransform(manager.targets[i]);
        }
    }

    public void TargetTransform(Transform _target)
    {
        agent.SetDestination(_target.position);
    }
}
