using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cubePrefab;
    public int numberOfCube = 10;
    private float planeSize = 10.0f;

    void Start(){
        
        for (int i = 0; i < numberOfCube; i++){
            Vector3 randomPosition = GetRandomPosition();
            Instantiate(cubePrefab,randomPosition,Quaternion.identity);
        };
    }

    // Update is called once per frame
    Vector3 GetRandomPosition(){
        float x = Random.Range(-planeSize/2,planeSize/2);
        float z = Random.Range(-planeSize/2,planeSize/2);
        return new Vector3(x,0.5f,z);
    }
}
