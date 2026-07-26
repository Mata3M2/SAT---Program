using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeightManager : MonoBehaviour
{
     // Variable to store the weight value       
    

    public enum WeightType  {Like = 0, Repost=1, Bookmark=2, Comment=3} //Enumeration type(enum is a special data type that enables for a variable to be a set of predefined constants)

    [Header("Current Mode）")]
    public WeightType currentWeightIndex; // Current weight type
    
    [Header("Weight Values")]
    public float[] weightValues = new float[4] { 0.2f, 0.5f, 0.3f, 0.8f }; // Array to store weight values for each type

    public float likeScore = 0.2f;
    public float repostScore = 0.5f;
    public float bookmarkScore = 0.3f;
    public float commentScore = 0.8f;
    
    public WeightDisplay weightDisplay; // Reference to the WeightDisplay script

    public event System.Action<WeightType> OnWeightTypeChanged;

    private string GetText()
    {
        return weightDisplay.weightText.text;
    }

    // Update is called once per frame
    void Update()
    {
        weightDisplay.weightText.text  = "(Weight:" + likeScore + ")";
        weightDisplay.score_Like.text = "Like: " + likeScore;
        //weightDisplay.score_Repost.text = "Repost: " + repostScore;
        //weightDisplay.score_Bookmark.text = "Bookmark: " + bookmarkScore;
        //weightDisplay.score_Comment.text = "Comment: " + commentScore;

        

         
    }
    public void OnNextButton()
        {
            int value = (int)currentWeightIndex;
            value = (value + 1 ) % System.Enum.GetValues(typeof(WeightType)).Length; //Moving to next WeightType, e.g: Like → repost...
            currentWeightIndex = (WeightType)value;
            Debug.Log(currentWeightIndex);

        }
    
}
