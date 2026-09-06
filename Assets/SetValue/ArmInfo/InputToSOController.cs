using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/*
InputToSOControllerは、ArmInputBoxから入力された値をArmValueSOに保存するためのコントローラーです。
インプットフィールドから得た値をスクリプタブルオブジェクトにつなげる役割を持っています。
*/
public class InputToSOController : MonoBehaviour
{
    [SerializeField] public ArmInputBox[] inputBoxes; // ArmInputBoxの配列を追加
    [SerializeField] private ArmValueSO armValueSO; // 保存先のScriptableObjectの参照を追加

    [SerializeField] private ArmScoreCalculator armScoreCalculator; // ArmScoreCalculatorの参照を追加


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
        SaveAll(); // First, save all input values.
        armScoreCalculator.CalculateArmScores(); // Next, calculate the score.
    }
    /*
    By saving the data once before performing the calculation, 
    the weight values ​​and the input values ​​are now calculated in the correct order.
    */
    }

//armValueSO.armValues[0] = int.Parse(inputField[0].text);
      