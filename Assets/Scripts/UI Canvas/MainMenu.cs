using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private int scenes;
    public void Gaming()
    {
        SceneManager.LoadScene(scenes);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
