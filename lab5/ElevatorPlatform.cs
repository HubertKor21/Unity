using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>(); // Lista waypoint�w
    public float speed = 2f;  // Pr�dko�� poruszania si� platformy
    private int currentWaypoint = 0; // Indeks aktualnego waypointa
    private bool isPlayerOnPlatform = false;  // Flaga sprawdzaj�ca, czy gracz jest na platformie

    void Start()
    {
        // Sprawdzamy, czy mamy co najmniej 2 punkty w li�cie waypoint�w
        if (waypoints.Count < 2)
        {
            Debug.LogWarning("Nie wystarczaj�ca liczba waypoint�w!");
            return;
        }
    }

    void Update()
    {
        if (waypoints.Count < 2) return;

        // Je�li gracz jest na platformie, pozw�l platformie porusza� si�
        if (isPlayerOnPlatform)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        // Poruszamy platform� do aktualnego waypointa
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint], speed * Time.deltaTime);

        // Je�li platforma dotar�a do waypointa
        if (transform.position == waypoints[currentWaypoint])
        {
            // Zmieniamy waypoint na kolejny (cyklicznie)
            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        }
    }

    // Funkcja wywo�ywana, gdy gracz wchodzi na platform�
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Sprawdzamy, czy obiekt to gracz
        {
            isPlayerOnPlatform = true; // Gracz wchodzi na platform�, wi�c zaczynamy ruch
            other.transform.parent = transform; // Gracz staje si� dzieckiem platformy
        }
    }

    // Funkcja wywo�ywana, gdy gracz schodzi z platformy
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = false; // Gracz schodzi z platformy, wi�c zatrzymujemy ruch
            other.transform.parent = null; // Gracz przestaje by� dzieckiem platformy
        }
    }
}
