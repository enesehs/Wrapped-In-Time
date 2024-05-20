using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject gameOverUI;
    void Update()
    {

    }
    public void gameOver()
    {
        gameOverUI.SetActive(true);
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.UnlockCursor();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restarted");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quited");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void Nah()
    {
        SceneManager.LoadScene("Nah");
    }

}
