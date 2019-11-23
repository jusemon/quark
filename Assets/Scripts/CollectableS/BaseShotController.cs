using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public class BaseShotController: MonoBehaviour
{
    protected Rigidbody2D rigidBody;

    public GameObject bulletPrefab;

    public GameObject explosionPrefab;

    public float boundX = 10.0f;

    public float reloadTime = 1.0f;

    public AudioClip shootSound;

    public AudioClip explosionSound;

    public float timeBeforeDestruction = 20.0f;

    public bool autodestruction = false;

    protected float lastTimeShot = 0f;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        if (autodestruction)
        {
            Destroy(gameObject, timeBeforeDestruction);
        }
    }

    public void Shoot()
    {
        // Play the shoot sound
        if (shootSound)
        {
            GetComponent<AudioSource>().PlayOneShot(shootSound);
        }

        // Create the bullet
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    public virtual void Hit(Vector3 hitCoordinates)
    {
        // Create an explosion on the coordinates of the hit.
        Instantiate(explosionPrefab, hitCoordinates, Quaternion.identity);
    }
}