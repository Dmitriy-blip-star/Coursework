using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScripts : MonoBehaviour
{
    public void InGame()
    {
        SceneManager.LoadScene("GameLvl1");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        SceneManager.LoadScene("GameLvl2");
    }
}
