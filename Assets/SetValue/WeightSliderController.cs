using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightSliderController : MonoBehaviour
{
    // Slider component to control the weight value
    public Slider weightSlider;

    // Current weight value
    public float weight;
    public WeightManager weightManager; 
    public Text weightText; //これはウェイトディスプレイから取っているのではなく、そのままのオブジェクトからアタッチしている。
   

    void Start()
    {
        // Initialize the weight value based on the slider's initial value
        if (weightSlider != null) 
        {
            weight = weightSlider.value;
            weightSlider.onValueChanged.AddListener(OnWeightChanged); //スライダーが動いたら OnWeightChanged フローを呼んでいる, これがないと、スライダーを動かしてもウェイトが更新されないから気をつけて。
            OnWeightChanged(weight);
        }
    }

    void Update()
    {
       
    }

    // Called when the slider value changes
    public void OnWeightChanged(float value)
    {
        // Set the weight to the slider's value
        weight = Mathf.Round(value * 10f) / 10f;

        if (weightText != null)
        {
            weight = float.Parse(weight.ToString("F1")); // Format to 1 decimal place
            weightText.text = "(Weight: " + weight + ")"; //ウェイトの値を変化させた後に、ここで表示していると
        }
    }
}
