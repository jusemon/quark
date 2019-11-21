﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class EnemyController : BaseShotController, ICanExplodeController
{
    public float speedX = 10.0f;

    public float speedY = -1.0f;

    public float minShootingTime = 1f;

    public float maxShootingTime = 3f;

    void FixedUpdate()
    {
        // Get the new position of our enemy . On X, move left and right; on Y Slowly get down.
        var x = boundX * Mathf.Sin(Time.deltaTime * speedX);
        var y = transform.position.y + Time.deltaTime * speedY;

        //Set the position of our character through the RigidBody2D component (since we are using physics) 
        rigidBody.MovePosition(new Vector2(x, transform.position.y));

        // Check if the player can shoot since last time the spaceship has fired
        if (Time.time - lastTimeShot > reloadTime)
        {
            // Set the current time as the last time the spaceship has fired
            lastTimeShot = Time.time;

            reloadTime = Random.Range(minShootingTime, maxShootingTime);

            // Create the bullet
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}