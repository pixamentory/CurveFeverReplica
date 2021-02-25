using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 200f;

    public string inputAxis = "Horizontal";

    float horizontal = 0f;

    void Update()
    {
        // Taking user input for player rotation
        horizontal = Input.GetAxisRaw(inputAxis);
    }


    private void FixedUpdate()
    {
        // player movement
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);

        //player rotation
        transform.Rotate(Vector3.forward * -horizontal * rotationSpeed * Time.fixedDeltaTime);
    }

    // checking for player collision for game over
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillsPlayer"))
        {
            speed = 0;
            rotationSpeed = 0;
            GameObject.FindObjectOfType<GameManager>().EndGame();
        }
    }
}
