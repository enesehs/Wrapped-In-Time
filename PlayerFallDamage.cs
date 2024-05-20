using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float fallThreshold = 0.2f; // Hasar al�nacak minimum d��me y�ksekli�i
    public float damagePerMeter = 10f; // Her metre i�in al�nacak hasar miktar�

    private float startYPosition; // D��meye ba�lad��� y konumu
    private bool isFalling; // Karakter d���yor mu?

    void Update()
    {
        // Karakterin zeminle temas halinde olup olmad���n� kontrol et
        if (IsGrounded())
        {
            if (isFalling)
            {
                float fallDistance = startYPosition - transform.position.y;
                if (fallDistance > fallThreshold)
                {
                    float damage = (fallDistance - fallThreshold) * damagePerMeter;
                    GetComponent<Health>().TakeDamage(damage);
                }

                isFalling = false; // Karakter yere de�di, d��me bitti
            }
        }
        else
        {
            if (!isFalling)
            {
                startYPosition = transform.position.y;
                isFalling = true; // Karakter havada, d��me ba�lad�
            }
        }
    }

    // Karakterin zeminle temas halinde olup olmad���n� kontrol eden fonksiyon
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
