using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform[] fruitObj;
    static public string spawnedYet = "n";
    static public Vector2 cloudxPos;
    static public Vector2 spawnPos;
    static public string newFruit = "n"; 
    static public int whichFruit = 0;

    private Vector3 move2;
    void Update ()
    {
        spawnFruit ();

        move2 = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, 3.08f, 0));
        move2.y = 3.08f;
        if (move2.x < -4f) {
            move2.x = -4f;
        }
        if (move2.x > 1.7f) {
            move2.x = 1.7f;
        }
        transform.position = (move2) + new Vector3 (0f, 0f, 1f);

        cloudxPos = transform.position;

        if ((Input.GetKeyDown("space")) && (spawnedYet == "y"))
        {
            spawnedYet = "n";
        }
        replaceFruit ();
    }
    void spawnFruit()
    {
        if (spawnedYet == "n") 
        {
            StartCoroutine(spawntimer());
            spawnedYet = "w";
        }
    }

    void replaceFruit ()
    {
        if (newFruit == "y")
        {
            newFruit = "n";
            Instantiate (fruitObj[whichFruit + 1], spawnPos, fruitObj[1].rotation);
        }
    }

    IEnumerator spawntimer ()
    {
        yield return new WaitForSeconds (.5f);
        Instantiate(fruitObj[Random.Range(0,4)], transform.position, fruitObj[1].rotation);
        spawnedYet = "y";
    }
}