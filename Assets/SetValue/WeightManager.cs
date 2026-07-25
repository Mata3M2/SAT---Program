using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightManager : MonoBehaviour
{
    public float likeScore; // Variable to store the weight value       
    public WeightDisplay weightDisplay; // Reference to the WeightDisplay script

    public enum WeightType //Enumeration type(enum is a special data type that enables for a variable to be a set of predefined constants)
{
    Like, 
    Repost,
    Bookmark,
    Comment
}
    private int currentWeightIndex = 0; // Default weight type [Like]
   

    void Start()
    {
        likeScore = 0.2f; // Initialize the weight value
    }

    // Update is called once per frame
    void Update()
    {
        weightDisplay.weightText.text  = "(Weight:" + likeScore + ")";
        weightDisplay.scoreBoard.text = "Like: " + likeScore;

        

         
    }
    public void OnNextButton()
        {
            currentWeightIndex = (currentWeightIndex + 1) % System.Enum.GetValues(typeof(WeightType)).Length;
            Debug.Log(currentWeightIndex + " MA");

        }
    
}
