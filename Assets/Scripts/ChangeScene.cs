using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void changeS()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void sair()
    {
        Application.Quit();
    }
}
