using UnityEngine;

public class Shooting : MonoBehaviour
{
    PlayerController controller;

    public Transform muzzle;
    public Projectile projectile;

    private Transform body;
    Vector3 pushForce;
    Vector3 bodyVector;

    private void Start()
    {
        body = transform.Find("Body").transform;
        controller = FindObjectOfType<PlayerController>();
    }

    public void Shoot (Gun _myGun)
    {
        //Adds forces that push player backwards
        pushForce.z = _myGun.playerKnockback;
        bodyVector.y = body.eulerAngles.y;
        //Debug.Log(pushForce);

        controller.AddPushBackForce(pushForce * -500f, bodyVector);

        //Actual shooting
        Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
        newProjectile.newSpeed(_myGun.shotSpeed);
    }
}
