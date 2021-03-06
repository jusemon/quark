﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class BulletController : MonoBehaviour
{
    public float speed = 10.0f;

    public float timeBeforeDestruction = 10.0f;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        // Destroy the bullet if it didn't hit anything after 10 seconds
        Destroy(gameObject, timeBeforeDestruction);
    }

    void FixedUpdate()
    { 
        //Get the new position of our bullet 
        var y = transform.position.y + Time.deltaTime * speed;

        //Set the position of our bullet through the RigidBody2D component (since we are using physics) 
        rigidBody.MovePosition(new Vector2(transform.position.x, y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the bullet (and it has been shot by an enemy)
        if ((collision.tag == "Player" && speed < 0) || (collision.tag == "Enemy" && speed > 0))
        {
            var component = collision.GetComponent<ICanExplodeController>();
            if (component != null)
            {
                // Send the message to the player/enemy that the spaceship has been hit
                collision.GetComponent<ICanExplodeController>().Hit(transform.position);

                // Destroy the bullet
                Destroy(gameObject);
            }
        }
    }
}
