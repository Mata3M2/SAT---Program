using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This program is responsible for displaying the scoreboard values ​​that appear on the screen when selecting an arm
/// This displays the scoreboard values ​​that appear on the screen when selecting an arm.
///
/// It retrieves the data from `Config.cs` to ensure that the settings applied after configuring the weights are reflected.
/// </summary>



public class ScoreBoard : MonoBehaviour
{
        //The value is retrieved from the configuration, and the value specified within that configuration originates 
        // from the numerical output generated when the Weight Manager's `OnNextButton()` was determined.
        // Visualise: ScoreBoard ← Config ← WeightManager ← WeightSliderController
         [SerializeField] private Config weightConfig;  
        public Text[] score; 
        public float[] scoreValues = new float[4];
        void Update()
    {
        scoreValues[0] = weightConfig.weightValues[0];
        score[0].text = "Like: " + scoreValues[0].ToString("F1"); //Round to one decimal place

        scoreValues[1] = weightConfig.weightValues[1];
        score[1].text = "Repost: " + scoreValues[1].ToString("F1");

        scoreValues[2] = weightConfig.weightValues[2];
        score[2].text = "Bookmark: " + scoreValues[2].ToString("F1");

        scoreValues[3] = weightConfig.weightValues[3];
        score[3].text = "Comment: " + scoreValues[3].ToString("F1");
        
    }

}
    