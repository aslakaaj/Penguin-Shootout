using UnityEngine;

public class CameraSmoothing : MonoBehaviour
{
    private GameObject lookAt;

    public bool smooth = false;
    private float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -6.5f);

    void Start()
    {
        lookAt = GameObject.Find("Player");
    }

    public void FixedUpdate()
    {
        Vector3 desiredPosition = lookAt.transform.position + offset;

        if (smooth)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
        else
        {
            transform.position = desiredPosition;
        }
    }

    public void Smooth_Switch(bool newValue)
    {
        smooth = newValue;
    }
}
