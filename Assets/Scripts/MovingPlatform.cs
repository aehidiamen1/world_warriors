using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;

    private int i;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set the position of the platform to the starting point
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        //If the platform is close to the next point, move to the next point
        if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if(i == points.Length)
            {
                i = 0;
            }
        }

        //Move the platform towards the next point
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    //When a player lands on the platform, make the player a child of the platform so they move together
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the object colliding with the platform is the player
        if (collision.collider.CompareTag("Player"))
        {
            if (transform.position.y < collision.transform.position.y-0.8f)
                collision.transform.parent = transform;   
        }
    }

    //When the player leaves the platform, remove the parent so they no longer move together
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
