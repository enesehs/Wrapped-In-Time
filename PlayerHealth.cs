using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; // Karakterin maksimum sa�l���
    private float currentHealth; // Karakterin mevcut sa�l���
    public GameManagerScript gameManager;
    public Image bloodSplatterImage; // Kan lekesi imgesi referans�
    public Slider healthBar; // Can bar� referans�

    private Color bloodSplatterColor; // Kan lekesi imgesi ba�lang�� rengi

    void Start()
    {
        currentHealth = maxHealth; // Ba�lang��ta maksimum sa�l�kla ba�la
        // Kan lekesi imgesi ba�lang�� rengini al
        if (bloodSplatterImage != null)
        {
            bloodSplatterColor = bloodSplatterImage.color;
            bloodSplatterColor.a = 0; // Ba�lang��ta tamamen saydam
            bloodSplatterImage.color = bloodSplatterColor;
        }

        // Can bar�n� maksimum sa�l��a ayarla
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    // Hasar al�nd���nda �a�r�lan fonksiyon
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage taken: " + damage + ". Current health: " + currentHealth);

        // Kan lekesi g�r�n�rl���n� art�r
        if (bloodSplatterImage != null)
        {
            StopAllCoroutines(); // Mevcut t�m coroutineleri durdur
            bloodSplatterImage.color = bloodSplatterColor;
            StartCoroutine(FadeBloodSplatter()); // Kan lekesini yava��a azaltmak i�in coroutine ba�lat
        }

        // Can bar�n� g�ncelle
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    // Karakter �ld���nde �a�r�lan fonksiyon
    void Die()
    {
        Debug.Log("Character died.");
        gameManager.gameOver();
        StartCoroutine(DisablePlayerMovementAfterDelay(0.5f));
        if (healthBar != null)
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.mass = 10f; // Karakterin a��rl���n� belirleyin
            rb.drag = 2f; // S�rt�nmeyi ayarlay�n
            rb.angularDrag = 1.05f; // D�nel s�rt�nmeyi ayarlay�n
        }
       
        Debug.Log("Fizik Var");
        

    }

    IEnumerator DisablePlayerMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
    }



    // Kan lekesini yava��a azaltmak i�in coroutine
    IEnumerator FadeBloodSplatter()
    {
        float fadeDuration = 2f; // Kan lekesinin kaybolma s�resi
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            bloodSplatterColor.a = Mathf.Lerp(bloodSplatterImage.color.a, 0, elapsedTime / fadeDuration);
            bloodSplatterImage.color = bloodSplatterColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        bloodSplatterColor.a = 0;
        bloodSplatterImage.color = bloodSplatterColor;
    }
}
