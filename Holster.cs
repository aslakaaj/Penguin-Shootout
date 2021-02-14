using UnityEngine;

public class Holster : MonoBehaviour
{
    [HideInInspector]
    public Gun equippedGun;
    public Gun weaponToStartWith;
    
    private GameObject weapon;
    public bool isEquipped = false;

    void Awake()
    {
        if (equippedGun != null)
        {
            equippedGun = null;
        }

        EquipGun(weaponToStartWith);

        weapon = Instantiate(equippedGun.gunPrefab, transform.position, transform.rotation) as GameObject;
        weapon.transform.parent = transform;
        isEquipped = true;
    }

    public void EquipGun(Gun _GunToEquip)
    {
        equippedGun = _GunToEquip;
    }
}
