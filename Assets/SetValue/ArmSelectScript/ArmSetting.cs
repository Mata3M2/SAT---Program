using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSetting : MonoBehaviour
{
    public GameObject Arm;
    void Start()
    {
        Instantiate(Arm, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
