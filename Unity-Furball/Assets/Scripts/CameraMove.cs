using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed = 5f;
    public float edgeSize = 50f;
    public float minX = -5f;
    public float maxX = 5f;
  

    void Update()
    {
        float move = 0f;

        // Keyboard input (A / D)
        if (Input.GetKey(KeyCode.A))
            move -= 1f;

        if (Input.GetKey(KeyCode.D))
            move += 1f;

        // Mouse edge scrolling
        if (Input.mousePosition.x <= edgeSize)
            move -= 1f;

        if (Input.mousePosition.x >= Screen.width - edgeSize)
            move += 1f;

        // Apply movement
        Vector3 pos = transform.position;
        pos.x += move * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
}


