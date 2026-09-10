using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This program manages the weight values for each weight type and handles the transition to the next scene
/// Each weight (such as Like, Repost, etc.) is handled as a float value; the value adjusted via the "SliderWeight" 
/// is retrieved after being rounded to two decimal places. This value is then used within a ScriptableObject.
/// 
/// Here, I format the values ​​obtained from SliderWeight for transfer to a ScriptableObject and enable the 
/// manipulation of arrays (reposts, bookmarks, and comments)
/// </summary>

public class WeightManager : MonoBehaviour
{

     [SerializeField] private Config weightConfig;  
     public PanelManager panelManager;  
     public WeightSliderController sliderController;
     public ChangeSceneManager changeSceneManager;
    
    #region WeightType
    public enum WeightType  
    {
        Like = 0, 
        Repost=1, 
        Bookmark=2, 
        Comment=3, 
        ToNextPage=4} //Enumeration type(enum is a special data type that enables for a variable to be a set of predefined constants)
    #endregion

    [Header("Current Mode）")]
    public WeightType currentWeightIndex; // Current weight type
    
    [Header("Weight Values")]
    public float[] weightValues = new float[4] { 0.2f, 0.5f, 0.3f, 0.8f }; // This is where the float value for each WeightType is handled; the mechanism is designed so that the value updates once you confirm the number using the button.

    
    public WeightDisplay weightDisplay; // Reference to the WeightDisplay script
    public float weight;


    public event System.Action<WeightType> OnWeightTypeChanged;
    public Text score_Like; //Object to be attached directly
    public Text score_Repost;
    public Text score_Bookmark;
    public Text score_Comment;

    // Update is called once per frame
    void Start()
    {
        if (sliderController.weightSlider != null) 
        {
            weight = sliderController.weightSlider.value;
            sliderController.weightSlider.onValueChanged.AddListener(sliderController.OnWeightChanged); //スライダーが動いたら OnWeightChanged フローを呼んでいる, これがないと、スライダーを動かしてもウェイトが更新されないから気をつけて。
            sliderController.OnWeightChanged(weight);
        }
    }

#region Button Attributes
    public void OnNextButton()
        {
            float currentSliderValue = sliderController.weight;

            #region WeightSetting of Each WeightTpye
            switch (currentWeightIndex) //This is a program that sets scores when applying weights.
            {
                case WeightType.Like: //Finalize the numerical values.
                //★Save to index [0] of the Config (ScriptableObject) array.
                //
                if (weightConfig != null) weightConfig.weightValues[0] = currentSliderValue;

                weightValues[0] = currentSliderValue; 
                weight = sliderController.weightSlider.value; //Get the value of the weight slider
                weight = float.Parse(weight.ToString("F1"));
                score_Like.text = "Like: " + weight;
                               
                break;

                case WeightType.Repost:
                if (weightConfig != null) weightConfig.weightValues[1] = currentSliderValue;

                weightValues[1] = currentSliderValue;
                weight = sliderController.weightSlider.value;
                weight = float.Parse(weight.ToString("F1"));
                score_Repost.text = "Repost: " + weight;
                break;

                case WeightType.Bookmark:
                if (weightConfig != null) weightConfig.weightValues[2] = currentSliderValue;


                weight = sliderController.weightSlider.value; 
                weight = float.Parse(weight.ToString("F1"));
                score_Bookmark.text = "Bookmark: " + weight;
                break;

                case WeightType.Comment:
                if (weightConfig != null) weightConfig.weightValues[3] = currentSliderValue;
              
                weightValues[3] = currentSliderValue;
                weight = sliderController.weightSlider.value; 
                weight = float.Parse(weight.ToString("F1"));
                score_Comment.text = "Comment: " + weight;
                break;
                
            }
            #endregion

            //The processing for [Move Panel] or [Move to Next Scene] is included here.
            int value = (int)currentWeightIndex; //This program transitions to the next `Enum` value; specifically, when the button is pressed, it displays the next variable defined within the `public Enum WeightType` shown above.
            value = (value + 1 ) % System.Enum.GetValues(typeof(WeightType)).Length; //Moving to next WeightType, e.g: Like → repost...
            currentWeightIndex = (WeightType)value;

            Debug.Log(currentWeightIndex);

            if (panelManager != null)
            {
            panelManager.RefreshPanels();
            }
            else if (panelManager == null)
        {
            Debug.Log("Panel is dosen't attached");
        }

        }
        #endregion
    
}
