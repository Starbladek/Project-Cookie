using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public void Playgame()
    {
        SceneManager.LoadScene("Michael", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
