using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;

    public void PlayGame()
    {
        ResetAllToDefault();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToOptions()
    {
        gameObject.SetActive(false);
        optionsMenu.SetActive(true);
    }

    private void ResetAllToDefault()
    {
        Level.ResetToDefault();
        Player.GetInstance().ResetToDefault();
    }
}
