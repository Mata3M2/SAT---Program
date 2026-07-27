using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
/*
ここは、アームを選択する時の画面に出てくるスコアボードの数値を表示しているよ。

ウェイトを設定した後の設定が反映されるように、[Config.cs]から持ってきてます。
*/


public class ScoreBoard : MonoBehaviour
{
        //config から値を取ってきて、その config の中に書かれている値は、WeightマネージャーのOnNextButton()を決定した際に出力された数値から取ってきている。
        // Visualise: ScoreBoard ← Config ← WeightManager ← WeightSliderController
         [SerializeField] private Config weightConfig;  
        public Text[] score; 
        public float[] scoreValues = new float[4];
        void Update()
    {
        scoreValues[0] = weightConfig.weightValues[0];
        score[0].text = "Like: " + scoreValues[0].ToString("F1"); //小数第一位まで四捨五入をする

        scoreValues[1] = weightConfig.weightValues[1];
        score[1].text = "Like: " + scoreValues[1].ToString("F1");

        scoreValues[2] = weightConfig.weightValues[2];
        score[2].text = "Like: " + scoreValues[2].ToString("F1");

        scoreValues[3] = weightConfig.weightValues[3];
        score[3].text = "Like: " + scoreValues[3].ToString("F1");
        
    }

}
    