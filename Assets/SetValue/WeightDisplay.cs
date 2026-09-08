using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WeightDisplay : MonoBehaviour
{
    private WeightManager weightManager;
    [SerializeField] private GameObject messageText;
    
    public Text weightText;     
    public Text score_Like;
    public Text score_Repost;
    public Text score_Bookmark;
    public Text score_Comment;
    // Start is called before the first frame update
    void Awake() //こいつはテキストを変えるときに絶対必要。
    {
        weightText = GameObject.Find("WeightText").GetComponent<Text>();
        score_Like = GameObject.Find("Score_Like").GetComponent<Text>();
        score_Repost = GameObject.Find("Score_Repost").GetComponent<Text>();
        score_Bookmark = GameObject.Find("Score_Bookmark").GetComponent<Text>();
        score_Comment = GameObject.Find("Score_Comment").GetComponent<Text>();

    }

    // Update is called once per frame
}
