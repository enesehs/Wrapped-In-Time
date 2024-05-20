using UnityEngine;

public class BoxMoverDef : MonoBehaviour
{
    public float moveSpeedX = 0f; // Kutunun x eksenindeki hareket h�z�
    public float moveSpeedZ = 0f; // Kutunun z eksenindeki hareket h�z�
    public float moveSpeedY = 0f; // Kutunun y eksenindeki hareket h�z�
    public float moveDistance = 0f; // Kutunun hareket edece�i mesafe

    private Vector3 startPosition; // Kutunun ba�lang�� pozisyonu
    private bool movingRight = true; // Sa�a do�ru hareket ediyor mu?
    private bool movingForward = true; // �leri do�ru hareket ediyor mu?
    private bool movingUp = true; // Yukar� do�ru hareket ediyor mu?

    void Start()
    {
        // Ba�lang�� pozisyonunu kaydet
        startPosition = transform.position;
    }

    void Update()
    {
        // Sa� veya sol y�ne do�ru hareket et
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeedX * Time.deltaTime);

            // Hedef sa� noktaya ula�t� m� kontrol et
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false; // Sol y�ne ge�
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeedX * Time.deltaTime);

            // Hedef sol noktaya ula�t� m� kontrol et
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true; // Sa� y�ne ge�
            }
        }

        // �leri veya geri y�ne do�ru hareket et
        if (movingForward)
        {
            transform.Translate(Vector3.forward * moveSpeedZ * Time.deltaTime);

            // Hedef ileri noktaya ula�t� m� kontrol et
            if (transform.position.z >= startPosition.z + moveDistance)
            {
                movingForward = false; // Geri y�ne ge�
            }
        }
        else
        {
            transform.Translate(Vector3.back * moveSpeedZ * Time.deltaTime);

            // Hedef geri noktaya ula�t� m� kontrol et
            if (transform.position.z <= startPosition.z - moveDistance)
            {
                movingForward = true; // �leri y�ne ge�
            }
        }

        // Yukar� veya a�a�� y�ne do�ru hareket et
        if (movingUp)
        {
            transform.Translate(Vector3.up * moveSpeedY * Time.deltaTime);

            // Hedef yukar� noktaya ula�t� m� kontrol et
            if (transform.position.y >= startPosition.y + moveDistance)
            {
                movingUp = false; // A�a�� y�ne ge�
            }
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeedY * Time.deltaTime);

            // Hedef a�a�� noktaya ula�t� m� kontrol et
            if (transform.position.y <= startPosition.y - moveDistance)
            {
                movingUp = true; // Yukar� y�ne ge�
            }
        }
    }
}
