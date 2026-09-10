using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script utilizes "ScriptableObjects," a method that allows data values ​​to persist even when switching scenes.
/// This enables values—such as the weight settings for each weight type—to be used across different scenes.
/// </summary>

[CreateAssetMenu(menuName = "WeightValue/Config", fileName = "WeightValue")]
public class Config : ScriptableObject

{
    [Header("WeightType Setting")]
    //use the `WeightType` enum defined within `WeightManager` as a type
    public WeightManager.WeightType currentType;

    [Header("WeightScore")]
    public float[] weightValues = new float[4];
}


