using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// InputToSOController is a controller designed to save values ​​entered via ArmInputBox into an ArmValueSO.
/// It serves to link the values ​​obtained from the input field to the ScriptableObject.
/// </summary>
public class InputToSOController : MonoBehaviour
{
    [SerializeField] public ArmInputBox[] inputBoxes;
    [SerializeField] private ArmValueSO armValueSO; // Add a reference to the destination ScriptableObject.

    [SerializeField] private ArmScoreCalculator armScoreCalculator;
    [SerializeField] private TMP_Text errorMessageText; // Add a reference to the error message text.


    public void SaveAll()
    {
        for (int i = 0; i < inputBoxes.Length; i++)
        {
            int[] values = inputBoxes[i].GetInputValues();
            
            armValueSO.arms[i].likeAmount = values[0];
            armValueSO.arms[i].repostAmount = values[1];
            armValueSO.arms[i].bookmarkAmount = values[2];
            armValueSO.arms[i].commentAmount = values[3];
        }
    }

    public void SaveAndCalculate()
    {   
        errorMessageText.text = ""; // Clear the error message text before checking for empty input fields.


        for (int i = 0; i < inputBoxes.Length; i++)
        {
            if (!armValueSO.arms[i].isActive) // Only check input fields for active arms.
            {
                continue; // Skip the calculation for inactive arms.
            }
            
            if (inputBoxes[i].IsEmptyInputInInpufields())
            {
                errorMessageText.text = "Please fill in all input fields."; // Display an error message if any input field is empty.
                return; // Exit the method without saving or calculating.
            }
        } 

        
        SaveAll(); // First, save all input values.
        armScoreCalculator.CalculateArmScores(); // Next, calculate the score.
    }
    /*
    By saving the data once before performing the calculation, 
    the weight values ​​and the input values ​​are now calculated in the correct order.
    */
    }

//armValueSO.armValues[0] = int.Parse(inputField[0].text);
      