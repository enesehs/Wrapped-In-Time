using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; // Karakterin maksimum saðlýðý
    private float currentHealth; // Karakterin mevcut saðlýðý
    public GameManagerScript gameManager;
    public Image bloodSplatterImage; // Kan lekesi imgesi referansý
    public Slider healthBar; // Can barý referansý

    private Color bloodSplatterColor; // Kan lekesi imgesi baþlangýç rengi

    void Start()
    {
        currentHealth = maxHealth; // Baþlangýçta maksimum saðlýkla baþla
        // Kan lekesi imgesi baþlangýç rengini al
        if (bloodSplatterImage != null)
        {
            bloodSplatterColor = bloodSplatterImage.color;
            bloodSplatterColor.a = 0; // Baþlangýçta tamamen saydam
            bloodSplatterImage.color = bloodSplatterColor;
        }

        // Can barýný maksimum saðlýða ayarla
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    // Hasar alýndýðýnda çaðrýlan fonksiyon
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage taken: " + damage + ". Current health: " + currentHealth);

        // Kan lekesi görünürlüðünü artýr
        if (bloodSplatterImage != null)
        {
            StopAllCoroutines(); // Mevcut tüm coroutineleri durdur
            bloodSplatterImage.color = bloodSplatterColor;
            StartCoroutine(FadeBloodSplatter()); // Kan lekesini yavaþça azaltmak için coroutine baþlat
        }

        // Can barýný güncelle
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    // Karakter öldüðünde çaðrýlan fonksiyon
    void Die()
    {
        Debug.Log("Character died.");
        gameManager.gameOver();
        StartCoroutine(DisablePlayerMovementAfterDelay(0.5f));
        if (healthBar != null)
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.mass = 10f; // Karakterin aðýrlýðýný belirleyin
            rb.drag = 2f; // Sürtünmeyi ayarlayýn
            rb.angularDrag = 1.05f; // Dönel sürtünmeyi ayarlayýn
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



    // Kan lekesini yavaþça azaltmak için coroutine
    IEnumerator FadeBloodSplatter()
    {
        float fadeDuration = 2f; // Kan lekesinin kaybolma süresi
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
