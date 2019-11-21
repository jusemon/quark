using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class BaseShotController: MonoBehaviour
{
    protected Rigidbody2D rigidBody;

    public GameObject bulletPrefab;

    public GameObject explosionPrefab;

    public float boundX = 10.0f;

    public float reloadTime = 1.0f;

    protected float lastTimeShot = 0f;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public virtual void Hit(Vector3 hitCoordinates)
    {
        // Create an explosion on the coordinates of the hit.
        Instantiate(explosionPrefab, hitCoordinates, Quaternion.identity);
    }
}