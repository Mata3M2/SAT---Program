using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject a;//GameObject型の変数aを宣言　好きなゲームオブジェクトをアタッチ
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//スペースキーが押されたら
        {
            a.SetActive(true);//変数aにアタッチされているゲームオブジェクトをアクティブにする
        }
        else if (Input.GetKeyDown(KeyCode.Return))//エンターキーが押されたら
        {
            a.SetActive(false);//変数aにアタッチされているゲームオブジェクトを非アクティブにする
        }
    }
}
