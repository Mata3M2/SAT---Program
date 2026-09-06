using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArmInputBox : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] inputFields;

    public int[] GetInputValues()
    {
        int[] values = new int[4];

        for (int i = 0; i < inputFields.Length; i++)
        {
            if (int.TryParse(inputFields[i].text, out int value))
            {
                values[i] = value;
            }
            else
            {
                values[i] = 0;
            }
        }
        return values;
    }
}
