using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public float speed = 1.3f;

    private Vector3 initialPos;

    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position 
        initialPos = transform.position;

        // Store the y-length of the Sprite 
        offset = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Scroll the background 
        transform.position += new Vector3(0, -Time.deltaTime * speed, 0);

        //Check if the scrolling has passed the offset, if so, reposition the image 
        if (Mathf.Abs(transform.position.y - initialPos.y) > offset)
        {
            //Reposition the image 
            transform.position = initialPos;
        }
    }
}
