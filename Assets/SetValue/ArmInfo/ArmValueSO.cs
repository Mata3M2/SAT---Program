using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // ScriptableObjectが有効化されたときに呼ばれる
        // 必要に応じて初期化処理を行う
    }
}