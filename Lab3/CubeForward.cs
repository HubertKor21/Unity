using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 2.0f;
    private float targetPositionX = 10.0f;  // Docelowa pozycja wzdłuż osi X
    private bool movingForward = true;  

    void Update(){
        float step = speed * Time.deltaTime;

        if(movingForward){
            transform.Translate(step,0,0);

            if(transform.position.x >= targetPositionX){
                movingForward = false;
            }
        }
        else {
            transform.Translate(-step,0,0);

            if(transform.position.x <= 0){
                movingForward = true;
            }
        }

    }

    


}