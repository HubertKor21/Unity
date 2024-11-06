using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f; // K¹t otwarcia drzwi (w stopniach)
    public float openSpeed = 2f;  // Szybkoœæ otwierania (im wiêksza wartoœæ, tym szybciej)
    public Transform player;      // Gracz (mo¿esz przypisaæ przez Inspector)

    private bool isOpening = false; // Czy drzwi siê otwieraj¹
    private bool isClosing = false; // Czy drzwi siê zamykaj¹
    private Quaternion closedRotation; // Rotacja drzwi, gdy s¹ zamkniête
    private Quaternion openRotation;   // Rotacja drzwi, gdy s¹ otwarte

    void Start()
    {
        // Zapisujemy oryginaln¹ rotacjê drzwi
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + openAngle, transform.rotation.eulerAngles.z);
    }

    void Update()
    {
        // Sprawdzamy, czy gracz jest w pobli¿u drzwi
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < 3f) // Zasiêg wykrywania gracza (mo¿esz dostosowaæ wartoœæ)
        {
            if (!isOpening)
            {
                StartOpening();
            }
        }
        else
        {
            if (!isClosing)
            {
                StartClosing();
            }
        }

        // P³ynne otwieranie
        if (isOpening)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);

            // Sprawdzamy, czy drzwi osi¹gnê³y pe³ne otwarcie
            if (Quaternion.Angle(transform.rotation, openRotation) < 1f)
            {
                isOpening = false;
            }
        }

        // P³ynne zamykanie
        if (isClosing)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);

            // Sprawdzamy, czy drzwi osi¹gnê³y pe³ne zamkniêcie
            if (Quaternion.Angle(transform.rotation, closedRotation) < 1f)
            {
                isClosing = false;
            }
        }
    }

    void StartOpening()
    {
        isOpening = true;
        isClosing = false;
    }

    void StartClosing()
    {
        isClosing = true;
        isOpening = false;
    }
}
