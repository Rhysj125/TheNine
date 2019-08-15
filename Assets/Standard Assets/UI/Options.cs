using Game.Settings;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject mainMenu;

    public void ToggleEnemySpawning(Toggle toggle)
    {
        Settings.SpawnEnemies = toggle.isOn;
        Debug.Log(Settings.SpawnEnemies);
    }

    public void ReturnMainMenu()
    {
        mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
