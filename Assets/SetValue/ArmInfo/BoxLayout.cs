using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxLayout : MonoBehaviour
{
    [SerializeField] private ArmValueSO armValueSO; //アームのプレハブをアタッチする
    [SerializeField] private ArmInputBox[] armInputBoxes; //アームのプレハブをアタッチする
    private int activeArmCount = 1; //アクティブなアームの数を追跡する変数
    private void Start()
    {
        UpdateLayout(); //初期化時にアームの表示を更新する
    }

    public void AddArm()
    {
        if (activeArmCount >= armInputBoxes.Length)
        {
            return; //アクティブなアームの数が最大数に達している場合は、追加しない
        }

        activeArmCount++;
        UpdateLayout();
    }

    public void DeleteArm()
    {
        if(activeArmCount <= 0)
        {
            return; //アクティブなアームの数が1以下の場合は、削除しない
        }
        activeArmCount--;
        UpdateLayout();
    }

    private void UpdateLayout() //アクティブなアームの数に応じて、アームの表示を更新する
    {
        for (int i = 0; i < armInputBoxes.Length; i++)
        {
            bool isActive = i < activeArmCount;
            //UIの表情・非表示
            armInputBoxes[i].gameObject.SetActive(isActive); 
            //SO側の有効/無効の設定
            armValueSO.arms[i].isActive = isActive;

        }
    }
}
