using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    // Bu fonksiyon, karakterin trigger boxa girdiðinde çaðrýlýr
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Main 1");

    }
}
