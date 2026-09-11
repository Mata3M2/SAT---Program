using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

/// <summary>
/// This program transitions from the weight setting scene to the arm setting scene.
/// </summary>

public class SceneChange2 : MonoBehaviour
{
    public void change_scene2()
    {
        SceneManager.LoadScene("ArmSelect");
    }
}