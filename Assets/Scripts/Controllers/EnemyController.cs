using UnityEngine;

public class EnemyController : BaseEnemyController, ICanShotController, ICanExplodeController
{
    public float minShootingTime = 1f;

    public float maxShootingTime = 3f;

    void FixedUpdate()
    {
        Move();

        // Check if the player can shoot since last time the spaceship has fired
        if (Time.time - lastTimeShot > reloadTime)
        {
            // Set the current time as the last time the spaceship has fired
            lastTimeShot = Time.time;

            reloadTime = Random.Range(minShootingTime, maxShootingTime);
            Shoot();
        }
    }
}
