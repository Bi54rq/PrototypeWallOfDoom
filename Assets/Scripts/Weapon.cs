using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint; // The point where the bullet will be spawned
    public GameObject player;   // The player GameObject to target
    public GameObject bullet;   // The bullet prefab to instantiate
    public float shootInterval = 5f; // Time in seconds between shots

    private float nextShootTime = 0f; // Time when the next shot should occur

    void Update()
    {
        // Check if the current time is greater than or equal to the next shoot time
        if (Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootInterval; // Schedule the next shot
        }
    }

    void Shoot()
    {
        if (player != null && bullet != null && firePoint != null)
        {
            // Instantiate the bullet at the fire point's position and rotation
            GameObject bulletInstance = Instantiate(bullet, firePoint.position, firePoint.rotation);

            // Get the Bullet component and initialize it with the player's position
            Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.Initialize(player.transform.position);
            }
        }
    }
}
