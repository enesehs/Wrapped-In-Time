using UnityEngine;

public class BoxMover : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Kutunun hareket hızı
    public Vector3 targetPosition; // Kutunun hareket edeceği konum (isteğe bağlı)
    public float dayNightCycleSpeed = 10.0f; // Gün-gece döngüsünün hızı
    public Transform character; // Karakter referansı

    private bool isMovingForward = false; // Kutu ileriye doğru mu hareket ediyor?
    private bool isMovingBackward = false; // Kutu geriye doğru mu hareket ediyor?
    private bool isDayNightCycleForward = false; // Gün-gece döngüsü ileriye doğru mu gidiyor?
    private bool isDayNightCycleBackward = false; // Gün-gece döngüsü geriye doğru mu gidiyor?
    private Light directionalLight; // Directional Light referansı
    private Vector3 characterOffset; // Karakterin kutuya göre pozisyonu

    void Start()
    {
        // Directional Light'ı bul ve referansını al
        GameObject lightObject = GameObject.FindWithTag("DayNight");
        if (lightObject != null)
        {
            directionalLight = lightObject.GetComponent<Light>();
        }

        // Karakterin başlangıç pozisyonunu ayarla
        if (character != null)
        {
            characterOffset = character.position - transform.position;
        }
    }

    void Update()
    {
        // Hareket kontrolleri
        if (Input.GetKey(KeyCode.Q))
        {
            isMovingForward = true;
            isMovingBackward = false;
            isDayNightCycleForward = true;
            isDayNightCycleBackward = false;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            isMovingForward = false;
            isMovingBackward = true;
            isDayNightCycleForward = false;
            isDayNightCycleBackward = true;
        }
        else
        {
            isMovingForward = false;
            isMovingBackward = false;
            isDayNightCycleForward = false;
            isDayNightCycleBackward = false;
        }

        // Hareket güncellemeleri
        if (isMovingForward)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // Hedef konuma ulaşıldıysa dur
            if (targetPosition != Vector3.zero && Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMovingForward = false;
            }
        }
        else if (isMovingBackward)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

            // Başlangıç ​​noktasına ulaşıldıysa dur
            if (Vector3.Distance(transform.position, Vector3.zero) < 0.1f)
            {
                isMovingBackward = false;
            }
        }

        // Karakterin pozisyonunu güncelle
        

        // Gün-gece döngüsü güncellemeleri
        if (directionalLight != null)
        {
            if (isDayNightCycleForward)
            {
                directionalLight.transform.Rotate(Vector3.right * dayNightCycleSpeed * Time.deltaTime);
            }
            else if (isDayNightCycleBackward)
            {
                directionalLight.transform.Rotate(Vector3.left * dayNightCycleSpeed * Time.deltaTime);
            }
        }
    }
}
