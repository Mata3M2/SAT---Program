using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
