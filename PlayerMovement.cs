using UnityEngine;

//You need an empty gameObject (ADD THIS SCRIPT TO THIS OBJECT), with a body gameobject (Tagged "PlayerBody") as a child
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Camera cam;

    private Vector3 moveVelocity;
    private Rigidbody rb;
    public int speed = 10;

    private GameObject playerBody;
    public int rotationSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        playerBody = GameObject.FindGameObjectWithTag("PlayerBody");
    }

    // Update is called once per frame
    void Update()
    { 
        MoveInput();
        SetMousePosition();
    }

    void FixedUpdate()
    {
        //Moves the Player
        rb.AddForce(moveVelocity);
    }

    //Stores player inputs in an Vector3 wich is normalized and times with a movement speed
    void MoveInput()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(movX, 0, movY);
        moveVelocity = movement.normalized * speed;
    }

    //Finds the position of the mouse and runs the function LookAt()
    void SetMousePosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (ground.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            LookAt(point);
        }
    }

    //This function rotates the body gameObject to the mouse
    void LookAt(Vector3 _point)
    {
        //If you remove this line, the body gameobject will look at the ground :)
        Vector3 pointHeightCorrection = new Vector3(_point.x, playerBody.transform.position.y, _point.z);
        playerBody.transform.LookAt(pointHeightCorrection);
    }
}
