using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightManager : MonoBehaviour
{
    public float likeScore; // Variable to store the weight value       
    public WeightDisplay weightDisplay; // Reference to the WeightDisplay script

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("現在の重み: " + likeScore);
        weightDisplay.weightText.text = "(Weight :" + likeScore + ")";
    }
}
