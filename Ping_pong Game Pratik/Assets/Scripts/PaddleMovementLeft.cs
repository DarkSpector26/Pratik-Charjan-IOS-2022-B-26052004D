using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovementleft : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float minY = -4.0f;  // Downward limit
    public float maxY = 4.0f;   // Upward limit

    void Update()
    {
        bool isPressingUp = Input.GetKey(KeyCode.W);
        bool isPressingDown = Input.GetKey(KeyCode.S);

        if (isPressingUp)
        {
            // Move the paddle upward
            transform.Translate(Vector2.up * Time.deltaTime * movementSpeed);
        }

        if (isPressingDown)
        {
            // Move the paddle downward
            transform.Translate(Vector2.down * Time.deltaTime * movementSpeed);
        }

        // Clamp the y-position of the paddle to ensure it doesn't go beyond limits
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
