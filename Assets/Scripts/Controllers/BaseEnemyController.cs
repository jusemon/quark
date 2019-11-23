using UnityEngine;

public class BaseEnemyController : BaseShotController
{
    public float speedX = 10.0f;

    public float speedY = -1.0f;

    public int collectableValue = 1;

    public GameObject collectable;

    private float initialPositionX;

    public override void Start()
    {
        base.Start();
        this.initialPositionX = transform.position.x;
        Debug.Log($"initialPositionX: {initialPositionX}, localPosition: {transform.localPosition.x}");
    }

    public override void Hit(Vector3 hitCoordinates)
    {
        base.Hit(hitCoordinates);

        if (explosionSound)
        {
            GetComponent<AudioSource>().PlayOneShot(explosionSound);

            GetComponent<Renderer>().enabled = false;

            Destroy(gameObject, explosionSound.length);
        }
        else
        {
            Destroy(gameObject);
        }

        Destroy(this);

        Instantiate(collectable, transform.position, Quaternion.identity).GetComponent<ICollectable>().SetValue(collectableValue);
    }

    protected void Move()
    {

        // Get the new position of our Enemy. On X, move left and right; on Y slowly get down. 
        var x = boundX * Mathf.Sin(Time.fixedTime * Time.deltaTime * speedX + initialPositionX);

        var y = transform.position.y + Time.deltaTime * speedY;

        //Set the position of our character through the RigidBody2D component (since we are using physics) 
        rigidBody.MovePosition(new Vector2(x, y));
    }
}
