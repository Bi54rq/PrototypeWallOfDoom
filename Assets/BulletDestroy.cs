using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletDestroy : MonoBehaviour
{
    public string menuSceneName; // Name of the scene to load when hitting the player

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collides with the environment
        if (other.CompareTag("Environment"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        // Check if the bullet collides with the player
        else if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(menuSceneName); 
            Destroy(other.gameObject); 
            Destroy(gameObject); 
        }
    }
}
