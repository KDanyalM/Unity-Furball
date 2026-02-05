using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction jumpAction;
    Rigidbody rigidbody;
    Vector3 move;
    public static float jumpForce = 200;
    public float moveSpeed = 20.0f;
    Vector3 jump = new Vector3(0, jumpForce, 0);

    void Start()
    {
        moveAction.Enable();
        jumpAction.Enable();
        rigidbody = GetComponent<Rigidbody>();     
    }

    void Update()
    {
        move = moveAction.ReadValue<Vector3>();

        if (jumpAction.WasPerformedThisFrame())
        {
            Jump();
        }
        


    }
    void Jump()
    {
        rigidbody.AddForce(jump);
    }


    private void FixedUpdate()
    {
        Vector3 position = (Vector3)rigidbody.position + move * moveSpeed * Time.deltaTime;
        rigidbody.MovePosition(position);

    }
}
