using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightDisplay : MonoBehaviour
{
    private float weight;
    private Text messageText;
    // Start is called before the first frame update
    void Start()
    {
        messageText = GameObject.Find("WeightText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            weight++;
            Debug.Log("重み: " + weight + "点");
        }
    }
}
