using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public string menuSceneName; // Name of the scene to load when hitting the player

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collides with the environment
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(menuSceneName); 
            Destroy(other.gameObject); 
            Destroy(gameObject); 
        }
        
    }
}
