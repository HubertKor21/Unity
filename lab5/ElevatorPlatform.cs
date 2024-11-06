using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>(); // Lista waypointów
    public float speed = 2f;  // Prêdkoœæ poruszania siê platformy
    private int currentWaypoint = 0; // Indeks aktualnego waypointa
    private bool isPlayerOnPlatform = false;  // Flaga sprawdzaj¹ca, czy gracz jest na platformie

    void Start()
    {
        // Sprawdzamy, czy mamy co najmniej 2 punkty w liœcie waypointów
        if (waypoints.Count < 2)
        {
            Debug.LogWarning("Nie wystarczaj¹ca liczba waypointów!");
            return;
        }
    }

    void Update()
    {
        if (waypoints.Count < 2) return;

        // Jeœli gracz jest na platformie, pozwól platformie poruszaæ siê
        if (isPlayerOnPlatform)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        // Poruszamy platformê do aktualnego waypointa
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint], speed * Time.deltaTime);

        // Jeœli platforma dotar³a do waypointa
        if (transform.position == waypoints[currentWaypoint])
        {
            // Zmieniamy waypoint na kolejny (cyklicznie)
            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        }
    }

    // Funkcja wywo³ywana, gdy gracz wchodzi na platformê
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Sprawdzamy, czy obiekt to gracz
        {
            isPlayerOnPlatform = true; // Gracz wchodzi na platformê, wiêc zaczynamy ruch
            other.transform.parent = transform; // Gracz staje siê dzieckiem platformy
        }
    }

    // Funkcja wywo³ywana, gdy gracz schodzi z platformy
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = false; // Gracz schodzi z platformy, wiêc zatrzymujemy ruch
            other.transform.parent = null; // Gracz przestaje byæ dzieckiem platformy
        }
    }
}
