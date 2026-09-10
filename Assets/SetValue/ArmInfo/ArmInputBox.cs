using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/*
This program aggregates the Like, Repost, Bookmark, and comment values ​​for each ArmData (individual arm).
By grouping and bundling these numerical values ​​for the arms, it becomes easier to configure the settings for each value later on.
*/

public class ArmInputBox : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] inputFields;

    //This method fixes a bug that occurs when nothing has been entered into the input field.
    public bool IsEmptyInputInInpufields() //It is designed to return `true` if even one of the four input fields has nothing typed in it (i.e., the selection is empty).
    {
        for(int i = 0; i< inputFields.Length; i++)
        {
            if(string.IsNullOrWhiteSpace(inputFields[i].text))
            {
                return true;
            }
        }
        return false;
    }
    public int[] GetInputValues()
    {
        int[] values = new int[4];

        for (int i = 0; i < inputFields.Length; i++)
        {
            if (int.TryParse(inputFields[i].text, out int value)) //To prevent the program from stopping due to errors, I am enhancing its robustness; it is now designed to ignore any input that is not a number.
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
