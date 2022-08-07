using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public bool START;
    public bool END;
    public bool MAIN_MENU;
    public bool RESTART;

    private void Start()
    {
        Time.timeScale = 0.0f;
    }
    public void OnClickButton()
    {
        if (START||RESTART)
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1.0f;
        }

        if (END)
        {
            Application.Quit();

        }

        if (MAIN_MENU)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 0.0f;
        }
    }
}
