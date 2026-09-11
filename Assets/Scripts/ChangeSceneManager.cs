using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// This program manages the transition between scenes.
/// </summary>
public class ChangeSceneManager : MonoBehaviour
{
    public void change_button()
    {
        SceneManager.LoadScene("SetArmValue");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("After");
    }
}
