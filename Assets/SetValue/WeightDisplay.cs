using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightDisplay : MonoBehaviour
{
    private float weight = 0.2f;
    private Text messageText;
    public Text weightText;
    public Text scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        messageText = GameObject.Find("WeightText").GetComponent<Text>();
        weightText = GameObject.Find("WeightText").GetComponent<Text>();
        scoreBoard = GameObject.Find("Score_Like").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
