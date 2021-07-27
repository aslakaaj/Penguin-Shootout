using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave/NormalWave")]
public class WaveObject : ScriptableObject
{
    public int basicEnemiesToSpawn;
    //Other enemies
    //Boss enemies etc

    public float secondsBetweenSpawns = 2f;

    public GameObject basicEnemy;
}
