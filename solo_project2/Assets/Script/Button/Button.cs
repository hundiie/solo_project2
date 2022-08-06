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

    
    public void OnClickButton()
    {
        if (START||RESTART)
        {
            SceneManager.LoadScene(1);
        }

        if (END)
        {
            Application.Quit();
        }

        if (MAIN_MENU)
        {
            SceneManager.LoadScene(0);
        }
    }
}
