using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void Play()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Quit()
    {
        Application.Quit(); 
    }
}
