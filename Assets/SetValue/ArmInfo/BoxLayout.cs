using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxLayout : MonoBehaviour
{
    public GameObject Arm;
    void Start()
    {
        Instantiate(Arm, transform.position, Quaternion.identity);
    }

    public void AddArm()
    {
        Debug.Log("AddArm");
    }
}
