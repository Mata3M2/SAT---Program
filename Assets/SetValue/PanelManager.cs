using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class Test : MonoBehaviour
{
    public GameObject[] panels;//GameObject型の変数aを宣言　好きなゲームオブジェクトをアタッチ
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//スペースキーが押されたら
        {
            foreach (GameObject panel in panels){
                panel.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))//エンターキーが押されたら
        {
             foreach (GameObject panel in panels){
                panel.SetActive(false);
            }
        }
    }
}
