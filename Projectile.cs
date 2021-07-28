using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float shotSpeed;
    private float controlSpeed;
    [SerializeField]
    private float dSpeed = 1;

    private Enemy enemy;
    private Holster holster;
    private Vector3 pushForce;
    private Vector3 bodyVector;

    private Rigidbody rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        holster = FindObjectOfType<Holster>();
    }

    public void newSpeed(float _newSpeed)
    {
        shotSpeed = _newSpeed;
    }

    private void Update()
    {
        Vector3 test = Vector3.forward * Time.deltaTime * shotSpeed;
        transform.Translate(test);

        if (test.z >= holster.equippedGun.range)
        {
            rb.useGravity = true;
        }

        shotSpeed += dSpeed;

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.applyDamage(holster.equippedGun.damage);
            enemy.AddPushBackForce(pushForce * 500f, bodyVector);
            Destroy(gameObject);
        }
    }

    public void newKnockbackForce(Vector3 _pushForce, Vector3 _bodyVector)
    {
        pushForce = _pushForce;
        bodyVector = _bodyVector;
    }
}
