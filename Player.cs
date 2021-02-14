using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Shooting))]
public class Player : MonoBehaviour
{
    Camera cam;

    private PlayerController playerController;
    private Holster holster;
    private Shooting shooting;
    public int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        holster = gameObject.GetComponentInChildren<Holster>();
        shooting = gameObject.GetComponent<Shooting>();
        playerController = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player Movement
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(movX, 0, movY);
        Vector3 moveVelocity = movement.normalized * speed;

        playerController.AddMovement(moveVelocity);

        // Player looking
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (ground.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            playerController.LookAt(point);
        }

        //Player Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            shooting.Shoot(holster.equippedGun);
        }
    }
}
