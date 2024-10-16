using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public float speed = 2.0f;         // Prędkość przesuwania się Cube
    private Vector3[] points;          // Wierzchołki kwadratu
    private int currentPointIndex = 0; // Indeks bieżącego wierzchołka, do którego dążymy

    void Start()
    {
        // Definiujemy wierzchołki kwadratu o boku 10 jednostek
        points = new Vector3[] {
            new Vector3(10, 0, 0),    // Wierzchołek 0
            new Vector3(10, 0, 10),   // Wierzchołek 1
            new Vector3(0, 0, 10),    // Wierzchołek 2
            new Vector3(0, 0, 0)      // Wierzchołek 3
        };
    }

    void Update()
    {
        // Przemieszczamy Cube w stronę bieżącego wierzchołka
        transform.position = Vector3.MoveTowards(transform.position, points[currentPointIndex], speed * Time.deltaTime);

        // Jeśli Cube osiągnie bieżący wierzchołek (odległość bliska zeru)
        if (Vector3.Distance(transform.position, points[currentPointIndex]) < 1f)
        {
            // Zmieniamy indeks na kolejny wierzchołek
            currentPointIndex = (currentPointIndex + 1) % points.Length;

            // Obracamy Cube o 90 stopni, aby wskazywał w kierunku następnego wierzchołka
            transform.Rotate(0, 90, 0);
        }
    }
}
