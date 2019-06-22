using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void PlayGameBTN(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void QuitGameBTN()
    {
        Application.Quit();
    }
}
