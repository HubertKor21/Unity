using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float playerSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal")*playerSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical")*playerSpeed * Time.deltaTime;

        transform.Translate(moveX,0,moveZ);
    }
}
