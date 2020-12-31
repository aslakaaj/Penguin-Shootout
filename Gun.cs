using UnityEngine;

//This script makes it easier to make new guns
[CreateAssetMenu(fileName = "New Gun", menuName = "Weapons/Gun")]
public class Gun : ScriptableObject
{
    public int damage;
    public int range;

    //The graphics for your gun
    public GameObject gunPrefab;
}
