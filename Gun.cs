using UnityEngine;

//This script makes it easier to make new guns
[CreateAssetMenu(fileName = "New Gun", menuName = "Weapons/Gun")]
public class Gun : ScriptableObject
{
    public string weaponName;
    public int damage;
    public int range;
    public float playerKnockback;
    public float shotSpeed = 10;

    public GameObject gunPrefab;
}
