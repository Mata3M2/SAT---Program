using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/*
このプログラムは、各 ArmData（それぞれのアーム）の Like、Repost、Bookmark、コメントの値を一塊にするためのプログラムです。
アームの数値をグループ化・バンドル化してまとめることによって、後で各アームの各数値の設定がしやすくなります。
*/

public class ArmInputBox : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] inputFields;

    public int[] GetInputValues()
    {
        int[] values = new int[4];

        for (int i = 0; i < inputFields.Length; i++)
        {
            if (int.TryParse(inputFields[i].text, out int value)) //エラーでプログラムが止まらないため、ロバストネスを強化しています。入力された数値が数字でなければ無視するようになっています。
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
