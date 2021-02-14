using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float shotSpeed;

    public void newSpeed(float _newSpeed)
    {
        shotSpeed = _newSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * shotSpeed);
    }
}
