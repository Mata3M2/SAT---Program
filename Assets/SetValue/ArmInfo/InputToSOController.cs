using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputToSOController : MonoBehaviour
{
    [SerializeField] public ArmInputBox[] inputBoxes; // ArmInputBoxの配列を追加
    [SerializeField] private ArmValueSO armValueSO; // 保存先のScriptableObjectの参照を追加
    

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
}

//armValueSO.armValues[0] = int.Parse(inputField[0].text);
      