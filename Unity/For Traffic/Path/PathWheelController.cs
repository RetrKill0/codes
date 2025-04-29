using UnityEngine;

//By RetrKill0
public class PathWheelController : MonoBehaviour
{
    [Range(0.0f, 300.0f)]
    public float rotateSpeed = 100.0f;

    public Vector3 rotationAxis = Vector3.right; 

    public bool rotateForward = true; 

    void FixedUpdate()
    {
        float direction = rotateForward ? 1.0f : -1.0f; 

        transform.Rotate(direction * rotateSpeed * Time.deltaTime * rotationAxis);
    }
}