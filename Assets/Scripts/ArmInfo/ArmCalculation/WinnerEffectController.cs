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
    [SerializeField] private GameObject textToRemove; 

    public void ActivateWinnerEffect(int winnerIndex)
    {
        //at first eliminates winner effects from all arms, then activates the effect for the winning arm.
        for (int i = 0; i < winnerEffect.Length; i++)
        {
            winnerEffect[i].SetActive(false);
        }

        for (int i = 0; i < winnerEffect.Length; i++)
        {
            if (i == winnerIndex)
            {
                winnerEffect[i].SetActive(false);
            }        
                
            winnerEffect[winnerIndex].SetActive(true);
            textToRemove.SetActive(false);
        }
    }
    
    
}
