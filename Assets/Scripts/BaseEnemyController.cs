using UnityEngine;

public class BaseEnemyController : BaseShotController
{
    public float speedX = 10.0f;

    public float speedY = -1.0f;

    public int collectableValue = 1;

    public GameObject collectable;

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
}
