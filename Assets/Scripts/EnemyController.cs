using UnityEngine;

public class EnemyController : BaseShotController, ICanExplodeController
{
    public float speedX = 10.0f;

    public float speedY = -1.0f;

    public float minShootingTime = 1f;

    public float maxShootingTime = 3f;

    void FixedUpdate()
    {
        // Get the new position of our Enemy. On X, move left and right; on Y slowly get down. 
        var x = boundX * Mathf.Sin(Time.fixedTime * Time.deltaTime * speedX);

        var y = transform.position.y + Time.deltaTime * speedY;

        //Set the position of our character through the RigidBody2D component (since we are using physics) 
        rigidBody.MovePosition(new Vector2(x, y));

        // Check if the player can shoot since last time the spaceship has fired
        if (Time.time - lastTimeShot > reloadTime)
        {
            // Set the current time as the last time the spaceship has fired
            lastTimeShot = Time.time;

            reloadTime = Random.Range(minShootingTime, maxShootingTime);

            // Play the shoot sound
            if (shootSound)
            {
                GetComponent<AudioSource>().PlayOneShot(shootSound);
            }
            // Create the bullet
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    public override void Hit(Vector3 hitCoordinates)
    {
        base.Hit(hitCoordinates);

        // TODO: Aditional score anid destruction logic required.
        FindObjectOfType<UIScore>().IncreaseScore(1);
    }
}
