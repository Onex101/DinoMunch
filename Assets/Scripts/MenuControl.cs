using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void InstructionMenu()
    {
        SceneManager.LoadScene("Instructions");
    }

    // Not appropriate for a web build. Do not use.
    public void QuitGame()
    {
        Application.Quit();
    }
}
