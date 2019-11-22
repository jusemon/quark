﻿using UnityEngine;

public class EnemyControllerSmartAttacker : BaseEnemyController, ICanExplodeController, ICanShotController
{

    public float shootSensitivity;

    private Transform playerTransform;

    // Use this for initialization 
    public override void Start()
    {
        base.Start();
        playerTransform = FindObjectOfType<PlayerController>()?.transform;
    }

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
            // Check if the enemy is "close" on the x-axis to the player
            if (playerTransform && Mathf.Abs(playerTransform.position.x - transform.position.x) < shootSensitivity)
            {

                // Set the current time as the last time the spaceship has fired
                lastTimeShot = Time.time;

                // Shoot!
                Shoot();
            }
        }
    }
}