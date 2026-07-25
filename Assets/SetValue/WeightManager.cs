/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeightType
{
    Like,
    Repost,
    Comment,
    Bookmark
}

public class WeightManager : MonoBehaviour
{
    public float likeWeight; // current [like] weight
    public float repostWeight; // current [repost] weight
    public float commentWeight; // current [comment] weight
    public float bookmarkWeight; // current [bookmark] weight

    public void SetWeights(float like, float repost, float comment, float bookmark)
    {
        likeWeight = like;
        repostWeight = repost;
        commentWeight = comment;
        bookmarkWeight = bookmark;

        Debug.Log("Weights set: {Like=" + likeWeight + ", Repost=" + repostWeight + ", Comment=" + commentWeight + ", Bookmark=" + bookmarkWeight + "}");
    }

    // 1つのスライダー分の値だけを更新する（WeightSliderControllerから呼ばれる）
    public void SetWeight(WeightType type, float value)
    {
        switch (type)
        {
            case WeightType.Like:
                likeWeight = value;
                break;
            case WeightType.Repost:
                repostWeight = value;
                break;
            case WeightType.Comment:
                commentWeight = value;
                break;
            case WeightType.Bookmark:
                bookmarkWeight = value;
                break;
        }

        Debug.Log("Weights set: {Like=" + likeWeight + ", Repost=" + repostWeight + ", Comment=" + commentWeight + ", Bookmark=" + bookmarkWeight + "}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
