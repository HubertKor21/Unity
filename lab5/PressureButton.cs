using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    public float launchForce = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                Vector3 launchVelocity = Vector3.up * launchForce;
                playerRigidbody.velocity = launchVelocity;
                Debug.Log("Player zosta³ wyrzucony w powietrze!");
            }
        }
    }
}
