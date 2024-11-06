using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player; // Transform gracza, do obrotu w osi Y
    public Transform playerCamera; // Kamera gracza

    public float sensitivity = 200f; // Czu�o�� myszy
    private float xRotation = 0f; // Zmienna do �ledzenia obrotu w osi X (kamera)

    private void Start()
    {
        // Ukrywanie kursora oraz blokowanie go w centrum ekranu
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Pobieranie ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Obr�t gracza wok� osi Y (poziomo)
        player.Rotate(Vector3.up * mouseXMove);

        // Obr�t kamery wok� osi X (pionowo)
        xRotation -= mouseYMove;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ograniczenie k�ta w pionie

        // Zastosowanie rotacji na kamerze
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
