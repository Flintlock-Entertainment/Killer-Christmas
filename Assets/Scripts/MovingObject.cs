using UnityEngine;

/**
 *  This component moves its object back and forth between two points in space, using a rigid body.
 */
[RequireComponent(typeof(Rigidbody2D))]
public class MovingObject : MonoBehaviour
{
    [Tooltip("The points between which the platform moves")]
    [SerializeField] Transform startPoint = null, endPoint = null;

    [SerializeField] float speed = 1f;
    [SerializeField] float EPS = 0.1f;

    private bool moveFromStartToEnd = true;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (moveFromStartToEnd)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime));
        }
        else
        {  // move from end to start
            rb.MovePosition(Vector2.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime));
        }
        bool atStartPos = Mathf.Abs(transform.position.x - startPoint.position.x) < EPS;
        bool atEndPos = Mathf.Abs(transform.position.x - endPoint.position.x) < EPS;
        if (atStartPos)
        {
            moveFromStartToEnd = true;
        }
        else if (atEndPos)
        {
            moveFromStartToEnd = false;
        }
    }
}