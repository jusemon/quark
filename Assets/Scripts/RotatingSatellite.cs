using UnityEngine;

public class RotatingSatellite : MonoBehaviour
{
    public float speed = 3f;

    public float radius = 1f;

    public int initial;

    // Update is called once per frame
    void Update()
    {
        var x = radius * Mathf.Cos(speed * Time.time + initial);

        var y = radius * Mathf.Sin(speed * Time.time + initial);

        transform.localPosition = new Vector3(x, y, 0f);
    }
}
