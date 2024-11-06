using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    private bool playerOnPlatform = false;
    private bool movingToB = true;
    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform)
        {
            MovePlatform();
        }
        
    }

    void MovePlatform()
    {
        if (movingToB)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);

            if (transform.position == pointB.position)
            {
                movingToB = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            
            if(transform.position == pointA.position)
            {
                movingToB = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {  playerOnPlatform = false;
            other.transform.SetParent(null);
        }
    }
}
