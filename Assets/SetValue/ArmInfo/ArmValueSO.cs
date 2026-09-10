using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
This program manages the individual arms.
For instance, it treats them as `arms[0] = A`.
`arms[0]` is the variable used to manage the value for Arm A.
`arms[1]` is the variable used to manage the value for Arm B.
By grouping the values ​​for each arm into an array in this way, it becomes easy to manage and manipulate the values ​​of each arm later on.

*/
[CreateAssetMenu(menuName = "Custom/ArmValueSO", fileName = "   ArmValueSO")]
public class ArmValueSO : ScriptableObject
{
    public ArmData[] arms = new ArmData[4];

    private void OnEnable()
    {
        for (int i = 0; i < arms.Length; i++)
        {
            if (arms[i] == null)
            {
                arms[i] = new ArmData();
            }
        }
        // Called when the ScriptableObject is enabled
    }
}