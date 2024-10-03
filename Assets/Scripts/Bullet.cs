using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    private Rigidbody2D rb;   // Rigidbody2D component

    // This method will be called to initialize the bullet's direction
    public void Initialize(Vector2 targetPosition)
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();

        // Calculate the direction towards the target position
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        // Set the linear velocity towards the target position
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collides with the environment or the player
        if (other.CompareTag("Environment") || other.CompareTag("Player"))
        {
            // Handle logic for hitting the environment or player
            Destroy(gameObject); // Destroy the bullet on collision with the environment or player
        }
    }
}
