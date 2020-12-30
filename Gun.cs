using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Weapons/Gun")]
public class Gun : ScriptableObject
{
    public int damage;
    public int range;

    public GameObject gunPrefab;
}
