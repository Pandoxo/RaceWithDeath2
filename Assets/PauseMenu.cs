using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called oifnce before the first execution of Update after the MonoBehaviour is created
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    

    void FixedUpdate()
    {

    }


    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused  = true;

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void LoadMainMenu()
    {
        Debug.Log("Loading menu");
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }
    void OnPauseMenu()
    {
        if (GameIsPaused)
        {
            Resume();
        }else{
            Pause();
        }
        AudioListener.pause = !AudioListener.pause;
    }
}
 