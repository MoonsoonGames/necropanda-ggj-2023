using UnityEngine;

public class IsometricCharacterController : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        transform.position += moveDirection;
    }
}