using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Controller for managing the visual effects of the winning arm.
This program activates a visual effect for the arm that has the highest score.
*/


public class WinnerEffectController : MonoBehaviour
{
    [SerializeField] private GameObject[] winnerEffect; 

    public void ActivateWinnerEffect(int winnerIndex)
    {
        for (int i = 0; i < winnerEffect.Length; i++)
        {
            if (i == winnerIndex)
            {
                winnerEffect[i].SetActive(false);
            }        
                
            winnerEffect[winnerIndex].SetActive(true);
        }
    }
    
    
}
