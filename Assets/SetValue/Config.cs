using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
ここのスクリプトでは、スクリプタブルオブジェクトという、シーンを切り替えても数値が保存される方法を使っています。
これによってシーンが移動しても、例えば各ウェイトタイプのウェイトバリューが別のシーンで使えたりします。
*/

[CreateAssetMenu(menuName = "WeightValue/Config", fileName = "WeightValue")]
public class Config : ScriptableObject

{
    [Header("WeightType Setting")]
    //WeightManager の中に書いた WeightType という Enum を、型として使います。
    public WeightManager.WeightType currentType;

    [Header("WeightScore")]
    public float[] weightValues = new float[4];
}
