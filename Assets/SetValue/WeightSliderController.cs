using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightSliderController : MonoBehaviour
{
    // Slider component to control the weight value
    public Slider weightSlider;

    // Current weight value
    private float weight;
    public WeightManager weightManager; 

    void Start()
    {
        // Initialize the weight value based on the slider's initial value
        weight = weightSlider.value;
    }

    // Called when the slider value changes
    public void OnWeightChanged(float value)
    {
        // Set the weight to the slider's value
        weight = value;
        weight = float.Parse(weight.ToString("F1")); // Format to 1 decimal place
        weightManager.likeScore = weight;


        Debug.Log("現在の重み: " + weight);
    }
}