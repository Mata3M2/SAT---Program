/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightSliderController : MonoBehaviour
{
    // UnityのSliderを入れる場所
    public Slider weightSlider;
    public WeightManager weightManager;

    // このスライダーがどの重みを担当するか（Inspectorで選択）
    public WeightType weightType;

    // 現在の重み
    public float weight;

    // ゲーム開始時に実行される
    void Start()
    {
        // Sliderの現在の値を取得
        weight = weightSlider.value;
        weightManager.SetWeight(weightType, weight);
    }

    // Sliderの値が変更されたときに実行される（Slider.OnValueChangedに登録）
    public void OnWeightChanged(float value)
    {
        weight = value;
        weightManager.SetWeight(weightType, value);
    }
}