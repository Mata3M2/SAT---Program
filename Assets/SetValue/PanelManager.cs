using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelManager : MonoBehaviour
{
    [SerializeField]private GameObject[] panels;//GameObject型の変数aを宣言　好きなゲームオブジェクトをアタッチ
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