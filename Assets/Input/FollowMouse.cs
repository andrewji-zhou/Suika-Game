using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform[] fruitObj;
    static public string spawnedYet = "n";
    static public Vector2 cloudxPos;

    private static FollowMouse instance;
    private Vector3 move2;

    void Awake ()
    {
        instance = this;
    }

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
    }
    void spawnFruit()
    {
        if (spawnedYet == "n") 
        {
            StartCoroutine(spawntimer());
            spawnedYet = "w";
        }
    }

    // Called by Fruitcon when two fruits of the same type merge.
    // The largest fruit has no next level, so its pair just disappears.
    static public void MergeFruit (int fruitIndex, Vector2 position)
    {
        int next = fruitIndex + 1;
        if (next >= instance.fruitObj.Length)
        {
            return;
        }
        Instantiate (instance.fruitObj[next], position, instance.fruitObj[1].rotation);
    }

    IEnumerator spawntimer ()
    {
        yield return new WaitForSeconds (.5f);
        Transform fruit = Instantiate(fruitObj[Random.Range(0,4)], transform.position, fruitObj[1].rotation);
        fruit.GetComponent<Fruitcon>().inCloud = true;
        spawnedYet = "y";
    }
}