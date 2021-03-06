﻿using UnityEngine;

public class PlayerController : BaseShotController, ICanExplodeController
{
    public float speed = 10.0f;

    public Joystick joystick;

    void FixedUpdate()
    {
        //Get the new position of our character 
        var x = transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if (joystick && Input.GetAxis("Horizontal") == 0)
        {
            x = transform.position.x + joystick.Horizontal * Time.deltaTime * speed;
        }

        // Clamp along x-value according to boundX variable
        x = Mathf.Clamp(x, -boundX, boundX);

        //Set the position of our character through the RigidBody2D component (since we are using physics) 
        rigidBody.MovePosition(new Vector2(x, transform.position.y));

        // Check if the player has fired
        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire1"))
        {
            PlayerShoot();
        }
    }

    public void PlayerShoot()
    {
        // Check if the player can shoot since last time the spaceship has fired
        if (Time.time - lastTimeShot > reloadTime)
        {
            // Set the current time as the last time the spaceship has fired
            lastTimeShot = Time.time;

            Shoot();
        }
    }

    public override void Hit(Vector3 hitCoordinates)
    {
        base.Hit(hitCoordinates);
        if (explosionSound)
        {
            GetComponent<AudioSource>().PlayOneShot(explosionSound);
        }
        FindObjectOfType<UILivesCounter>().RemoveLife();
    }
}
