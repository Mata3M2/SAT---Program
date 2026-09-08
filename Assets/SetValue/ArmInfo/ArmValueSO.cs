using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
各アームを管理するプログラムです
例えば、「arms[0] = A」として扱っています
arms[0]は、アームAの数値を管理するための変数です。
arms[1]は、アームBの数値を管理するための変数です。
このように、各アームの数値を配列としてまとめることで、後で各アームの数値を簡単に管理・操作することができます。

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
        // ScriptableObjectが有効化されたときに呼ばれる
        // 必要に応じて初期化処理を行う
    }
}