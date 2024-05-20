using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float fallThreshold = 0.2f; // Hasar alýnacak minimum düþme yüksekliði
    public float damagePerMeter = 10f; // Her metre için alýnacak hasar miktarý

    private float startYPosition; // Düþmeye baþladýðý y konumu
    private bool isFalling; // Karakter düþüyor mu?

    void Update()
    {
        // Karakterin zeminle temas halinde olup olmadýðýný kontrol et
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

                isFalling = false; // Karakter yere deðdi, düþme bitti
            }
        }
        else
        {
            if (!isFalling)
            {
                startYPosition = transform.position.y;
                isFalling = true; // Karakter havada, düþme baþladý
            }
        }
    }

    // Karakterin zeminle temas halinde olup olmadýðýný kontrol eden fonksiyon
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
