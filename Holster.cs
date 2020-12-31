using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holster : MonoBehaviour
{
    [SerializeField]
    private Gun weaponToSpawn;

    void Start()
    {
        GameObject weapon = Instantiate(weaponToSpawn.gunPrefab, transform.position, transform.rotation) as GameObject;
        weapon.transform.parent = transform;
    }

    void Update()
    {
        
    }
}
