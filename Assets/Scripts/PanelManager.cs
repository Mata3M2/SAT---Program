using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This program manages the display of panels based on the current weight type.
/// </summary>
public class PanelManager : MonoBehaviour
{
    [SerializeField]private GameObject[] panels;//Control the display of panels based on the current weight type.
    public WeightManager weightManager;
 
    public void RefreshPanels()
    {
        int index = (int)weightManager.currentWeightIndex;
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == index);
        }
    }
          
}