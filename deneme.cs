using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    // Bu fonksiyon, karakterin trigger boxa girdi�inde �a�r�l�r
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Main 1");

    }
}
