using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject panels;//GameObject型の変数aを宣言　好きなゲームオブジェクトをアタッチ
    public WeightManager weightManager;
 
    void Update()
    {
        if ((int)weightManager.currentWeightIndex == 1) // if weight type is repost
        {
            panels.SetActive(true);//変数aにアタッチされているゲームオブジェクトをアクティブにする
        }
        else if (Input.GetKeyDown(KeyCode.Return))//エンターキーが押されたら
        {
            panels.SetActive(false);//変数aにアタッチされているゲームオブジェクトを非アクティブにする
        }
    }
          
}


     
    

