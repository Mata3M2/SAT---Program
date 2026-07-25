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
    private WeightType currentWeightType = WeightType.Like; // Default weight type
    public void OnNextButton()
    {
        currentWeightType = WeightType.Like;
        
        }

    void Start()
    {
        likeScore = 0.2f; // Initialize the weight value
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("現在の重み: " + likeScore);
        weightDisplay.weightText.text = "(Weight :" + likeScore + ")";
        weightDisplay.scoreBoard.text = "Like: " + likeScore;

         
    }

    
}
