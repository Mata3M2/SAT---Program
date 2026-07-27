using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeightManager : MonoBehaviour
{
     // Variable to store the weight value   
     public PanelManager panelManager;  
     public WeightSliderController sliderController;
     public ChangeSceneManager changeSceneManager;
    

    public enum WeightType  {Like = 0, Repost=1, Bookmark=2, Comment=3, ToNextPage=4} //Enumeration type(enum is a special data type that enables for a variable to be a set of predefined constants)

    [Header("Current Mode）")]
    public WeightType currentWeightIndex; // Current weight type
    
    [Header("Weight Values")]
    public float[] weightValues = new float[4] { 0.2f, 0.5f, 0.3f, 0.8f }; // Array to store weight values for each type

    
    public WeightDisplay weightDisplay; // Reference to the WeightDisplay script
    public float weight;


    public event System.Action<WeightType> OnWeightTypeChanged;
    public Text score_Like; //オブジェクトを直接アタッチする
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
    public void OnNextButton()
        {
            float currentSliderValue = sliderController.weight;
            
            switch (currentWeightIndex) //ここは重み付けをするときにスコアを設定するプログラムです
            {
                case WeightType.Like: //数値を確定する
                weightValues[0] = currentSliderValue; 
                weight = sliderController.weightSlider.value; //ウェイトスライダーの値をゲットしてる
                weight = float.Parse(weight.ToString("F1"));
                score_Like.text = "Like: " + weight;
                               
                break;

                case WeightType.Repost:
                weightValues[1] = currentSliderValue;
                weight = sliderController.weightSlider.value;
                weight = float.Parse(weight.ToString("F1"));
                score_Repost.text = "Repost: " + weight;
                break;

                case WeightType.Bookmark:
                weight = sliderController.weightSlider.value; 
                weight = float.Parse(weight.ToString("F1"));
                score_Bookmark.text = "Bookmark: " + weight;
                break;

                case WeightType.Comment:
                weightValues[3] = currentSliderValue;
                weight = sliderController.weightSlider.value; 
                weight = float.Parse(weight.ToString("F1"));
                score_Comment.text = "Comment: " + weight;
                break;
                
                

            }
            

            
            int value = (int)currentWeightIndex; //次の Enum 値に遷移する（行っている）ので、上の public Enum WeightType の中にある Enum の変数、つまり次の変数を、ボタンを押したら表示するよっていうプログラムです。
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
    
}
