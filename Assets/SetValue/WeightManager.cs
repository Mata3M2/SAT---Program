using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public float[] weightValues = new float[4] { 0.2f, 0.5f, 0.3f, 0.8f }; // ここで各 WeightType のフロートを扱っている, なので、ボタンで数値を確定したら、この数値が動くという仕組みだ。

    
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

#region Button Attributes
    public void OnNextButton()
        {
            float currentSliderValue = sliderController.weight;

            #region WeightSetting of Each WeightTpye
            switch (currentWeightIndex) //ここは重み付けをするときにスコアを設定するプログラムです
            {
                case WeightType.Like: //数値を確定する
                //★Config（ScriptableObject）の配列[0]に保存
                //
                if (weightConfig != null) weightConfig.weightValues[0] = currentSliderValue;

                weightValues[0] = currentSliderValue; 
                weight = sliderController.weightSlider.value; //ウェイトスライダーの値をゲットしてる
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

            //ここに[パネルの移動]や[次のシーンへ移動する]処理が入っている。
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
        #endregion
    
}
