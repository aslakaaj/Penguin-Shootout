using UnityEngine;

public class Manager : MonoBehaviour
{
    public Transform[] targets;

    public float maxPlayerHealth = 100;
    public float currentPlayerHealth = 100;

    public bool playerTakenDamage = false;

    public GameObject[] activeEnemies;

    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
    }

    private void Update()
    {
        //Counting enemies in the scene
        activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (currentPlayerHealth <= 0)
        {
            Debug.LogWarning("PLAYER DEAD");
        }

        if (currentPlayerHealth >= maxPlayerHealth)
        {
            playerTakenDamage = false;
        }

        else if (currentPlayerHealth != maxPlayerHealth)
        {
            playerTakenDamage = true;
        }
    }
}
