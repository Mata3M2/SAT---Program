using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    private int score;
    public Text messageText;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            messageText.text = "書き換えました！";
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            score++;
            Debug.Log("スコア: " + score + "点");

            scoreText.text = "Score :" + score;
        }
    }
}
