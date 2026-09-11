using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The value is obtained from a user interface operated via a floating slider, with the figure rounded to two decimal places.
/// The value obtained here is sent to the Weight Manager, which then formats it for transfer to a ScriptableObject and enables the manipulation of arrays (reposts, bookmarks, and comments).
/// </summary>

public class WeightSliderController : MonoBehaviour
{
    // Slider component to control the weight value
    public Slider weightSlider;

    // Current weight value
    public float weight;
    public WeightManager weightManager; 
    public Text weightText; //This is not being taken from the weight display; instead, it is being attached directly from the object itself.
   

    void Start()
    {
        // Initialize the weight value based on the slider's initial value
        if (weightSlider != null) 
        {
            weight = weightSlider.value;
            weightSlider.onValueChanged.AddListener(OnWeightChanged); //When the slider moves, it calls the `OnWeightChanged` flow; be careful, because without this, the weight won't update when you move the slider.
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
            weightText.text = "(Weight: " + weight + ")"; //Display the weight value after it has been changed
        }
    }
}
