using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCharacterController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    public Transform playerCamera; // Referencja do kamery

    private float rotationSpeed = 700f; // Pr�dko�� obracania postaci (g��wnie w osi Y)

    private void Start()
    {
        // Zak�adamy, �e komponent CharacterController jest ju� podpi�ty pod obiekt
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Wyci�gamy warto�ci, aby mo�liwe by�o ich efektywniejsze wykorzystanie w funkcji
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Dzi�ki parametrowi playerGrounded mo�emy doda� zachowania, kt�re b�d�
        // mog�y by� uruchomione dla ka�dego z dw�ch stan�w
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Zmieniamy spos�b poruszania si� postaci
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Obracanie postaci wok� osi Y
        float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * horizontalRotation);

        // Skok
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // Pr�dko�� swobodnego opadania zgodnie ze wzorem y = (1/2 * g) * t^2
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
