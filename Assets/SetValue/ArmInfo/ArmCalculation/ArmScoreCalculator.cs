using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This program calculates a score based on the attributes of each arm and selects the arm with the highest score.
It retrieves attribute values ​​and weights for each arm from the ArmValueSO and Confic2 ScriptableObjects to perform the score calculation.
Finally, it identifies the winning arm and activates a visual effect for it.
*/

public class ArmScoreCalculator : MonoBehaviour
{
    [SerializeField] private ArmValueSO armValueSO; //attaches the ArmValueSO ScriptableObject to retrieve arm attribute values
    [SerializeField] private Config config; //attaches the configuration object

    // アームのスコアを格納する配列
    [SerializeField] private float[] armScores;
    // A variable that stores the index of the arm with the highest score.
    [SerializeField] private int winnerArmIndex = -1; //-1 is a value that doesn't point to anything specific. I used -1 because 0 would be interpreted as "like."


    [SerializeField] private WinnerEffectController winnerEffectController; //Add a reference to WinnerEffectController.

    

    public void CalculateArmScores()
    {
        //Create an array based on the number of arms.
        armScores = new float[armValueSO.arms.Length];

        for (int i = 0; i < armValueSO.arms.Length; i++)
        {
            //Here, I ensure that arms marked as invalid—meaning the "enabled" checkbox is unchecked—are treated as disabled.
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

            // Calculate the score for each arm.
            armScores[i] = likeScore + repostScore + bookmarkScore + commentScore;
        }

        FindWinnerArm();
        
    }


    /*
    This program finds the arm with the highest value among the active arms.
    */
    private void FindWinnerArm()
    {
        winnerArmIndex = -1; // Initialize
        float highestScore = float.MinValue;

        //find the highest score
        for (int i = 0; i < armScores.Length; i++)
        {
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

        //When if more than one arm has the same highest score →　In the event of a tie, the winner is determined randomly.
        //Collect the arm associated with the highest score. This ensures that, in the event of a tie in arm values, the selection is made randomly.
        List<int> candidatesWinner = new List<int>();
        for (int i = 0; i < armScores.Length; i++)
        {
            if (!armValueSO.arms[i].isActive)
            {
                continue; 
            }

            if (armScores[i] == highestScore)
            {
                candidatesWinner.Add(i);
            }
        }

        if (candidatesWinner.Count > 0)
        {
            // Randomly select one of the tied arms
            winnerArmIndex = candidatesWinner[Random.Range(0, candidatesWinner.Count)];
        }


        Debug.Log("Winner Index: " + winnerArmIndex);
        Debug.Log("Winner Scores: " + highestScore);

        winnerEffectController.ActivateWinnerEffect(winnerArmIndex); // Activate the winner effect for the winning arm
    }

}
