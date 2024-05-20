using UnityEngine;

public class BoxMoverDef : MonoBehaviour
{
    public float moveSpeedX = 0f; // Kutunun x eksenindeki hareket hýzý
    public float moveSpeedZ = 0f; // Kutunun z eksenindeki hareket hýzý
    public float moveSpeedY = 0f; // Kutunun y eksenindeki hareket hýzý
    public float moveDistance = 0f; // Kutunun hareket edeceði mesafe

    private Vector3 startPosition; // Kutunun baþlangýç pozisyonu
    private bool movingRight = true; // Saða doðru hareket ediyor mu?
    private bool movingForward = true; // Ýleri doðru hareket ediyor mu?
    private bool movingUp = true; // Yukarý doðru hareket ediyor mu?

    void Start()
    {
        // Baþlangýç pozisyonunu kaydet
        startPosition = transform.position;
    }

    void Update()
    {
        // Sað veya sol yöne doðru hareket et
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeedX * Time.deltaTime);

            // Hedef sað noktaya ulaþtý mý kontrol et
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false; // Sol yöne geç
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeedX * Time.deltaTime);

            // Hedef sol noktaya ulaþtý mý kontrol et
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true; // Sað yöne geç
            }
        }

        // Ýleri veya geri yöne doðru hareket et
        if (movingForward)
        {
            transform.Translate(Vector3.forward * moveSpeedZ * Time.deltaTime);

            // Hedef ileri noktaya ulaþtý mý kontrol et
            if (transform.position.z >= startPosition.z + moveDistance)
            {
                movingForward = false; // Geri yöne geç
            }
        }
        else
        {
            transform.Translate(Vector3.back * moveSpeedZ * Time.deltaTime);

            // Hedef geri noktaya ulaþtý mý kontrol et
            if (transform.position.z <= startPosition.z - moveDistance)
            {
                movingForward = true; // Ýleri yöne geç
            }
        }

        // Yukarý veya aþaðý yöne doðru hareket et
        if (movingUp)
        {
            transform.Translate(Vector3.up * moveSpeedY * Time.deltaTime);

            // Hedef yukarý noktaya ulaþtý mý kontrol et
            if (transform.position.y >= startPosition.y + moveDistance)
            {
                movingUp = false; // Aþaðý yöne geç
            }
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeedY * Time.deltaTime);

            // Hedef aþaðý noktaya ulaþtý mý kontrol et
            if (transform.position.y <= startPosition.y - moveDistance)
            {
                movingUp = true; // Yukarý yöne geç
            }
        }
    }
}
