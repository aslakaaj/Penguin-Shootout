using UnityEngine;

public class Manager : MonoBehaviour
{
    public Transform[] targets;

    private Enemy enemy;

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            enemy.TargetTransform(targets[i]);
        }
    }
}
