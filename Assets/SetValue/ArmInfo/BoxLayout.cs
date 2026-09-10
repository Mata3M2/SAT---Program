using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
/// <summary>
/// This class manages the layout of arm input boxes.
/// This program allows for the addition and removal of arms. Added arms are referenced, whereas arms that have been 
/// added but subsequently disabled are excluded from the calculation results.
/// 
/// The system is designed to continuously update this state within the update method.
/// </summary>
public class BoxLayout : MonoBehaviour
{
    [SerializeField] private ArmValueSO armValueSO;
    [SerializeField] private ArmInputBox[] armInputBoxes;
    private int activeArmCount = 2; //A variable that tracks the number of active arms.
    private void Start()
    {
        UpdateLayout(); //Update the arm display during initialization.
    }

    public void AddArm()
    {
        if (activeArmCount >= armInputBoxes.Length)
        {
            return; //Do not add more if the number of active arms has reached the maximum.
        }

        activeArmCount++;
        UpdateLayout();
    }

    public void DeleteArm()
    {
        if(activeArmCount <= 2)
        {
            return; //Do not delete if the number of active arms is 2 or less.
        }
        activeArmCount--;
        UpdateLayout();
    }

    private void UpdateLayout() //Update the display of the arms based on the number of active arms.
    {
        for (int i = 0; i < armInputBoxes.Length; i++)
        {
            bool isActive = i < activeArmCount;
            //UI Visibility (Show/Hide)
            armInputBoxes[i].gameObject.SetActive(isActive); 
            //Enable/Disable setting on the SO side
            armValueSO.arms[i].isActive = isActive;

        }
    }
}
