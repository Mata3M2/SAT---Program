using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScoreCalculator : MonoBehaviour
{
    [SerializeField] private ArmValueSO armValueSO; //アームのプレハブをアタッチする
    [SerializeField] private Config config; //設定情報をアタッチする

    // アームのスコアを格納する配列
    [SerializeField] private float[] armScores;
    // 最もスコアが高いアームのインデックスを格納する変数. 
    [SerializeField] private int winnerArmIndex = -1; //マイナス1は何も指していない数値。0は「like」になってしまうので、マイナス1にしている。


    private void Start()
    {
        CalculateArmScores();
    }

    public void CalculateArmScores()
    {
        //アーム数に合わせて配列を作ります
        armScores = new float[armValueSO.arms.Length];

        for (int i = 0; i < armValueSO.arms.Length; i++)
        {
            //ここで有効のチェックが外れている無効なアームは、無効にするようにしています。
            if (!armValueSO.arms[i].isActive)
            {
                armScores[i] = 0f; // 無効なアームのスコアを0に設定
                continue; // 無効なアームは計算をスキップ
            }

            ArmData armData = armValueSO.arms[i];

            float likeScore = armData.likeAmount * config.weightValues[0];

            float repostScore = armData.repostAmount * config.weightValues[1];

            float bookmarkScore = armData.bookmarkAmount * config.weightValues[2];

            float commentScore = armData.commentAmount * config.weightValues[3];

            // 各アームのスコアを計算
            armScores[i] = likeScore + repostScore + bookmarkScore + commentScore;
        }

        FindWinnerArm();
        
    }


    /*
    This program finds the arm with the highest value among the active arms.
    */
    private void FindWinnerArm()
    {
        winnerArmIndex = -1; // 初期化
        float highestScore = float.MinValue;

        for (int i = 0; i < armScores.Length; i++){
            if (!armValueSO.arms[i].isActive)
            {
                continue; 
            }

            if (armScores[i] > highestScore)
            {
                highestScore = armScores[i];
                winnerArmIndex = i;
            }
        }

        Debug.Log("Winner Index: " + winnerArmIndex);
        Debug.Log("Winner Scores: " + highestScore);
    }

}
