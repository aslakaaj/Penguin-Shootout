using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holster : MonoBehaviour
{
    //In the inspector you can implement a GUN object (Wich is what were made in the GUN script)
    [SerializeField]
    private Gun weaponToSpawn;

    //When this script awakes, the selected gun will Instanstiate in the game
    void Awake()
    {
        GameObject weapon = Instantiate(weaponToSpawn.gunPrefab, transform.position, transform.rotation) as GameObject;
        weapon.transform.parent = transform;
    }
}
