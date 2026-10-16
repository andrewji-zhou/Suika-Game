using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitcon : MonoBehaviour
{
    private string inthecloud = "y";
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y < 3)
        {
            inthecloud = "n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inthecloud == "y") {
            GetComponent<Transform>().position = FollowMouse.cloudxPos;
        }

        if (Input.GetKeyDown("space")) {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            inthecloud = "n";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            FollowMouse.spawnPos = transform.position;
            FollowMouse.newFruit = "y";
            FollowMouse.whichFruit = int.Parse(gameObject.tag);
            Destroy(gameObject);
        }
    }
}


