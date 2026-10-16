using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitcon : MonoBehaviour
{
    // True while the fruit is hovering at the dropper waiting to be dropped.
    public bool inCloud = false;

    private bool merged = false;
    private Rigidbody2D body;
    private Collider2D col;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Start()
    {
        if (inCloud)
        {
            // Held fruit: no gravity and no collisions until it is dropped.
            body.gravityScale = 0;
            col.enabled = false;
        }
        else
        {
            // Merge results (and anything else spawned in the pile) fall immediately.
            body.gravityScale = 1;
        }
    }

    void Update()
    {
        if (!inCloud) return;

        // z is 0 to match where dropped fruits have always sat.
        transform.position = new Vector3(FollowMouse.cloudxPos.x, FollowMouse.cloudxPos.y, 0f);

        if (Input.GetKeyDown("space"))
        {
            body.gravityScale = 1;
            col.enabled = true;
            inCloud = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (inCloud || merged) return;
        if (collision.gameObject.tag != gameObject.tag) return;

        Fruitcon other = collision.gameObject.GetComponent<Fruitcon>();
        if (other == null || other.inCloud || other.merged) return;

        // Both fruits get this callback; only one of them performs the merge.
        if (GetInstanceID() > other.GetInstanceID()) return;

        merged = true;
        other.merged = true;

        Vector2 midpoint = (transform.position + other.transform.position) / 2f;
        FollowMouse.MergeFruit(int.Parse(gameObject.tag), midpoint);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
