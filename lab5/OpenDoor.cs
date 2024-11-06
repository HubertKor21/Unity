using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f; // K�t otwarcia drzwi (w stopniach)
    public float openSpeed = 2f;  // Szybko�� otwierania (im wi�ksza warto��, tym szybciej)
    public Transform player;      // Gracz (mo�esz przypisa� przez Inspector)

    private bool isOpening = false; // Czy drzwi si� otwieraj�
    private bool isClosing = false; // Czy drzwi si� zamykaj�
    private Quaternion closedRotation; // Rotacja drzwi, gdy s� zamkni�te
    private Quaternion openRotation;   // Rotacja drzwi, gdy s� otwarte

    void Start()
    {
        // Zapisujemy oryginaln� rotacj� drzwi
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + openAngle, transform.rotation.eulerAngles.z);
    }

    void Update()
    {
        // Sprawdzamy, czy gracz jest w pobli�u drzwi
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < 3f) // Zasi�g wykrywania gracza (mo�esz dostosowa� warto��)
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

        // P�ynne otwieranie
        if (isOpening)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);

            // Sprawdzamy, czy drzwi osi�gn�y pe�ne otwarcie
            if (Quaternion.Angle(transform.rotation, openRotation) < 1f)
            {
                isOpening = false;
            }
        }

        // P�ynne zamykanie
        if (isClosing)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);

            // Sprawdzamy, czy drzwi osi�gn�y pe�ne zamkni�cie
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
