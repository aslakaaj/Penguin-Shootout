using UnityEngine;

//You need an empty gameObject, with a body gameobject (Tagged "PlayerBody") as a child 
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector3 moveVelocity;
    private Vector3 pushForce;
    private Vector3 bodyVector;

    public Rigidbody rb;

    private GameObject playerBody;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerBody = GameObject.FindGameObjectWithTag("PlayerBody");
    }

    void FixedUpdate()
    {
        //Moves the Player
        rb.AddForce(moveVelocity);

        //Knocksback player after shooting
        rb.AddForce(pushForce);
        pushForce.Set(0, 0, 0);
    }

    public void AddMovement(Vector3 _moveVelocity)
    {
        moveVelocity = _moveVelocity;
    }

    //This function rotates the body gameObject to the mouse
    public void LookAt(Vector3 _point)
    {
        //If you remove this line, the body gameobject will look at the ground :)
        Vector3 pointHeightCorrection = new Vector3(_point.x, playerBody.transform.position.y, _point.z);
        playerBody.transform.LookAt(pointHeightCorrection);
    }

    //Adds recoil force to the player when shooting
    public void AddPushBackForce(Vector3 _pushForce, Vector3 _bodyVector)
    {
        pushForce = _pushForce;

        pushForce = Quaternion.Euler(0, _bodyVector.y, 0) * pushForce;

       //Debug.Log(pushForce);
       //Debug.Log(bodyVector);
    }
}
