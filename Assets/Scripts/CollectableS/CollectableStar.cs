using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class CollectableStar : MonoBehaviour, ICollectable
{
    /// <summary>
    /// The collectable sound
    /// </summary>
    public AudioClip collectableSound;

    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the angel's cake
        if (collision.tag == "Player")
        {
            FindObjectOfType<UIScore>().IncreaseScore(value);

            // Play the collectable sound
            if (collectableSound)
            {
                GetComponent<AudioSource>().PlayOneShot(collectableSound);
            }

            // Hide the heart
            GetComponent<Renderer>().enabled = false;

            // Destroy the heart after a delay
            if (collectableSound)
            {
                Destroy(gameObject, collectableSound.length);
            }
            else
            {
                Destroy(gameObject);
            }

            // Destroy the script in case the player hits again the heart before that is destroyed
            Destroy(this);
        }
    }

    public void SetValue(int value)
    {
        this.value = value;
    }

}
