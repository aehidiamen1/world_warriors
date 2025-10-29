using UnityEngine;
using System.Collections; // Needed for IEnumerator

public class enemy_patrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    private bool isWaiting = false; // To prevent movement while idling

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isWalking", true);
    }

    void Update()
    {
        if (isWaiting) return; // Don't move while idling

        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.linearVelocity = new Vector2(speed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, 0);
        }

        // Check if we reached a point
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            if (currentPoint == pointB.transform)
            {
                StartCoroutine(WaitAndSwitch(pointA.transform));
            }
            else if (currentPoint == pointA.transform)
            {
                StartCoroutine(WaitAndSwitch(pointB.transform));
            }
        }
    }

    //Pausing the patrol cycle when it reaches the end of the current point it is at
    private IEnumerator WaitAndSwitch(Transform nextPoint)
    {
        isWaiting = true;
        rb.linearVelocity = Vector2.zero;
        anim.SetBool("isWalking", false); // Play idle animation

        yield return new WaitForSeconds(2f); // Wait 2 seconds

        flip();
        anim.SetBool("isWalking", true); // Resume walking
        currentPoint = nextPoint;
        isWaiting = false;
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
