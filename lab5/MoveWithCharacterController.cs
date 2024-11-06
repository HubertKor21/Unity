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

    private float rotationSpeed = 700f; // Prêdkoœæ obracania postaci (g³ównie w osi Y)

    private void Start()
    {
        // Zak³adamy, ¿e komponent CharacterController jest ju¿ podpiêty pod obiekt
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Wyci¹gamy wartoœci, aby mo¿liwe by³o ich efektywniejsze wykorzystanie w funkcji
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Dziêki parametrowi playerGrounded mo¿emy dodaæ zachowania, które bêd¹
        // mog³y byæ uruchomione dla ka¿dego z dwóch stanów
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Zmieniamy sposób poruszania siê postaci
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Obracanie postaci wokó³ osi Y
        float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * horizontalRotation);

        // Skok
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // Prêdkoœæ swobodnego opadania zgodnie ze wzorem y = (1/2 * g) * t^2
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
