using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PaddleMovementRight : MonoBehaviour
{
    public float MovementSpeedRight = 1.0f;
    public float minY = -4.0f;  // Downward limit
    public float maxY = 4.0f;   // Upward limit

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        bool ispressingUp = Input.GetKey(KeyCode.UpArrow);
        bool ispressingDown = Input.GetKey(KeyCode.DownArrow);

        if (ispressingUp)
        {
            transform.Translate(Vector2.up * Time.deltaTime * MovementSpeedRight);
        }

        if (ispressingDown)
        {
            transform.Translate(Vector2.down * Time.deltaTime * MovementSpeedRight);

        }

        // Clamp the y-position of the paddle to ensure it doesn't go beyond limits
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
