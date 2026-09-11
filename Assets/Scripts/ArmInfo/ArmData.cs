[System.Serializable]

/*
It manages and stores numerical values ​​for the arms. The ArmData class is a data structure designed to 
hold the counts for Likes, Reposts, Bookmarks, and comments for each arm.
*/
    public class ArmData
    {
        public int likeAmount;
        public int repostAmount;
        public int bookmarkAmount;
        public int commentAmount;

        public bool isActive; //これは後からアームを追加したり消したりできるから、その際、後の処理に含まれないようにするための変数です。

    }
